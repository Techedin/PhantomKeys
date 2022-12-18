using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;   // Item to put in the inventory on pickup
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp()
    {

        Inventory.inventoryInstance.AddItem(item);

        if (Inventory.inventoryInstance.pickedUp == true)
        {
            Destroy(gameObject);
        }

    }
}
