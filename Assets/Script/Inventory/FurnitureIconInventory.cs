using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureIconInventory : InventoryIcon
{
    private BuildableSO furnitureSO;
    private int quantity;

    public void PopulateUI() {
        broadcastInventorySO.TriggerEvent(this, furnitureSO, quantity);
    }

    public void SetInfo(BuildableSO furnitureSO, int quantity) {
        this.furnitureSO = furnitureSO;
        icon.sprite = furnitureSO.previewSprite;
        this.quantity = quantity;
    }
}
