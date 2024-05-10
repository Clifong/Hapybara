using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodIconInventory : InventoryIcon
{
    private FoodSO foodSO;
    public void PopulateUI() {
        broadcastInventorySO.TriggerEvent(this, foodSO);
    }

    public void SetInfo(FoodSO foodSO) {
        this.foodSO = foodSO;
        icon.sprite = foodSO.foodIconWithFrame;
    }
}
