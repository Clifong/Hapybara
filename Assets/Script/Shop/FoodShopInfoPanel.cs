using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodShopInfoPanel : ShopInfoPanel
{
    private FoodSO foodSO;
    public TextMeshProUGUI currentHealthRecover;

    public override void PopulateUI(Component component, object obj) {
        object[] temp = (object[]) obj;
        this.foodSO = (FoodSO) temp[0];
        int qty = (int) temp[1];
        int cost = (int) temp[2];
        foodSO.SetUIInfoWithoutFrame(icon, name);
        description.text = foodSO.foodDescription;
        costText.text = cost.ToString();
        qtyText.text = qty.ToString();

        foodSO.FillUpDefaultInfo(currentHealthRecover, maxHealthChange, attackChange, defenceChange, speedChange, effectsDescription);
    }
}
