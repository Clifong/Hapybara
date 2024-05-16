using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon : InventoryIcon
{
    private WeaponSO weaponSO;
    private int quantity;
    public Image playerEquippedIcon;

    public void PopulateUI() {
        broadcastInventorySO.TriggerEvent(this, weaponSO, quantity);
    }

    public void SetInfo(WeaponSO weaponSO, int quantity) {
        this.weaponSO = weaponSO;
        icon.sprite = weaponSO.weaponIconWithFrame;
        this.quantity = quantity;
        if (weaponSO.owner == null) {
            playerEquippedIcon.gameObject.SetActive(false);
        } else {
            playerEquippedIcon.gameObject.SetActive(true);
            playerEquippedIcon.sprite = weaponSO.owner.playerIcon;
        }
    }

    public void ResetUIInfo() {
        SetInfo(weaponSO, quantity);
    }
}
