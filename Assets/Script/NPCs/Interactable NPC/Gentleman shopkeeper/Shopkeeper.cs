using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : InteractableNPC
{
    public ShopkeeperSO shopkeeperSO; 
    private ShopManager shopManager;

    void Start() {
        shopManager = GetComponentInChildren<ShopManager>();
    }

    public override void Interact() {
        shopManager.DisplayAllWeaponOnSale(shopkeeperSO);
    }
}
