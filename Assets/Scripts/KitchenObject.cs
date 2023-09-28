using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour {

    // [SerializeField] for the KitchenObjectSO type.
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    // Simply returns the KitchenObjectSO data to clear counter where the function is called.
    public KitchenObjectSO GetKitchenObjectSO() {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter clearCounter) {
        // If this instance of clearCounter is not null then it clears the kitchenObject.
        if (this.clearCounter != null) {
            this.clearCounter.ClearKitchenObject();
        }

        // Sets this instance of clearCounter to the clear counter that is passed into params.
        this.clearCounter = clearCounter;

        // Checks if the kitchen counter already has a kitchen object. If it does it throws an error.
        if(clearCounter.HasKitchenObject()) {
            Debug.LogError("Counter already has a kitchen object.");
        }

        // Sets the clearCounters kitchenObject to this instance.
        clearCounter.SetKitchenObject(this);

        // Sets the parent of this kitchenObject to the other clearCounter.
        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        // Sets the local position in transform to Vector3.0
        transform.localPosition = Vector3.zero;
    }

    // Returns this instance of clearCounter.
    public ClearCounter GetClearCounter() {
        return clearCounter;
    }

}
