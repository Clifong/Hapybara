using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon : InventoryIcon
{
    private WeaponSO weaponSO;
    private int quantity;

    public void PopulateUI() {
        broadcastInventorySO.TriggerEvent(this, weaponSO, quantity);
    }

    public void SetInfo(WeaponSO weaponSO, int quantity) {
        this.weaponSO = weaponSO;
        icon.sprite = weaponSO.weaponIconWithFrame;
        this.quantity = quantity;
    }
}
