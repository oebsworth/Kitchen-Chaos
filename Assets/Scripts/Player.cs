using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // [SerializeField] means it can be edited in the editor. Without having to declare the variable as public.
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private float playerRadius = 0.7f;
    [SerializeField] private float playerHeight = 2f;
    // Link to the GameInput class.
    [SerializeField] public GameInput gameInput;
    // Private variable of the type boolean called isWalking.
    private bool isWalking;

    private void Update() {

        // Recieves a normalized movement vector from the GameInput class.
        Vector2 inputVector = gameInput.GetMovementVector();

        // New Vector3 that uses the inputVector to move on the x and z planes.
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        // Creates a boolean for the player collision if they are hitting an object or not.
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove) {
            // Attempt only X movement.
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove) {
                // Can move only on the X axis.
                moveDir = moveDirX;
            } else {
                // Cannot move on the X.

                // Attempt only Z movement.
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove) {
                    // Can move only on the Z axis.
                    moveDir = moveDirZ;
                } // else can't move in any direction.
            }
        }

        // Only moves the player if they aren't colliding with an object in front of them.
        if (canMove) {
            // Transform.position is the position of the gameobject that has the script attached. * by Time.deltaTime to make the movement fps independent.
            transform.position += moveDir * moveDistance;
        }


        // Sets the isWalking variable to true or false depending on whether or not the player is walking.
        isWalking = moveDir != Vector3.zero;
        // Rotates the player so that they are facing forward. Also spherically interpolates between tranform.forward and moveDir using Time.deltaTime.
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * turnSpeed);

    }

    // Function that returns the isWalking variable to where it was called from.
    public bool IsWalking() {
        return isWalking;
    }

}
