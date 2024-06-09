using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurniturePanelDescription : InventoryDescriptionPanels
{
    private BuildableSO furnitureSO;

    public override void PopulateUI(Component component, object obj) {
        object[] temp = (object[]) obj;
        this.furnitureSO = (BuildableSO) temp[0];
        int qty = (int) temp[1];
        furnitureSO.SetUIInfo(icon, name);
        description.text = furnitureSO.description;
        quantityText.text = qty.ToString();
    }
}
