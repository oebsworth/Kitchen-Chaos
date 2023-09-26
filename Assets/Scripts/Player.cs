using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // [SerializeField] means it can be edited in the editor. Without having to declare the variable as public.
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float turnSpeed = 10f;
    // Link to the GameInput class.
    [SerializeField] public GameInput gameInput;
    // Private variable of the type boolean called isWalking.
    private bool isWalking;

    private void Update() {

        // Recieves a normalized movement vector from the GameInput class.
        Vector2 inputVector = gameInput.GetMovementVector();

        // New Vector3 that uses the inputVector to move on the x and z planes.
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        // Transform.position is the position of the gameobject that has the script attached. * by Time.deltaTime to make the movement fps independent.
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        // Sets the isWalking variable to true or false depending on whether or not the player is walking.
        isWalking = moveDir != Vector3.zero;
        // Rotates the player so that they are facing forward. Also spherically interpolates between tranform.forward and moveDir using Time.deltaTime.
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * turnSpeed);

    }

    public bool IsWalking() {
        return isWalking;
    }

}
