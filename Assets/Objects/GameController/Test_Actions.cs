// GENERATED AUTOMATICALLY FROM 'Assets/Objects/GameController/Test_Actions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Test_Actions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Test_Actions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Test_Actions"",
    ""maps"": [
        {
            ""name"": ""User"",
            ""id"": ""72c42010-005d-4da0-8438-51ac4af85d8a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""e91233a8-70f2-4630-82db-3115f2119aef"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""d5e0307b-e0ed-43ef-b6df-758802e4a84e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""4c12572a-b370-4f22-ad73-a16979a5ffb0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""2f5992ca-b52a-485a-b9fa-f1fc2412e5f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""d00328f3-a45f-44c4-a76e-3c989c664dd0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""2c5e08dd-4fbe-467d-9e17-14087f330236"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""2626729a-36d3-4e5b-aa5b-d8e62221ab6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Message"",
                    ""type"": ""Button"",
                    ""id"": ""4e2d58ec-6e5e-4f07-af0a-bd0d9571e75b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Esc"",
                    ""type"": ""Button"",
                    ""id"": ""527eec0e-910c-4b32-8c2c-95dfaf74e752"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c5d01d2e-04db-4abd-a505-dfe593fd68ca"",
                    ""path"": ""<SwitchProControllerHID>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Pro Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c129183f-67e2-47e8-b9e5-e01af0182796"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4db66a41-5781-4a91-af56-537569d91b83"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ad702b92-0315-43bc-87ff-1722ba6518fc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""75aace95-d811-4cd8-a9f8-c78358766217"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a693e96b-ccb2-42b2-bef2-61dd92d12dbf"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7d20f9a3-a192-44d9-90c9-62cb17462b50"",
                    ""path"": ""<SwitchProControllerHID>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Pro Controller"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2f3008e7-0a8c-42c4-bb50-52a2f0c1f774"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""257a6513-d0e8-45c7-93b9-6f5fc0ce912b"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f16af0a7-809f-4d30-9cb7-e76e6d6b52f8"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""633f7653-c15f-49c4-98fb-cca14780c4e9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""45b48a3b-7f4a-4b2c-8de4-ca7b006abd1b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a278727b-4b2e-426a-ad19-620eedbb409c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""931e6e13-8ece-409e-b418-301aa50098fc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf9bb760-0d2c-4f1c-8818-0d6ca538d4ca"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Pro Controller"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10f93f13-87d2-4894-b3ea-6d2a7da9ece5"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c029c2a-656b-4758-a95f-ed99d6a9d5f4"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2faf2e8-0265-4efb-b0ca-acbcd95ee800"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1eca4036-0c3d-4282-8973-cfb7e3928f91"",
                    ""path"": ""<SwitchProControllerHID>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Pro Controller"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b52a22e-7f35-442e-bfef-e41d29f28eda"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f87dfacf-3ac7-46e5-b161-fdb62f46d1ad"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Message"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7f10526-0426-4b87-8485-a172fa368313"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Esc"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Pro Controller"",
            ""bindingGroup"": ""Pro Controller"",
            ""devices"": []
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        }
    ]
}");
        // User
        m_User = asset.FindActionMap("User", throwIfNotFound: true);
        m_User_Move = m_User.FindAction("Move", throwIfNotFound: true);
        m_User_Rotate = m_User.FindAction("Rotate", throwIfNotFound: true);
        m_User_Up = m_User.FindAction("Up", throwIfNotFound: true);
        m_User_Down = m_User.FindAction("Down", throwIfNotFound: true);
        m_User_Quit = m_User.FindAction("Quit", throwIfNotFound: true);
        m_User_Fire = m_User.FindAction("Fire", throwIfNotFound: true);
        m_User_Jump = m_User.FindAction("Jump", throwIfNotFound: true);
        m_User_Message = m_User.FindAction("Message", throwIfNotFound: true);
        m_User_Esc = m_User.FindAction("Esc", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // User
    private readonly InputActionMap m_User;
    private IUserActions m_UserActionsCallbackInterface;
    private readonly InputAction m_User_Move;
    private readonly InputAction m_User_Rotate;
    private readonly InputAction m_User_Up;
    private readonly InputAction m_User_Down;
    private readonly InputAction m_User_Quit;
    private readonly InputAction m_User_Fire;
    private readonly InputAction m_User_Jump;
    private readonly InputAction m_User_Message;
    private readonly InputAction m_User_Esc;
    public struct UserActions
    {
        private @Test_Actions m_Wrapper;
        public UserActions(@Test_Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_User_Move;
        public InputAction @Rotate => m_Wrapper.m_User_Rotate;
        public InputAction @Up => m_Wrapper.m_User_Up;
        public InputAction @Down => m_Wrapper.m_User_Down;
        public InputAction @Quit => m_Wrapper.m_User_Quit;
        public InputAction @Fire => m_Wrapper.m_User_Fire;
        public InputAction @Jump => m_Wrapper.m_User_Jump;
        public InputAction @Message => m_Wrapper.m_User_Message;
        public InputAction @Esc => m_Wrapper.m_User_Esc;
        public InputActionMap Get() { return m_Wrapper.m_User; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UserActions set) { return set.Get(); }
        public void SetCallbacks(IUserActions instance)
        {
            if (m_Wrapper.m_UserActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_UserActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_UserActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnRotate;
                @Up.started -= m_Wrapper.m_UserActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_UserActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnDown;
                @Quit.started -= m_Wrapper.m_UserActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnQuit;
                @Fire.started -= m_Wrapper.m_UserActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnFire;
                @Jump.started -= m_Wrapper.m_UserActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnJump;
                @Message.started -= m_Wrapper.m_UserActionsCallbackInterface.OnMessage;
                @Message.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnMessage;
                @Message.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnMessage;
                @Esc.started -= m_Wrapper.m_UserActionsCallbackInterface.OnEsc;
                @Esc.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnEsc;
                @Esc.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnEsc;
            }
            m_Wrapper.m_UserActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Message.started += instance.OnMessage;
                @Message.performed += instance.OnMessage;
                @Message.canceled += instance.OnMessage;
                @Esc.started += instance.OnEsc;
                @Esc.performed += instance.OnEsc;
                @Esc.canceled += instance.OnEsc;
            }
        }
    }
    public UserActions @User => new UserActions(this);
    private int m_ProControllerSchemeIndex = -1;
    public InputControlScheme ProControllerScheme
    {
        get
        {
            if (m_ProControllerSchemeIndex == -1) m_ProControllerSchemeIndex = asset.FindControlSchemeIndex("Pro Controller");
            return asset.controlSchemes[m_ProControllerSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IUserActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMessage(InputAction.CallbackContext context);
        void OnEsc(InputAction.CallbackContext context);
    }
}
