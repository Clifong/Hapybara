using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon : InventoryIcon
{
    private WeaponSO weaponSO;

    public void PopulateUI() {
        broadcastInventorySO.TriggerEvent(this, weaponSO);
    }

    public void SetInfo(WeaponSO weaponSO) {
        this.weaponSO = weaponSO;
        icon.sprite = weaponSO.weaponIconWithFrame;
    }
}
