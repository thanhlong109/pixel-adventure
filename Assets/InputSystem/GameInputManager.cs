using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputManager : MonoBehaviour
{
    public static GameInputManager Instance;
    private GameControls inputActions;
    public float MoveDirection; // 1 0 -1
    public bool JumpPressed = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
            return;
        }
        inputActions = new GameControls();
    }

    private void OnEnable()
    {
        inputActions.Player.Move.performed += StartMove;
        inputActions.Player.Move.canceled += StopMove;

        inputActions.Player.Jump.performed += StartJump;
        inputActions.Player.Jump.canceled += StopJump;

        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= StartMove;
        inputActions.Player.Move.canceled -= StopMove;

        inputActions.Player.Jump.performed -= StartJump;
        inputActions.Player.Jump.canceled -= StopJump;

        inputActions.Player.Disable();
    }

    private void StartMove(InputAction.CallbackContext ctx)
    {
        MoveDirection = ctx.ReadValue<float>();
    }

    private void StopMove(InputAction.CallbackContext ctx) 
    {
        MoveDirection = 0;
    }

    private void StartJump(InputAction.CallbackContext ctx)
    {
        JumpPressed = true;
    }

    private void StopJump(InputAction.CallbackContext ctx)
    {
        JumpPressed = false;
    }

   
}
