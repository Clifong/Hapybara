using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipButton : MonoBehaviour
{
    public Button button;
    public Sprite equipWeaponImage;
    public Sprite unequipWeaponImage;
    public TextMeshProUGUI text;
    private WeaponSO weaponSO;
    public CrossObjectEvent equipWeapon;
    public CrossObjectEvent unequipWeapon;

    public void CheckIfEquipped(Component component, object obj) {
        object[] temp = (object[]) obj;
        weaponSO = (WeaponSO) temp[0];
        if (weaponSO.equipped) {
            button.image.sprite = unequipWeaponImage;
            text.text = "Unequip";
        } else {
            button.image.sprite = equipWeaponImage;
            text.text = "Equip";
        }
    }

    public void EquipOrUnequipWeapon() {
        if (weaponSO.equipped) {
            unequipWeapon.TriggerEvent();
            button.image.sprite = equipWeaponImage;
            text.text = "Equip";
        }
        else {
            equipWeapon.TriggerEvent();
            button.image.sprite = unequipWeaponImage;
            text.text = "Unequip";
        }
    }
    
}
