using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerManager;    // 追加

using MyPhotonMessage;

/*
 * 注意
 * ・回転は親オブジェクトを動かさない、Modelのみ回転させる
 * 　・よって方向取得はModelのtransformを使用すること
 * ・移動は親オブジェクトを動かす
 * ・Input_systemの時親子関係が変わるので注意
 * */

public class SampleCharacter3 : PlayerInformationBase
{
    private ReadInput _input;
    private Rigidbody _rigidbody;
    private Transform _model;
    private Butterfly.Motion _butterfly;
    private Arrow _arrow;

    [SerializeField] private GameObject _deathObj;
    [SerializeField] private MessagePanelController _msgPanel;

    private readonly float _deathMagnitude = 20;
    private readonly float _acceleration = 30;//1800;
    private readonly float _mass = 1;
    private readonly float _drag = 0.1f;
    private readonly float _anglarDrag = 1.0f;
    private Vector3 _gravity = new Vector3(0, -9.8f, 0);
    private readonly float _propellingPower = 0.07f;//4f;
    private readonly float _jumpPower = 0.5f;

    protected override void Awake()
    {
        base.Awake();
        _rigidbody = this.GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = new Vector3(0, 0f, 0);
        _model = this.transform.Find("Model").gameObject.transform;
        _arrow = _model.transform.Find("Forward/Arrow").gameObject.GetComponent<Arrow>();

        _rigidbody.mass = _mass;
        _rigidbody.drag = _drag;
        _rigidbody.angularDrag = _anglarDrag;
        Physics.gravity = _gravity;
        _rigidbody.useGravity = true;
    }

    private void Start()
    {
        GameObject butterfly = this.transform.Find("Model/Model").gameObject;

        switch (base.controllerType)
        {
            case ControllerType.input_system_wing:
                _input = new ReadInputSystemWing();    //アップキャスト
                _butterfly = new Butterfly.Motion_InputSystem(butterfly, _input);
                this.transform.Find("OVRPlayerController").parent = _model;
                break;
            case ControllerType.oculus_wing:
                _input = new ReadOculusWing(this.gameObject, _model);
                _butterfly = new Butterfly.Motion_Oculus(butterfly, this.gameObject);
                break;
            default:
                Debug.LogWarning("Unsupported Controller type: " + base.controllerType);
                break;
        }
        this.GetComponent<CapsuleCollider>().enabled = true;
        _deathObj.SetActive(false);
        _msgPanel.InitPanel(this, _input);
    }

    private void Rudder(float angle)
    {
        Vector3 plane = _model.InverseTransformDirection(Vector3.up);
        _model.rotation *= Quaternion.AngleAxis(angle, plane);
    }

    private void Elevator(float angle)
    {
        _model.rotation *= Quaternion.AngleAxis(angle, Vector3.right);
    }

    private void Aileron(float angle)
    {
        _model.rotation *= Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Throttle(float value)
    {
        Vector3 direction = _model.up;
        Vector3 power = direction * value * _acceleration * -Physics.gravity.y/* * Time.deltaTime*/;
        _rigidbody.AddForce(power, ForceMode.Acceleration);    // y方向に力
    }

    private void PropellingPower()
    {
        if (_rigidbody.velocity.y < 0)    // 下降中のとき
        {
            float power = -_rigidbody.velocity.y * _propellingPower * -Physics.gravity.y/* * Time.deltaTime*/;
            _rigidbody.AddForce(_model.up * power, ForceMode.Acceleration);
        }
    }

    private void PlayerDeath(DeathPattern d)
    {
        if (_deathObj == null)
        {
            Debug.LogWarning("Cannot find the object of death display.");
            return;
        }
        Debug.Log("You Died");
        _deathObj.GetComponent<DeathMessage>().deathPattern = d;
        _deathObj.SetActive(true);
        this.GetComponent<SampleCharacter3>().enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        float magnitude = collision.impulse.magnitude;
        Debug.LogFormat("Collision: {0}, Magnitude = {1}", collision.gameObject.name, magnitude);

        if (magnitude > _deathMagnitude)
        {
            PlayerDeath(DeathPattern.collision);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        float pow = _input.JumpAction();
        if (pow >= 1f && !_deathObj.activeSelf)    // マジックナンバーは適当な数（小ジャン連続により地面に着かない状態を防ぐ）
        {
            Debug.Log("Jump");
            Throttle(pow * _jumpPower);
        }
    }

    private void FallVoidCheck()    // 奈落チェック
    {
        if (this.transform.position.y < -250)
        {
            PlayerDeath(DeathPattern.fallVoid);
            _rigidbody.velocity = Vector3.zero;    // 停止させる
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (_input.ReadFireButton()) { _arrow.TargetSelection(); }

        // 操作性の関係からモード1の割り当て
        Vector2 stickR = _input.ReadStick_R();
        Vector2 stickL = _input.ReadStick_L();

        Rudder(stickL.x);
        Elevator(stickL.y);
        Aileron(stickR.x);
        Throttle(stickR.y);

        PropellingPower();
        FallVoidCheck();

        _butterfly.Flap();
    }
}

public class ReadOculusWing : ReadInput    // Oculusのコントローラを使用
{
    private float _throttlePower = 3;

    private Transform _model;
    private GameObject _centerEye;
    private GameObject _LeftHand;
    private GameObject _RightHand;

    private float _previousY = 0.0f;

    private float _previousEyeAveY = 0.0f;
    private float _jumpLowest = float.MaxValue;
    private float _jumpTime = float.MaxValue;
    private bool _isJumping = false;

    public ReadOculusWing(GameObject player, Transform model)
    {
        Debug.Log("Input: Oculus (Wing)");

        _centerEye = player.transform.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/CenterEyeAnchor").gameObject;
        _LeftHand = player.transform.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/LeftHandAnchor/LeftControllerAnchor").gameObject;
        _RightHand = player.transform.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/RightHandAnchor/RightControllerAnchor").gameObject;

        _model = model;
    }

    private float VectorAngle(Vector3 from, Vector3 to, Vector3 planeNormal)
    {
        Vector3 planeFrom = Vector3.ProjectOnPlane(from, planeNormal);
        Vector3 planeTo = Vector3.ProjectOnPlane(to, planeNormal);
        float angle = Vector3.SignedAngle(planeFrom, planeTo, planeNormal);
        return angle;
    }

    // 地面に着いている際のジャンプ動作
    public override float JumpAction()
    {
        float power = 0.0f;
        float currentY = _centerEye.transform.position.y;
        float currentAveY = _centerEye.transform.position.y + _RightHand.transform.position.y + _LeftHand.transform.position.y;
        float dy = currentAveY - _previousEyeAveY;
        float time = Time.time - _jumpTime;
        if (time > 2.0 && _isJumping == true)    // 2秒以上のときはジャンプでないと判定
        {
            _jumpTime = Time.time;
            _isJumping = false;
        }
        else if (dy > 0 && _isJumping == false)    // 3点の平均値が上昇中
        {
            _isJumping = true;
            _jumpTime = Time.time;
        }
        else if (dy <= 0)
        {
            if (_isJumping == true)
            {
                power = currentY - _jumpLowest;
                power /= time;
                _isJumping = false;
                _jumpLowest = float.MaxValue;
            }
            else
            {
                _jumpLowest = currentY;
            }
        }
        _previousEyeAveY = currentAveY;
        return power;
    }

    public override Vector2 ReadStick_L()
    {
        Vector2 angle;
        // ラダー
        Vector3 rightFrom = _model.transform.right;
        Vector3 rightTo = (_RightHand.transform.position - _LeftHand.transform.position).normalized;
        Vector3 plane = _model.InverseTransformDirection(Vector3.up);
        angle.x = VectorAngle(rightFrom, rightTo, plane);

        // エレベーター・2つのコントローラの中点から本体に伸びるベクトル
        Vector3 upFrom = _model.transform.up;
        Vector3 center = (_RightHand.transform.position + _LeftHand.transform.position) / 2;
        Vector3 upTo = (_centerEye.transform.position - center).normalized;
        angle.y = VectorAngle(upFrom, upTo, _model.right);
        /* 旧バージョン
        Vector3 rUp = _model.transform.InverseTransformDirection(_RightHand.transform.up);
        Vector3 lUp = _model.transform.InverseTransformDirection(_LeftHand.transform.up);
        float averageZ = (rUp.z + lUp.z) / 2;      // 左右の傾きの平均をとることとする
        float val = averageZ * _rotateSpeed.x * Time.deltaTime;
        Quaternion q = Quaternion.AngleAxis(val, _transform.InverseTransformDirection(_model.right));
        _rigidbody.rotation *= q;
        */

        return angle;
    }

    public override Vector2 ReadStick_R()
    {
        Vector2 angle = Vector2.zero;
        // エルロン
        Vector3 rightFrom = _model.transform.right;
        Vector3 rightTo = (_RightHand.transform.position - _LeftHand.transform.position).normalized;
        angle.x = VectorAngle(rightFrom, rightTo, _model.forward);

        // スロットル
        Vector3 average = (_RightHand.transform.position + _LeftHand.transform.position) / 2;
        float currentY = _centerEye.transform.position.y - average.y;
        float dy = currentY - _previousY;
        if (dy > 0 && _previousY != 0.0f)
        {
            angle.y = dy * _throttlePower;
        }
        _previousY = currentY;

        return angle;
    }

    public override bool ReadQuitButton()
    {
        return OVRInput.GetDown(OVRInput.Button.Start);
    }

    public override bool ReadFireButton()
    {
        return OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger);
    }

    public override bool ReadMessageButton()
    {
        return OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger);
    }

    public override bool ReadEscButton()
    {
        return ReadMessageButton();
    }
}


public class ReadInputSystemWing : ReadInput    // input system（キーボード）使用
{
    private float _RudderSpeed = 1.0f;
    private float _elevatorSpeed = 1.0f;
    private float _aileronSpeed = 30.0f;
    private float _throttlePower = 0.5f;

    private Test_Actions _input;

    public ReadInputSystemWing()
    {
        _input = new Test_Actions();
        _input.Enable();
        Debug.Log("Input: Input System");
    }

    public override Vector2 ReadStick_R()
    {
        Vector2 val = Vector2.zero;
        val.x = -_input.User.Rotate.ReadValue<Vector2>().x * _aileronSpeed * Time.deltaTime;
        if (this.ReadUpButton())
        {
            val.y = _throttlePower;
        }
        return val;
    }

    public override Vector2 ReadStick_L()
    {
        Vector2 val = _input.User.Move.ReadValue<Vector2>();
        val.x *= _RudderSpeed;
        val.y *= _elevatorSpeed;
        return val;
    }

    public override bool ReadQuitButton()
    {
        return _input.User.Quit.triggered;
    }

    public override bool ReadFireButton()
    {
        return _input.User.Fire.triggered;
    }

    public override bool ReadUpButton()
    {
        return _input.User.Up.triggered;
    }
    public override bool ReadMessageButton()
    {
        return _input.User.Message.triggered;
    }

    public override bool ReadEscButton()
    {
        return _input.User.Esc.triggered;
    }

    public override float JumpAction()
    {
        if (_input.User.Jump.triggered)
        {
            Debug.Log("Jump");
            return 1;
        }
        else
        {
            return 0;
        }
    }
}


namespace Butterfly
{
    public abstract class Motion
    {
        private float _maxWingRange = 120;
        private float _minWingRange = -30;

        private GameObject _butterflyR;
        private GameObject _butterflyL;
        private Quaternion _defaultWingL;    //初期の翅状態保存用
        private Quaternion _defaultWingR;

        public Motion(GameObject butterfly)
        {
            _butterflyR = butterfly.transform.Find("right_wing").gameObject;
            _butterflyL = butterfly.transform.Find("left_wing").gameObject;
            _defaultWingL = _butterflyL.transform.localRotation;    //翅の初期状態を記憶
            _defaultWingR = _butterflyR.transform.localRotation;
        }

        private float CulcButterflyAnlge(float x)    // xは0から1
        {
            float angle = (_maxWingRange - _minWingRange) * (x >= 0 ? x : 0) + _minWingRange;
            return angle;
        }

        protected void Flap_base(float left, float right)    // left, right は0から1
        {
            float angleL = CulcButterflyAnlge(left);
            _butterflyL.transform.localRotation = _defaultWingL * Quaternion.AngleAxis(angleL, Vector3.up);
            float angleR = CulcButterflyAnlge(right);
            _butterflyR.transform.localRotation = _defaultWingR * Quaternion.AngleAxis(-angleR, Vector3.up);
        }

        public abstract void Flap();
    }

    public class Motion_Oculus : Motion
    {
        private GameObject _centerEye;
        private GameObject _LeftHand;
        private GameObject _RightHand;

        public Motion_Oculus(GameObject butterfly, GameObject player) : base(butterfly)
        {
            _centerEye = player.transform.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/CenterEyeAnchor").gameObject;
            _LeftHand = player.transform.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/LeftHandAnchor/LeftControllerAnchor").gameObject;
            _RightHand = player.transform.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/RightHandAnchor/RightControllerAnchor").gameObject;
        }

        public override void Flap()
        {
            float leftWing = (_LeftHand.transform.position - _centerEye.transform.position).normalized.y;
            float rightWing = (_RightHand.transform.position - _centerEye.transform.position).normalized.y;
            Flap_base(-leftWing, -rightWing);
        }
    }

    public class Motion_InputSystem : Motion
    {
        private float flapSpeed = 4.0f;     //最大1
        private float flapReturnSpeed = 3.0f;
        private float flapMaxRange = 0.6f;
        private float flapMinRange = 0.1f;

        private ReadInput _input;
        private bool _isFlapping = false;
        private float _angle = 0;

        public Motion_InputSystem(GameObject butterfly, ReadInput input) : base(butterfly)
        {
            _input = input;
        }

        public override void Flap()
        {
            if (_input.ReadUpButton()) { _isFlapping = true; }
            if (_isFlapping)
            {
                if (_angle < flapMaxRange) { _angle += flapSpeed * Time.deltaTime; }
                else { _isFlapping = false; }
            }
            else if (_angle > flapMinRange) { _angle -= flapReturnSpeed * Time.deltaTime; }
            Flap_base(_angle, _angle);
        }
    }
}