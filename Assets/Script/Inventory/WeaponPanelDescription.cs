using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponPanelDescription : InventoryDescriptionPanels
{
    private WeaponSO weaponSO;
    public GameObject equippedByWhoIcon;
    public Transform equippedByWhoContent;
    private List<GameObject> spawnedEquippedByWhoIcon = new List<GameObject>();

    public override void PopulateUI(Component component, object obj) {
        object[] temp = (object[]) obj;
        this.weaponSO = (WeaponSO) temp[0];
        int qty = (int) temp[1];
        weaponSO.SetUIInfo(icon, name);
        description.text = weaponSO.weaponDescription;
        quantityText.text = qty.ToString();

        weaponSO.FillUpDefaultInfo(maxHealthChange, attackChange, defenceChange, speedChange, effectsDescription);
        foreach (GameObject icon in spawnedEquippedByWhoIcon)
        {
            Destroy(icon);
        }
        spawnedEquippedByWhoIcon.Clear();
        foreach (PlayerSO owner in weaponSO.owner)
        {
            GameObject icon = Instantiate(equippedByWhoIcon, equippedByWhoContent);
            icon.GetComponent<EquippedByWhoIcon>().SetInfo(owner);
            spawnedEquippedByWhoIcon.Add(icon);
        }
    }
}
