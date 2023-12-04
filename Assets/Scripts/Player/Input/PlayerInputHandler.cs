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
    public bool InteractDoubleClick { get; private set; }
    public int InteractDoubleClickCount { get; private set; }
    public float interactDoubleClickThresholdTime = 0.2f;
    public float InteractDoubleClickTimer { get; private set; }


    private void Update()
    {
        CheckInteractDoubleClick();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;

    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InteractInput = true;
            InteractDoubleClickCount++;
        }

        if (context.canceled)
        {
            InteractInput = false;
        }
    }

    //Checks if the player has double clicked the interact button within a certain timeframe (interactDoubleClickThresholdTime)
    public void CheckInteractDoubleClick()
    {
        if(InteractDoubleClickCount == 1)
        {
            InteractDoubleClickTimer += Time.deltaTime;
        }

        if (InteractDoubleClickTimer <= interactDoubleClickThresholdTime && InteractDoubleClickCount == 2)
        {
            InteractDoubleClick = true;
        }
        else if (InteractDoubleClickTimer > interactDoubleClickThresholdTime || InteractDoubleClickCount == 2)
        {
            InteractDoubleClick = false;
        }

        if (InteractDoubleClickCount == 2 || InteractDoubleClickTimer > interactDoubleClickThresholdTime)
        {
            InteractDoubleClickCount = 0;
            InteractDoubleClickTimer = 0;
        }

    }

    //Sets the interactDoubleClick to false after use.
    public void SetInteractDoubleClickFalse()
    {
        InteractDoubleClick = false;
    }
}
