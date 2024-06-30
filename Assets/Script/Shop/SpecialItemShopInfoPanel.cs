using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItemShopInfoPanel : ShopInfoPanel
{
    private RecipeSO recipeSO;

    public override void PopulateUI(Component component, object obj) {
        object[] temp = (object[]) obj;
        this.recipeSO = (RecipeSO) temp[0];
        int qty = (int) temp[1];
        int cost = (int) temp[2];
        recipeSO.SetUIInfo(icon, name);
        description.text = recipeSO.description;
        costText.text = cost.ToString();
        qtyText.text = qty.ToString();
    }
}