using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            // Player is not carrying anything

            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player); // Spawn new KitchenObject and set parent to player

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}
