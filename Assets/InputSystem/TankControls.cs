//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputSystem/TankControls.inputactions
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

public partial class @TankControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @TankControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TankControls"",
    ""maps"": [
        {
            ""name"": ""TankInput"",
            ""id"": ""3bb0f98b-547c-4dce-ac39-34cd33f06778"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""2160b79b-f3a6-4b0d-871d-082ef11929fa"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""91dece20-ca70-487c-835d-605626244589"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RotateCannon"",
                    ""type"": ""Value"",
                    ""id"": ""9ce9138b-295d-4787-93fa-ce00b4051d97"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""2c90f7cb-1629-4171-9e85-14d8eb5a271d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WS"",
                    ""id"": ""99d393dd-0dcb-4756-a5e0-4845b859a0ca"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""b206cc49-46b3-4fe2-98dd-d4ebfb4dc50b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""28d40cef-ecae-4e22-af36-8ae72e04cb1a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftStick"",
                    ""id"": ""1b98a1a2-3b50-4a0e-b0d3-241a41bc4158"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""e1df12db-5316-4819-b3af-aee34700e6c6"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""c51e8b5c-af0b-4108-97c5-37e48b0d9979"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1e36e541-1aea-4223-a210-fb9d18af2d69"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2438cdb6-1072-4354-9081-c08eed1d4764"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""0b9dc5dc-386d-4ef7-8003-eeeff41eaa97"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""fe48429e-4f2a-4cd1-ad21-57658cf718a0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""60544758-5821-45b9-8743-1598e3e1196e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftStick"",
                    ""id"": ""9ab558db-cdea-4f0a-84b1-ac8571b0c58f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""88b13b62-167a-4ddf-ae1c-ee11542205b8"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""e6e3482f-64fe-422a-8ff8-0769efb19aaf"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""977f4b5a-2082-42ec-a0b9-735cf1324c9c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCannon"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""f19ec0ac-ed19-44f0-a426-6009f1475160"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""RotateCannon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""94c5205e-5bd4-4d4e-b7d1-d3d7f617d4b5"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""RotateCannon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftStick"",
                    ""id"": ""e63da86f-c104-48b8-8e4f-dce9860b9cfb"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCannon"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""e10032c2-8655-4935-9d07-76dc54905013"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RotateCannon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""6cfb31b6-f98c-4c4d-ac61-d14f1bda89a1"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RotateCannon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard_Mouse"",
            ""bindingGroup"": ""Keyboard_Mouse"",
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
        // TankInput
        m_TankInput = asset.FindActionMap("TankInput", throwIfNotFound: true);
        m_TankInput_Move = m_TankInput.FindAction("Move", throwIfNotFound: true);
        m_TankInput_Rotate = m_TankInput.FindAction("Rotate", throwIfNotFound: true);
        m_TankInput_RotateCannon = m_TankInput.FindAction("RotateCannon", throwIfNotFound: true);
        m_TankInput_Attack = m_TankInput.FindAction("Attack", throwIfNotFound: true);
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

    // TankInput
    private readonly InputActionMap m_TankInput;
    private ITankInputActions m_TankInputActionsCallbackInterface;
    private readonly InputAction m_TankInput_Move;
    private readonly InputAction m_TankInput_Rotate;
    private readonly InputAction m_TankInput_RotateCannon;
    private readonly InputAction m_TankInput_Attack;
    public struct TankInputActions
    {
        private @TankControls m_Wrapper;
        public TankInputActions(@TankControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_TankInput_Move;
        public InputAction @Rotate => m_Wrapper.m_TankInput_Rotate;
        public InputAction @RotateCannon => m_Wrapper.m_TankInput_RotateCannon;
        public InputAction @Attack => m_Wrapper.m_TankInput_Attack;
        public InputActionMap Get() { return m_Wrapper.m_TankInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TankInputActions set) { return set.Get(); }
        public void SetCallbacks(ITankInputActions instance)
        {
            if (m_Wrapper.m_TankInputActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_TankInputActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TankInputActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TankInputActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_TankInputActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_TankInputActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_TankInputActionsCallbackInterface.OnRotate;
                @RotateCannon.started -= m_Wrapper.m_TankInputActionsCallbackInterface.OnRotateCannon;
                @RotateCannon.performed -= m_Wrapper.m_TankInputActionsCallbackInterface.OnRotateCannon;
                @RotateCannon.canceled -= m_Wrapper.m_TankInputActionsCallbackInterface.OnRotateCannon;
                @Attack.started -= m_Wrapper.m_TankInputActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_TankInputActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_TankInputActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_TankInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @RotateCannon.started += instance.OnRotateCannon;
                @RotateCannon.performed += instance.OnRotateCannon;
                @RotateCannon.canceled += instance.OnRotateCannon;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public TankInputActions @TankInput => new TankInputActions(this);
    private int m_Keyboard_MouseSchemeIndex = -1;
    public InputControlScheme Keyboard_MouseScheme
    {
        get
        {
            if (m_Keyboard_MouseSchemeIndex == -1) m_Keyboard_MouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard_Mouse");
            return asset.controlSchemes[m_Keyboard_MouseSchemeIndex];
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
    public interface ITankInputActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnRotateCannon(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
}
