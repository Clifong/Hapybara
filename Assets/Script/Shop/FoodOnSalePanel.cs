using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodOnSalePanel : ShopPanel
{
    private FoodSO foodSO;
    private int qty;
    private int cost;

    public void SetFoodSO(FoodSO foodSO, int qty, int cost) {
        this.foodSO = foodSO;
        this.qty = qty;
        this.cost = cost;
        this.foodSO.SetUIInfo(icon, name);
    }

    public void BroadcastSO() {
        broadcastSO.TriggerEvent(this, foodSO, qty, cost);
    }
}
