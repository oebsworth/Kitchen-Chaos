using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour {

    // [SerializeField] for the KitchenObjectSO type.
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    // Simply returns the KitchenObjectSO data to clear counter where the function is called.
    public KitchenObjectSO GetKitchenObjectSO() {
        return kitchenObjectSO;
    }

}
