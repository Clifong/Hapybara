using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopInfoPanel : ShopInfoPanel
{
    private WeaponSO weaponSO;

    public override void PopulateUI(Component component, object obj) {
        object[] temp = (object[]) obj;
        this.weaponSO = (WeaponSO) temp[0];
        int qty = (int) temp[1];
        int cost = (int) temp[2];
        weaponSO.SetUIInfoWithoutFrame(icon, name);
        description.text = weaponSO.weaponDescription;
        costText.text = cost.ToString();
        qtyText.text = qty.ToString();

        weaponSO.FillUpDefaultInfo(maxHealthChange, attackChange, defenceChange, speedChange, effectsDescription);
    }
}
