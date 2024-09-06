using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName ="PlayerInput")]
public class PlayerInput : ScriptableObject, InputActions.IPlayerActions
{
    public InputActions inputActions;

    public UnityAction<Vector2> onWalk;
    public UnityAction disWalk;
    public UnityAction onJump;
    public UnityAction onAttack;
    public UnityAction disAttack;



    private void OnEnable()
    {
        inputActions = new InputActions();
        inputActions.Player.SetCallbacks(this);
    }

    public void turnOnPlayer()
    {
        inputActions.Player.Enable();
    }
    public void OnWalk(InputAction.CallbackContext context)
    {
        if (context.performed)
            onWalk?.Invoke(context.ReadValue<Vector2>());
        if (context.canceled)
            disWalk?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            onJump?.Invoke();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            onAttack?.Invoke();
        if (context.canceled)
            disAttack?.Invoke();

    }
}
