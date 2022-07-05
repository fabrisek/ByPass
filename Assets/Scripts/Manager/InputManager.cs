using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;
public enum ControlDeviceType
{
    KeyboardAndMouse,
    Gamepad,
}
public class InputManager : MonoBehaviour
{
    
    public static Input Input { private set; get; }
    public static InputManager Instance;

    [SerializeField] PlayerInput playerInput;
    public static ControlDeviceType currentControlDevice;

    public static float SensibilityMouseY;
    public static float SensibilityMouseX;   
    public static float SensibilityGamePadY;
    public static float SensibilityGamePadX;

    public static event Action rebindComplete;
    public static event Action rebindCanceled;
    public static event Action<InputAction, int> rebindStarted;

    [SerializeField] List<InputActionReference> allBinding;


    private void Awake()
    {
        Input = new Input();
        Instance = this;
        SensibilityMouseX = PlayerPrefs.GetFloat("SensibilityMouseX", 100f); 
        SensibilityMouseY = PlayerPrefs.GetFloat("SensibilityMouseY", 100f); 
        SensibilityGamePadX = PlayerPrefs.GetFloat("SensibilityGamePadX", 100f); 
        SensibilityGamePadY = PlayerPrefs.GetFloat("SensibilityGamePadY", 100f);



        /*
        if (LevelManager.Instance != null)
        {
            _input.InGame.RestartAndBack.performed += context => LevelManager.Instance.RestartLevel();
            _input.InGame.RestartAndBack.canceled -= context => LevelManager.Instance.RestartLevel();
        }

        if (HUD_MainMenu.Instance != null)
            _input.InGame.RestartAndBack.performed += context => HUD_MainMenu.Instance.Back();*/
    }

    public void OnEnable()
    {
        Input.Enable();
        for (int i = 0; i < allBinding.Count; i++)
        {
            string _actionName = allBinding[i].action.name;
            if (allBinding[i] != null)
            {
                LoadBindingOverride(_actionName);
            }
        }
        if (playerInput != null)
            playerInput.onControlsChanged += OnControlsChanged;

        if (PlayerController.Instance != null)
        {
            Input.InGame.SlowTime.performed += context => CompetenceRalentie.Instance.ActiveSlowTime(true);
            Input.InGame.SlowTime.canceled += context => CompetenceRalentie.Instance.ActiveSlowTime(false);
            Input.InGame.Pause.performed += context => GameManager.Instance.Pause();
            Input.InGame.Jump.started += context => PlayerController.Instance.GetPlayerJump();
            Input.InGame.Jump.canceled += context => PlayerController.Instance.PlayerJumpDown(true);
        }

        if (WallRunController.Instance != null)
            Input.InGame.Jump.started += context => WallRunController.Instance.WallJump();

        if (GrapplingGun.Instance != null)
        {
            Input.InGame.Grappling.performed += context => GrapplingGun.Instance.StartGrapple();
            Input.InGame.Grappling.canceled += context => GrapplingGun.Instance.StopGrapple();
        }

    }
    private void OnDisable()
    {

        if (PlayerController.Instance != null)
        {
            Input.InGame.SlowTime.performed -= context => CompetenceRalentie.Instance.ActiveSlowTime(true);
            Input.InGame.SlowTime.canceled -= context => CompetenceRalentie.Instance.ActiveSlowTime(false);
            Input.InGame.Pause.performed -= context => GameManager.Instance.Pause();
            Input.InGame.Jump.started -= context => PlayerController.Instance.GetPlayerJump();
            Input.InGame.Jump.canceled -= context => PlayerController.Instance.PlayerJumpDown(true);
        }

        if (WallRunController.Instance != null)
            Input.InGame.Jump.started -= context => WallRunController.Instance.WallJump();

        if (GrapplingGun.Instance != null)
        {
            Input.InGame.Grappling.performed -= context => GrapplingGun.Instance.StartGrapple();
            Input.InGame.Grappling.canceled -= context => GrapplingGun.Instance.StopGrapple();
        }

        Input.Disable();


    }

        public Vector2 GetPlayerMovement()
    {
        return Input.InGame.Move.ReadValue<Vector2>();
    }

    public Vector2 GetPlayerLook()
    {
        return Input.InGame.Look.ReadValue<Vector2>();
    }

    private void OnControlsChanged(UnityEngine.InputSystem.PlayerInput obj)
    {
        if (obj.currentControlScheme == "Gamepad")
        {
            if (currentControlDevice != ControlDeviceType.Gamepad)
            {
                //Data_Manager.LastDevice = ControlDeviceType.Gamepad;
                // Send Event
                // EventHandler.ExecuteEvent("DeviceChanged", currentControlDevice);
                //PlayerCam.Instance.IsGamePad = true;
                Cursor.visible = false;
            }
        }
        else
        {
            if (currentControlDevice != ControlDeviceType.KeyboardAndMouse)
            {
                //Data_Manager.LastDevice = ControlDeviceType.KeyboardAndMouse;
                //PlayerCam.Instance.IsGamePad = false;

                if (Time.timeScale == 0)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                }
                // Send Event
                // EventHandler.ExecuteEvent("DeviceChanged", currentControlDevice);
            }
        }
    }


    public void SetSensibilityGamePad(float y)
    {
        PlayerPrefs.SetFloat("SensibilityGamePadY", y);
        SensibilityGamePadY = y;
        PlayerPrefs.SetFloat("SensibilityGamePadX", y);
        SensibilityGamePadX = y;
    }

    public void SetSensibilityMouse(float y)
    {
        PlayerPrefs.SetFloat("SensibilityMouseY", y);
        SensibilityMouseY = y;
        PlayerPrefs.SetFloat("SensibilityMouseX", y);
        SensibilityMouseX = y;
    }

    public static void StartRebind(string actionName, int bindingIndex, TextMeshProUGUI statusText, bool excludeMouse)
    {
        InputAction action = Input.asset.FindAction(actionName);
        if (action == null || action.bindings.Count <= bindingIndex)
        {
            Debug.Log("Couln't find action or binding");
            return;
        }

        if (action.bindings[bindingIndex].isComposite)
        {
            var firstPartIndex = bindingIndex + 1;
            if (firstPartIndex < action.bindings.Count && action.bindings[firstPartIndex].isComposite)
            {
                DoRebind(action, bindingIndex, statusText, true,excludeMouse);
            }
        }

        else
            DoRebind(action, bindingIndex, statusText, false,excludeMouse);
    }

    private static void DoRebind(InputAction actionToRebind, int bindingIndex, TextMeshProUGUI statusText, bool allCompositeParts, bool excludeMouse)
    {
        Debug.Log("Binging");
        if (actionToRebind == null || bindingIndex < 0)
            return;

        statusText.text = $"Press a {actionToRebind.expectedControlType}";
        actionToRebind.Disable();
        var rebind = actionToRebind.PerformInteractiveRebinding(bindingIndex);
        rebind.OnComplete(operation =>
        {
            actionToRebind.Enable();
            operation.Dispose();

            if (allCompositeParts)
            {
                var nextBindingIndex = bindingIndex + 1;
                if (nextBindingIndex < actionToRebind.bindings.Count && actionToRebind.bindings[nextBindingIndex].isComposite)
                    DoRebind(actionToRebind, nextBindingIndex, statusText, allCompositeParts, excludeMouse);
            }
            SaveBindingOverride(actionToRebind);
            rebindComplete?.Invoke();
        });

        rebind.OnCancel(operation =>
        {
            actionToRebind.Enable();
            operation.Dispose();

            rebindCanceled?.Invoke();
        });

        rebind.WithCancelingThrough("<Keyboard>/escape");

        if (excludeMouse)
            rebind.WithControlsExcluding("Mouse");

        rebindStarted?.Invoke(actionToRebind, bindingIndex);
        rebind.Start();
    }


    public static string GetBindingName( string actionName, int bindingIndex)
    {
        if (Input == null)
        {
            Input = new Input();
        }

        InputAction action = Input.asset.FindAction(actionName);
        return action.GetBindingDisplayString(bindingIndex);
    }

    private static void SaveBindingOverride(InputAction action)
    {
        for (int i = 0; i < action.bindings.Count; i++)
        {
            PlayerPrefs.SetString(action.actionMap + action.name + i, action.bindings[i].overridePath);
        }
    }

    public static void LoadBindingOverride(string actionName)
    {
        if (Input == null)
            Input = new Input();

        InputAction action = Input.asset.FindAction(actionName);

        for (int i = 0; i < action.bindings.Count; i++)
        {
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString(action.actionMap + action.name + i, action.bindings[i].overridePath)))
            {
                action.ApplyBindingOverride(i, PlayerPrefs.GetString(action.actionMap + action.name + i, action.bindings[i].overridePath));
            }
        }
    }

    public static void ResetBinding(string actionName, int bindingIndex)
    {
        InputAction action = Input.asset.FindAction(actionName);

        if (action == null || action.bindings.Count <= bindingIndex)
        {
            print("Coulnd not find action or binding");
            return;
        }

        if (action.bindings[bindingIndex].isComposite)
        {
            for (int i = bindingIndex; i < action.bindings.Count && action.bindings[i].isComposite; i++)
            {
                action.RemoveBindingOverride(i);
            }
        }

        else
            action.RemoveBindingOverride(bindingIndex);



        SaveBindingOverride(action);
    }
}
