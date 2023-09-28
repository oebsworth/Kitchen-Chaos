using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour {

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    // Interact method gets sent from the player to say it has interacted with a counter.
    public void Interact() {
        Debug.Log("Interact");
        // Instantiates a new kitchenObject using the KitchenObjectSO, spawns it at the counterTopPoint transform (top of the counter).
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
        // Sets the transform of the kitchen object to 0 on all axis.
        kitchenObjectTransform.localPosition = Vector3.zero;

        // Debugs what kitchenObjectSO objectName you are interacting with.
        Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectSO().objectName);
    }
}
