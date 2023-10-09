using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;
    private List<KitchenObjectSO> kitchenObjectSOList;
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            if (!kitchenObjectSOList.Contains(kitchenObjectSO))
            {
                kitchenObjectSOList.Add(kitchenObjectSO);

                OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs
                {
                    kitchenObjectSO = kitchenObjectSO,
                });
                return true;
            }
        }         
        return false;
    }
}
