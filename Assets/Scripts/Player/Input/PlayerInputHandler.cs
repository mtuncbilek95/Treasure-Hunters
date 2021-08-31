using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    #region Button Variables
    private float buttonHoldTime = 0.4f;
    private float startTime;
    #endregion

    #region Movement Variables
    public Vector2 MovementRawInput { get; private set; }
    public int NormXInput { get; private set; }
    public int NormYInput { get; private set; }
    #endregion

    #region Jump Variables
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    #endregion

    #region Attack Variables
    public bool AttackInput { get; private set; }
    public bool AttackInputStop { get; private set; }
    #endregion

    #region Interact Variables
    public bool InteractInput { get; private set; }
    public bool InteractInputStop { get; private set; }
#endregion

    #region Throw Variables
    public bool ThrowInput { get; private set; }
    public bool ThrowInputStop { get; private set; }
    #endregion

    #region Unity Callback Functions
    private void Update()
    {
        ButtonTimer();
    }
    #endregion

    #region Input Action Callback Functions
    public void OnMovementInput(InputAction.CallbackContext context)
    {
        MovementRawInput = context.ReadValue<Vector2>();
        NormXInput = Mathf.RoundToInt(MovementRawInput.normalized.x);
        NormYInput = Mathf.RoundToInt(MovementRawInput.normalized.y);
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            startTime = Time.time;
            JumpInputStop = false;

        }
        else if (context.canceled)
        {
            JumpInputStop = true;
        }
    }
    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInput = true;
            AttackInputStop = false;

        }
        else if (context.canceled)
        {
            AttackInputStop = true;
        }
    }
    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InteractInput = true;
            InteractInputStop = false;
        }
        else if (context.canceled)
        {
            InteractInputStop = true;
        }
    }
    public void OnThrowInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ThrowInput = true;
            ThrowInputStop = false;
        }
        else if (context.canceled)
        {
            ThrowInputStop = true;
        }
    }
    #endregion

    #region Extra Functions
    public void UseJumpInput() => JumpInput = false;
    public void UseAttackInput() => AttackInput = false;
    public void UseInteractInput() => InteractInput = false;
    public void UseThrowInput() => ThrowInput = false;
    private void ButtonTimer()
    {
        if (JumpInput && Time.time >= startTime + buttonHoldTime)
        {
            JumpInput = false;
        }
        else if (AttackInput && Time.time >= startTime + buttonHoldTime)
        {
            AttackInput = false;
        }
        else if (InteractInput && Time.time >= startTime + buttonHoldTime)
        {
            InteractInput = false;
        }
        else if (ThrowInput && Time.time >= startTime + buttonHoldTime)
        {
            ThrowInput = false;
        }
    }
    #endregion
}
