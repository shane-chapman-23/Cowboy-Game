using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }

    public bool InteractInput { get; private set; }

    private void LateUpdate()
    {
        //Sets the input to false at the end of each frame so the player cant hold down the interact button to continuously speed up
        InteractInput = false;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;

    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            InteractInput = true;
        }
    }
}
