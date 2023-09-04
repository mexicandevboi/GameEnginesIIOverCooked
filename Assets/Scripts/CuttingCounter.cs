using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSoArray;

    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            // There is no KitchenObject here
            if (player.HasKitchenObject()) {
                // Player is carrying something
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())) {
                    // Player is carrying something that can be cut
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
            } else {
                // Player is not carrying anything
            }
        } else {
            // There is a KitchenObject here
            if (player.HasKitchenObject()) {
                // Player is carrying something
            } else {
                // Player is not carrying something
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player) {
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO())) {
            // There is a KitchenObject here AND it can be cut
            var outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
            
            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO) {
        return GetOutputForInput(inputKitchenObjectSO) != null;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO) {
        foreach (var cuttingRecipeSo in cuttingRecipeSoArray) {
            if (cuttingRecipeSo.input == inputKitchenObjectSO) {
                return cuttingRecipeSo.output;
            }
        }

        return null;
    }
}