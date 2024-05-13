using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : InteractableNPC
{
    public ShopkeeperSO shopkeeperSO; 
    public CrossObjectEventWithData showAllItemsOnSale;
    public override void Interact() {
        showAllItemsOnSale.TriggerEvent(this, shopkeeperSO);
    }
}
