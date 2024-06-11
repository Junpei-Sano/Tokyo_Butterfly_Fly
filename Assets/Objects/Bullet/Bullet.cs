using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float _speed = 2000;
    float _killtime = 2.0f;  //��莞�Ԍo�ߌ�I�u�W�F�N�g������
    int _boundTimes = 2;

    private Rigidbody _rigidbody;
    private float _time;
    private int _boundCount = 0;

    // Start is called before the first frame update
    public void Fire(Vector3 direction)
    {
        Vector3 force = direction.normalized * _speed;
        _rigidbody = this.GetComponent<Rigidbody>();
        _rigidbody.AddForce(force);
        _time = Time.time;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _time > _killtime)    //n�b�ȏ���ł������
        {
            Destroy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _boundCount++;
        if (_boundCount >= _boundTimes)    //n��ȏ㔽�������Ȃ�
        {
            Destroy();
        }
    }
}
