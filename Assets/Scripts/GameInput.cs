using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour 
{
    public event EventHandler OnInteractAction;

    private PlayerInputActions playerInputActions;

    private void Awake() 
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed; // Listen to Interact Input
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty); // Fire event
    }

    public Vector2 GetMovementVectorNormalized() 
    {

        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>(); // Get input

        inputVector = inputVector.normalized; // Not move faster diagonally

        return inputVector;
    }
}
