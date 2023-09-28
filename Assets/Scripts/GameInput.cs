using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameInput : MonoBehaviour {

    // Defined an event.
    public event EventHandler OnInteractAction;
    // Connects to the PlayerInputActions class.
    private PlayerInputActions playerInputActions;

    // First function to run in unity.
    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        // This adds a listener to the Interact key.
        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    // This function is called when the interact button is pressed.
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        // If this event doesn't have a listener then this will fire a null error.
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVector() {

        // Vector2 called inputVector, recieves inputs from the new input system.
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        // Returns the inputVector to the Player class.
        return inputVector;
    }

}
