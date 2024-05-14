using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponOnSalePanel : ShopPanel
{
    private WeaponSO weaponSO;
    private int qty;
    private int cost;

    public void SetWeaponSO(WeaponSO weaponSO, int qty, int cost) {
        this.weaponSO = weaponSO;
        this.qty = qty;
        this.cost = cost;   
        weaponSO.SetUIInfoWithFrame(icon, name);
    }

    public void BroadcastSO() {
        broadcastSO.TriggerEvent(this, weaponSO, qty, cost);
    }
}
