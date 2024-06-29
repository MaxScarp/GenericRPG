using System;
using UnityEngine;
using UnityEngine.InputSystem;

public static class PlayerInput
{
    public static event EventHandler<Vector3> OnClickPerformed;

    private static PlayerInputActions playerInputActions;
    private static PlayerInputActions.PlayerActions playerActions;

    static PlayerInput()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerActions = playerInputActions.Player;

        SubscribeToActions();
    }

    private static void SubscribeToActions()
    {
        playerActions.Click.performed += Player_click_performed;
    }

    private static void Player_click_performed(InputAction.CallbackContext obj)
    {
        OnClickPerformed?.Invoke(null, Mouse.current.position.ReadValue());
    }
}
