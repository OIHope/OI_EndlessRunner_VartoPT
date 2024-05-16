//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.8.1
//     from Assets/Scripts/C_Player/InputSystem.inputactions
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
using UnityEngine;

public partial class @InputSystem: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""7775f912-905e-41c8-9b27-eb39b6fcdaaf"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bb103ca8-13e0-4ecb-9911-2876ebc61c77"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slide"",
                    ""type"": ""Button"",
                    ""id"": ""9afc8e3b-28f9-466d-923f-f70b3da194a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""9df22159-f9b5-4372-b188-40ca932f7ab2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""f1d590fa-e43a-49b1-8f93-09195ed56278"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3e4184ce-dfb1-4a6f-abdf-de374995abb0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5a6f82c-ba0b-48a8-b30f-011ae3f4e28f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05804d82-b45e-4cd5-99a8-f061a7a95702"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f78fe7e8-624a-48f8-9032-4ea4ed3643f7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22fcb565-0da1-4d5a-a92a-5928a82a8725"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b9105f9-05fd-4157-950b-25b0e84cecb2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2f55033-bda6-44a5-ad50-bdd7452723d9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a91bde1c-d3ba-46fb-8d5d-8bcb787ec325"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""beb171e4-e9d9-43a4-89aa-74a1677518a9"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UIControl"",
            ""id"": ""c666a134-0f18-475d-b8d7-5007223fa038"",
            ""actions"": [
                {
                    ""name"": ""MenuEscape"",
                    ""type"": ""Button"",
                    ""id"": ""6406615f-00ec-44b6-951c-158cb3498be9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""792f825c-2e9f-4a6d-880d-f12e7c1dd7a9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c93e3d22-e064-4131-aa8d-e32967bc6784"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuEscape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d9c8ca9-80c2-488e-a0a6-0b7e4a411000"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Jump = m_PlayerMovement.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMovement_Slide = m_PlayerMovement.FindAction("Slide", throwIfNotFound: true);
        m_PlayerMovement_Left = m_PlayerMovement.FindAction("Left", throwIfNotFound: true);
        m_PlayerMovement_Right = m_PlayerMovement.FindAction("Right", throwIfNotFound: true);
        // UIControl
        m_UIControl = asset.FindActionMap("UIControl", throwIfNotFound: true);
        m_UIControl_MenuEscape = m_UIControl.FindAction("MenuEscape", throwIfNotFound: true);
        m_UIControl_Enter = m_UIControl.FindAction("Enter", throwIfNotFound: true);
    }

    ~@InputSystem()
    {
        Debug.Assert(!m_PlayerMovement.enabled, "This will cause a leak and performance issues, InputSystem.PlayerMovement.Disable() has not been called.");
        Debug.Assert(!m_UIControl.enabled, "This will cause a leak and performance issues, InputSystem.UIControl.Disable() has not been called.");
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

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private List<IPlayerMovementActions> m_PlayerMovementActionsCallbackInterfaces = new List<IPlayerMovementActions>();
    private readonly InputAction m_PlayerMovement_Jump;
    private readonly InputAction m_PlayerMovement_Slide;
    private readonly InputAction m_PlayerMovement_Left;
    private readonly InputAction m_PlayerMovement_Right;
    public struct PlayerMovementActions
    {
        private @InputSystem m_Wrapper;
        public PlayerMovementActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_PlayerMovement_Jump;
        public InputAction @Slide => m_Wrapper.m_PlayerMovement_Slide;
        public InputAction @Left => m_Wrapper.m_PlayerMovement_Left;
        public InputAction @Right => m_Wrapper.m_PlayerMovement_Right;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Add(instance);
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Slide.started += instance.OnSlide;
            @Slide.performed += instance.OnSlide;
            @Slide.canceled += instance.OnSlide;
            @Left.started += instance.OnLeft;
            @Left.performed += instance.OnLeft;
            @Left.canceled += instance.OnLeft;
            @Right.started += instance.OnRight;
            @Right.performed += instance.OnRight;
            @Right.canceled += instance.OnRight;
        }

        private void UnregisterCallbacks(IPlayerMovementActions instance)
        {
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Slide.started -= instance.OnSlide;
            @Slide.performed -= instance.OnSlide;
            @Slide.canceled -= instance.OnSlide;
            @Left.started -= instance.OnLeft;
            @Left.performed -= instance.OnLeft;
            @Left.canceled -= instance.OnLeft;
            @Right.started -= instance.OnRight;
            @Right.performed -= instance.OnRight;
            @Right.canceled -= instance.OnRight;
        }

        public void RemoveCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerMovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // UIControl
    private readonly InputActionMap m_UIControl;
    private List<IUIControlActions> m_UIControlActionsCallbackInterfaces = new List<IUIControlActions>();
    private readonly InputAction m_UIControl_MenuEscape;
    private readonly InputAction m_UIControl_Enter;
    public struct UIControlActions
    {
        private @InputSystem m_Wrapper;
        public UIControlActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @MenuEscape => m_Wrapper.m_UIControl_MenuEscape;
        public InputAction @Enter => m_Wrapper.m_UIControl_Enter;
        public InputActionMap Get() { return m_Wrapper.m_UIControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIControlActions set) { return set.Get(); }
        public void AddCallbacks(IUIControlActions instance)
        {
            if (instance == null || m_Wrapper.m_UIControlActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIControlActionsCallbackInterfaces.Add(instance);
            @MenuEscape.started += instance.OnMenuEscape;
            @MenuEscape.performed += instance.OnMenuEscape;
            @MenuEscape.canceled += instance.OnMenuEscape;
            @Enter.started += instance.OnEnter;
            @Enter.performed += instance.OnEnter;
            @Enter.canceled += instance.OnEnter;
        }

        private void UnregisterCallbacks(IUIControlActions instance)
        {
            @MenuEscape.started -= instance.OnMenuEscape;
            @MenuEscape.performed -= instance.OnMenuEscape;
            @MenuEscape.canceled -= instance.OnMenuEscape;
            @Enter.started -= instance.OnEnter;
            @Enter.performed -= instance.OnEnter;
            @Enter.canceled -= instance.OnEnter;
        }

        public void RemoveCallbacks(IUIControlActions instance)
        {
            if (m_Wrapper.m_UIControlActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIControlActions instance)
        {
            foreach (var item in m_Wrapper.m_UIControlActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIControlActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIControlActions @UIControl => new UIControlActions(this);
    public interface IPlayerMovementActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnSlide(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
    public interface IUIControlActions
    {
        void OnMenuEscape(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
    }
}