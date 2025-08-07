using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Vector2 MoveInput, LookInput;
    public bool GoUp, GoDown, GoFast, DoLook;
    public bool isMouse;
    
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        LookInput = context.ReadValue<Vector2>();
        var device = context.control.device;

        if (device is not Mouse)
        {
            DoLook = LookInput != Vector2.zero;
        }

        isMouse = device is Mouse;
    }


    public void OnUp(InputAction.CallbackContext context)
    {
        GoUp = context.phase == InputActionPhase.Performed;
    }

    public void OnDown(InputAction.CallbackContext context)
    {
        GoDown = context.phase == InputActionPhase.Performed;
    }

    public void OnFast(InputAction.CallbackContext context)
    {
        GoFast = context.phase == InputActionPhase.Performed;
    }

    public void OnDoLook(InputAction.CallbackContext context)
    {
        DoLook = context.phase == InputActionPhase.Performed;
    }

}