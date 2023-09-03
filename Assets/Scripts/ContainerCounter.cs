using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;
    
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    public override void Interact(Player player) {
        var kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
        /* The Kitchen Object handles
           its own transform and the kitchenObject of the ClearCounter to which it belongs. */
        kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        
        OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
    }
}