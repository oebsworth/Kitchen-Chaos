using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour {

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    // Bool to enable testing mode.
    [SerializeField] private bool testing;

    private KitchenObject kitchenObject;

    // Runs per frame.
    private void Update() {
        // Setup testing key using key T, moves the kitchenobject from clearCounter to secondClearCounter.
        if (testing & Input.GetKeyDown(KeyCode.T)) {
            if (kitchenObject != null) {
                kitchenObject.SetClearCounter(secondClearCounter);
            }
        }
    }

    // Interact method gets sent from the player to say it has interacted with a counter.
    public void Interact() {
        if (kitchenObject == null) {
            // Instantiates a new kitchenObject using the KitchenObjectSO, spawns it at the counterTopPoint transform (top of the counter).
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            // Sets the clearCounter on the KitchenObject to this instance.
            kitchenObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this);
        } else {
            Debug.Log(kitchenObject.GetClearCounter());
        }
        

    }

    // Returns the Transform of the counterTopPoint.
    public Transform GetKitchenObjectFollowTransform() {
        return counterTopPoint;
    }
    
    // Sets the kitchenObject attached to this instance to the kitchenObject that is passed in with params.
    public void SetKitchenObject(KitchenObject kitchenObject) {
        this.kitchenObject = kitchenObject;
    }

    // Return the KitchenObject in this instance.
    public KitchenObject GetKitchenObject() {
        return kitchenObject;
    }
    
    // Sets the kitchenObject in this instance to null.
    public void ClearKitchenObject() {
        kitchenObject = null;
    }

    // Returns if the kitchenObject exists on this clearCounter.
    public bool HasKitchenObject() {
        return kitchenObject != null;
    }

}
