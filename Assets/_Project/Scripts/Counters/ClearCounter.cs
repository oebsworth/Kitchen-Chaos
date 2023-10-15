using System.Runtime.CompilerServices;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    // Public class called ClearCounter that inherits from BaseCounter.
    public override void Interact(Player player)
    {
        // Override of the Interact function that derives from the BaseCounter class. 
        if (this.HasKitchenObject())
        {
            // ClearCounter has a KitchenObject.
            if (player.HasKitchenObject())
            {
                // Player is holding a KitchenObject.
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    // Player is holding a PlateKitchenObject.
                    if (plateKitchenObject.TryAddIngredient(this.GetKitchenObject().GetKitchenObjectSO()))
                    {
                        // The ingredient on the ClearCounter is suitable to be added to the PlateKitchenObject that the Player is holding.
                        this.GetKitchenObject().DestroySelf(); // Gets the KitchenObject on the ClearCounter and deletes it.
                    }
                }
                else
                {
                    // Player is not holding a PlateKitchenObject.
                    if (this.GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        // ClearCounter is has a PlateKitchenObject.
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            // The ingredient on the Player is suitable to be added to the PlateKitchenObject that the ClearCounter has.
                            player.GetKitchenObject().DestroySelf(); // Gets the KitchenObject on the ClearCounter and deletes it.
                        }
                    }
                }
            }
            else
            {
                // Player is not holding a KitchenObject.
                this.GetKitchenObject().SetKitchenObjectParent(player); // Gets the KitchenObject on the ClearCounter and moves it to the Player.
            }
        }
        else
        {
            // ClearCounter does not have a KitchenObject.
            if (player.HasKitchenObject())
            {
                // Player is holding a KitchenObject.
                player.GetKitchenObject().SetKitchenObjectParent(this); // Gets the KitchenObject on the Player and moves it to the ClearCounter.
            }
        }
    }
}