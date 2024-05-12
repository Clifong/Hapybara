using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponPanelDescription : InventoryDescriptionPanels
{
    private WeaponSO weaponSO;

    public override void PopulateUI(Component component, object obj) {
        object[] temp = (object[]) obj;
        this.weaponSO = (WeaponSO) temp[0];
        int qty = (int) temp[1];
        icon.sprite = weaponSO.weaponIconWithoutFrame;
        name.text = weaponSO.weaponName;
        description.text = weaponSO.weaponDescription;

        maxHealthChange.text = weaponSO.maxHealthChange.ToString();
        attackChange.text = weaponSO.attackChange.ToString();
        defenceChange.text = weaponSO.defenceChange.ToString();
        speedChange.text = weaponSO.speedChange.ToString();
        effectsDescription.text = weaponSO.effectsDescription;
        quantityText.text = qty.ToString();
    }
}
