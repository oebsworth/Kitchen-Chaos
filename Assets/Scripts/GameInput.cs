using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour {

    // Connects to the PlayerInputActions class.
    private PlayerInputActions playerInputActions;

    // First function to run in unity.
    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVector() {

        // Vector2 called inputVector, recieves inputs from the new input system.
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        Debug.Log(inputVector);

        // Returns the inputVector to the Player class.
        return inputVector;
    }

}
