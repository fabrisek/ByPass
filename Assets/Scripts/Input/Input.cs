//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Input/Input.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Input : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""InGame"",
            ""id"": ""5e82d339-bc0b-4b1c-96c2-15e6b5cbac9b"",
            ""actions"": [
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""b74bec3b-0992-45b5-8018-07c51eca0afe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ba829a80-c391-452c-984c-91b990365aef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""22abd81e-ccde-41a5-8341-5982a60fe6d4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""c58f285a-1a67-4811-88f3-33ad8fa08013"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""f10ede12-e63d-4204-a440-cb4509be8f12"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SlowTime"",
                    ""type"": ""Button"",
                    ""id"": ""271846ed-42e6-4b36-9f12-78de11a101c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Grappling"",
                    ""type"": ""Button"",
                    ""id"": ""d389e2a9-9d34-4754-ab9f-7a9bb46f6ded"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""4db8fe25-a37c-4dd6-b8d5-73fe6787bf07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""61fbf334-b214-4c0c-ba04-221cf7a7ba92"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e3bf8ebe-d2c7-42d4-b737-391d943e9fbb"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28bf49c3-f98c-4949-8703-9e325d525753"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27d09d68-b10b-4112-982f-89a4988fbc3a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7eb0d58-b175-4cd6-a158-195087787cf1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4cbb5ad-ddbc-40da-b6ea-87896c5ff86c"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df2a4675-9050-44a2-8402-50f51e3acf9e"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fdc8e5e5-26c7-4b26-9aad-a1da20b29185"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""KeyBoard"",
                    ""id"": ""18f5c954-fdfa-4cd0-9ce0-3d757a63cbc5"",
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
                    ""id"": ""d11d1d2b-4ff0-4c9a-bc49-0d02452722df"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9f874b39-8092-4b9f-ba17-4e657e935b06"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6613b31b-b12b-42f1-916f-67333e67099b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4504f042-eb79-4a9e-b34d-ab09e37bd25c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""106c1e67-9a0a-4a8b-9b8c-a21726b50ad4"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.5,y=0.5)"",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""427281c0-a1f2-455c-8169-d1f198e0a12a"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""SlowTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""483cd423-8f45-4d28-99e2-cf5e34c7beb4"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SlowTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c0c3ab0-30b0-4e01-a103-dba532b8ef0a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""Grappling"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58968c55-eb6e-4241-b3c4-332423e389d0"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone(min=0.05,max=0.9)"",
                    ""groups"": """",
                    ""action"": ""Grappling"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd384357-6c2b-4198-92d3-fe42d0a68a78"",
                    ""path"": ""<Keyboard>/delete"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe6028f2-c8be-4e9f-adb8-14a8bdf19e88"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3ba3c68-be8a-474c-a414-df548bb322f8"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a4022ef-8bd4-480a-8c49-2763c334756a"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InMainMenu"",
            ""id"": ""7d200b25-9423-4c3b-b1fc-c8014fd9a258"",
            ""actions"": [
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""f40dacf0-6c87-4a82-9963-f791872f23e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""25a76cdc-caea-4682-ab74-029aec25b7c5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c70ee454-b48c-4462-8393-2fa177b4bef5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a256c9a9-157e-4b92-89ca-34f67d763b8b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86a8ca62-88e0-49ae-8eac-a07671718a06"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3422a8d6-1b40-4be5-89c7-a5882433a948"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa137e87-793f-4fbc-9dfe-dd3bc9d370fc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b83d0b0c-ab1e-4109-b7d9-d4cbd0868750"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""KeyBoard"",
                    ""id"": ""0b160762-4838-4a06-b1d0-1093ebda518c"",
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
                    ""id"": ""2c9390ff-50b2-445c-93d3-0face16d4bd3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""71bbeeb7-ad54-46d0-93f4-f54510c968c0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""50da0f76-2bef-45f4-ad62-2415b905d5f5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c4a4a8ca-b341-43b4-88cb-26f26d26427d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""763cd882-1e1e-430e-aa5a-f342bfab702d"",
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
                    ""id"": ""8355187b-1e44-4b2f-9b0a-072a0ca672de"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c08add2f-e941-450c-8bda-01e7774981a5"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""78a24d53-d1b1-4b3c-bb97-6ea7f589d748"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""443d48f4-ee8d-4dc0-99b8-074517fe6572"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyBoard"",
            ""bindingGroup"": ""KeyBoard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // InGame
        m_InGame = asset.FindActionMap("InGame", throwIfNotFound: true);
        m_InGame_Start = m_InGame.FindAction("Start", throwIfNotFound: true);
        m_InGame_Jump = m_InGame.FindAction("Jump", throwIfNotFound: true);
        m_InGame_Move = m_InGame.FindAction("Move", throwIfNotFound: true);
        m_InGame_Look = m_InGame.FindAction("Look", throwIfNotFound: true);
        m_InGame_Mouse = m_InGame.FindAction("Mouse", throwIfNotFound: true);
        m_InGame_SlowTime = m_InGame.FindAction("SlowTime", throwIfNotFound: true);
        m_InGame_Grappling = m_InGame.FindAction("Grappling", throwIfNotFound: true);
        m_InGame_Restart = m_InGame.FindAction("Restart", throwIfNotFound: true);
        m_InGame_Pause = m_InGame.FindAction("Pause", throwIfNotFound: true);
        // InMainMenu
        m_InMainMenu = asset.FindActionMap("InMainMenu", throwIfNotFound: true);
        m_InMainMenu_Back = m_InMainMenu.FindAction("Back", throwIfNotFound: true);
        m_InMainMenu_Select = m_InMainMenu.FindAction("Select", throwIfNotFound: true);
        m_InMainMenu_Move = m_InMainMenu.FindAction("Move", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // InGame
    private readonly InputActionMap m_InGame;
    private IInGameActions m_InGameActionsCallbackInterface;
    private readonly InputAction m_InGame_Start;
    private readonly InputAction m_InGame_Jump;
    private readonly InputAction m_InGame_Move;
    private readonly InputAction m_InGame_Look;
    private readonly InputAction m_InGame_Mouse;
    private readonly InputAction m_InGame_SlowTime;
    private readonly InputAction m_InGame_Grappling;
    private readonly InputAction m_InGame_Restart;
    private readonly InputAction m_InGame_Pause;
    public struct InGameActions
    {
        private @Input m_Wrapper;
        public InGameActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Start => m_Wrapper.m_InGame_Start;
        public InputAction @Jump => m_Wrapper.m_InGame_Jump;
        public InputAction @Move => m_Wrapper.m_InGame_Move;
        public InputAction @Look => m_Wrapper.m_InGame_Look;
        public InputAction @Mouse => m_Wrapper.m_InGame_Mouse;
        public InputAction @SlowTime => m_Wrapper.m_InGame_SlowTime;
        public InputAction @Grappling => m_Wrapper.m_InGame_Grappling;
        public InputAction @Restart => m_Wrapper.m_InGame_Restart;
        public InputAction @Pause => m_Wrapper.m_InGame_Pause;
        public InputActionMap Get() { return m_Wrapper.m_InGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void SetCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterface != null)
            {
                @Start.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnStart;
                @Jump.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnLook;
                @Mouse.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnMouse;
                @SlowTime.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnSlowTime;
                @SlowTime.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnSlowTime;
                @SlowTime.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnSlowTime;
                @Grappling.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnGrappling;
                @Grappling.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnGrappling;
                @Grappling.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnGrappling;
                @Restart.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnRestart;
                @Pause.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_InGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
                @SlowTime.started += instance.OnSlowTime;
                @SlowTime.performed += instance.OnSlowTime;
                @SlowTime.canceled += instance.OnSlowTime;
                @Grappling.started += instance.OnGrappling;
                @Grappling.performed += instance.OnGrappling;
                @Grappling.canceled += instance.OnGrappling;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public InGameActions @InGame => new InGameActions(this);

    // InMainMenu
    private readonly InputActionMap m_InMainMenu;
    private IInMainMenuActions m_InMainMenuActionsCallbackInterface;
    private readonly InputAction m_InMainMenu_Back;
    private readonly InputAction m_InMainMenu_Select;
    private readonly InputAction m_InMainMenu_Move;
    public struct InMainMenuActions
    {
        private @Input m_Wrapper;
        public InMainMenuActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Back => m_Wrapper.m_InMainMenu_Back;
        public InputAction @Select => m_Wrapper.m_InMainMenu_Select;
        public InputAction @Move => m_Wrapper.m_InMainMenu_Move;
        public InputActionMap Get() { return m_Wrapper.m_InMainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InMainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IInMainMenuActions instance)
        {
            if (m_Wrapper.m_InMainMenuActionsCallbackInterface != null)
            {
                @Back.started -= m_Wrapper.m_InMainMenuActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_InMainMenuActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_InMainMenuActionsCallbackInterface.OnBack;
                @Select.started -= m_Wrapper.m_InMainMenuActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_InMainMenuActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_InMainMenuActionsCallbackInterface.OnSelect;
                @Move.started -= m_Wrapper.m_InMainMenuActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_InMainMenuActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_InMainMenuActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_InMainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public InMainMenuActions @InMainMenu => new InMainMenuActions(this);
    private int m_KeyBoardSchemeIndex = -1;
    public InputControlScheme KeyBoardScheme
    {
        get
        {
            if (m_KeyBoardSchemeIndex == -1) m_KeyBoardSchemeIndex = asset.FindControlSchemeIndex("KeyBoard");
            return asset.controlSchemes[m_KeyBoardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IInGameActions
    {
        void OnStart(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnMouse(InputAction.CallbackContext context);
        void OnSlowTime(InputAction.CallbackContext context);
        void OnGrappling(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IInMainMenuActions
    {
        void OnBack(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
