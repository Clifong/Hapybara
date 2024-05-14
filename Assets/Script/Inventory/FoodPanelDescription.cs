using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodPanelDescription : InventoryDescriptionPanels
{
    private FoodSO foodSO;
    public TextMeshProUGUI currentHealthChange;

    public override void PopulateUI(Component component, object obj) {
        object[] temp = (object[]) obj;
        this.foodSO = (FoodSO) temp[0];
        int qty = (int) temp[1];
        foodSO.SetUIInfoWithoutFrame(icon, name);
        description.text = foodSO.foodDescription;

        foodSO.FillUpDefaultInfo(currentHealthChange, maxHealthChange, attackChange, defenceChange, speedChange, effectsDescription);
        quantityText.text = qty.ToString();
    }
}
