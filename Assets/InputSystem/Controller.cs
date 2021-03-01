// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/Controller.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controller : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""79ddc0ec-2315-41a4-9d2a-743e83ce1f08"",
            ""actions"": [
                {
                    ""name"": ""TouchStart"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b908890f-8bd2-4977-bafb-4c277fd8bc9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TouchEnd"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5f5fd711-6446-49db-ba98-3e466b539de2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""TouchMove"",
                    ""type"": ""PassThrough"",
                    ""id"": ""94cf1a93-dd07-4630-9c0e-3f51b4b5c54c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""ScaleVector2"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7c6b15cb-e1c0-4a98-b30c-68431828feb4"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ab9ca53-b180-422d-b593-e6c40fc2e342"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bbe73b55-ebd8-4112-bb7f-2053992bcaee"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19d12fb9-9b70-4a98-9cf3-eb48cf1cb5a8"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchEnd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9793fe2-76e3-4bb0-80c0-860c3f61673c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchEnd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d45a9a78-c75c-48e2-bf72-45a6875d8a8c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchEnd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2554f88c-2ffa-4c36-9b30-f8e3448e303e"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32a5f2dd-f9d3-4571-9b5b-50279c7225ca"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""bb15675f-098c-4eee-ad25-a5bd64decf6c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""00ec811c-6324-4acb-9525-9f5b85a0725a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0c20d080-ae63-4371-9d0c-d996b949fe68"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e4cd63e9-2db0-40ec-9861-1bbde3347849"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c6ec7f52-8114-43e2-8596-0e2c665c81ff"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_TouchStart = m_Player.FindAction("TouchStart", throwIfNotFound: true);
        m_Player_TouchEnd = m_Player.FindAction("TouchEnd", throwIfNotFound: true);
        m_Player_TouchMove = m_Player.FindAction("TouchMove", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_TouchStart;
    private readonly InputAction m_Player_TouchEnd;
    private readonly InputAction m_Player_TouchMove;
    public struct PlayerActions
    {
        private @Controller m_Wrapper;
        public PlayerActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchStart => m_Wrapper.m_Player_TouchStart;
        public InputAction @TouchEnd => m_Wrapper.m_Player_TouchEnd;
        public InputAction @TouchMove => m_Wrapper.m_Player_TouchMove;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @TouchStart.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchStart;
                @TouchStart.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchStart;
                @TouchStart.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchStart;
                @TouchEnd.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchEnd;
                @TouchEnd.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchEnd;
                @TouchEnd.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchEnd;
                @TouchMove.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchMove;
                @TouchMove.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchMove;
                @TouchMove.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchMove;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchStart.started += instance.OnTouchStart;
                @TouchStart.performed += instance.OnTouchStart;
                @TouchStart.canceled += instance.OnTouchStart;
                @TouchEnd.started += instance.OnTouchEnd;
                @TouchEnd.performed += instance.OnTouchEnd;
                @TouchEnd.canceled += instance.OnTouchEnd;
                @TouchMove.started += instance.OnTouchMove;
                @TouchMove.performed += instance.OnTouchMove;
                @TouchMove.canceled += instance.OnTouchMove;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnTouchStart(InputAction.CallbackContext context);
        void OnTouchEnd(InputAction.CallbackContext context);
        void OnTouchMove(InputAction.CallbackContext context);
    }
}
