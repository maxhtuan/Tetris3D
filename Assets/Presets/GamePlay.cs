// GENERATED AUTOMATICALLY FROM 'Assets/Presets/GamePlay.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GamePlay : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GamePlay()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GamePlay"",
    ""maps"": [
        {
            ""name"": ""Base"",
            ""id"": ""83fdc19a-7dc5-4831-b04f-a2ef363c31b5"",
            ""actions"": [
                {
                    ""name"": ""TurnBaseRight"",
                    ""type"": ""Button"",
                    ""id"": ""29445379-4be2-4713-a462-b4b0a6f36ff5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TurnBaseLeft"",
                    ""type"": ""Button"",
                    ""id"": ""fdb2a2a3-e97a-441b-aedd-da4e0fd88c62"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7470fcb9-5e31-4baf-bde3-fa1dcf5ed563"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnBaseRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ef5d9a2-62a0-4bb8-84e3-24852eb3e41e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnBaseLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player"",
            ""id"": ""9677a9d0-87ca-4a58-b689-e7b881fc42ea"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""e699d18b-28f6-4280-8ec3-95df9a2e49e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e427a887-ad83-4806-8fb9-420a90648fab"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Base
        m_Base = asset.FindActionMap("Base", throwIfNotFound: true);
        m_Base_TurnBaseRight = m_Base.FindAction("TurnBaseRight", throwIfNotFound: true);
        m_Base_TurnBaseLeft = m_Base.FindAction("TurnBaseLeft", throwIfNotFound: true);
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Forward = m_Player.FindAction("Forward", throwIfNotFound: true);
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

    // Base
    private readonly InputActionMap m_Base;
    private IBaseActions m_BaseActionsCallbackInterface;
    private readonly InputAction m_Base_TurnBaseRight;
    private readonly InputAction m_Base_TurnBaseLeft;
    public struct BaseActions
    {
        private @GamePlay m_Wrapper;
        public BaseActions(@GamePlay wrapper) { m_Wrapper = wrapper; }
        public InputAction @TurnBaseRight => m_Wrapper.m_Base_TurnBaseRight;
        public InputAction @TurnBaseLeft => m_Wrapper.m_Base_TurnBaseLeft;
        public InputActionMap Get() { return m_Wrapper.m_Base; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BaseActions set) { return set.Get(); }
        public void SetCallbacks(IBaseActions instance)
        {
            if (m_Wrapper.m_BaseActionsCallbackInterface != null)
            {
                @TurnBaseRight.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnTurnBaseRight;
                @TurnBaseRight.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnTurnBaseRight;
                @TurnBaseRight.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnTurnBaseRight;
                @TurnBaseLeft.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnTurnBaseLeft;
                @TurnBaseLeft.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnTurnBaseLeft;
                @TurnBaseLeft.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnTurnBaseLeft;
            }
            m_Wrapper.m_BaseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TurnBaseRight.started += instance.OnTurnBaseRight;
                @TurnBaseRight.performed += instance.OnTurnBaseRight;
                @TurnBaseRight.canceled += instance.OnTurnBaseRight;
                @TurnBaseLeft.started += instance.OnTurnBaseLeft;
                @TurnBaseLeft.performed += instance.OnTurnBaseLeft;
                @TurnBaseLeft.canceled += instance.OnTurnBaseLeft;
            }
        }
    }
    public BaseActions @Base => new BaseActions(this);

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Forward;
    public struct PlayerActions
    {
        private @GamePlay m_Wrapper;
        public PlayerActions(@GamePlay wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Player_Forward;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IBaseActions
    {
        void OnTurnBaseRight(InputAction.CallbackContext context);
        void OnTurnBaseLeft(InputAction.CallbackContext context);
    }
    public interface IPlayerActions
    {
        void OnForward(InputAction.CallbackContext context);
    }
}
