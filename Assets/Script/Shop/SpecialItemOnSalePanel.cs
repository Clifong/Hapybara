using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItemOnSalePanel : ShopPanel
{
    private RecipeSO recipeSO;
    private int qty;
    private int cost;

    public void SetRecipeSO(RecipeSO recipeSO, int qty, int cost) {
        this.recipeSO = recipeSO;
        this.qty = qty;
        this.cost = cost;
        this.recipeSO.SetUIInfo(icon, name);
    }

    public void BroadcastSO() {
        broadcastSO.TriggerEvent(this, recipeSO, qty, cost);
    }
}