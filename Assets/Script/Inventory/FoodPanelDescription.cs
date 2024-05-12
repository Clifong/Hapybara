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
        icon.sprite = foodSO.foodIconWithoutFrame;
        name.text = foodSO.foodName;
        description.text = foodSO.foodDescription;

        currentHealthChange.text = foodSO.currentHealthChange.ToString();
        maxHealthChange.text = foodSO.maxHealthChange.ToString();
        attackChange.text = foodSO.attackChange.ToString();
        defenceChange.text = foodSO.defenceChange.ToString();
        speedChange.text = foodSO.speedChange.ToString();
        effectsDescription.text = foodSO.effectsDescription;
        quantityText.text = qty.ToString();
    }
}
