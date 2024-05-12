using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodIconInventory : InventoryIcon
{
    private FoodSO foodSO;
    private int quantity;
    public void PopulateUI() {
        broadcastInventorySO.TriggerEvent(this, foodSO, quantity);
    }

    public void SetInfo(FoodSO foodSO, int quantity) {
        this.foodSO = foodSO;
        icon.sprite = foodSO.foodIconWithFrame;
        this.quantity = quantity;
    }
}
