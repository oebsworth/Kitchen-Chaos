using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    // Private const with the type of string called "IS_WALKING" set to "IsWalking" which is an animator variable.
    private const string IS_WALKING = "IsWalking";
    // Link to the Player class.
    [SerializeField] private Player player;
    // Private Animator component to connect to the "Animator" component in the gameobject.
    private Animator animator;

    // First function that runs when the game starts.
    private void Awake() {
        // Gets the "Animator" component from the gameobject that the script is attached to.
        animator = GetComponent<Animator>();
    }

    void Update() {
        // Sets the animator variable IsWalking to true or false depending on whether or not the player is walking. player.IsWalking() recieves the isWalking variable from the Player class.
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
