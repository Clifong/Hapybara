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
    public CrossObjectEventWithData checkIfEquipped;
    public CrossObjectEventWithData checkIfNotEnough;
    private bool equipped = false;

    public void CheckIfEquipped(Component component, object obj) {
        object[] temp = (object[]) obj;
        weaponSO = (WeaponSO) temp[0];
        checkIfEquipped.TriggerEvent(this);
    }

    public void IsEquipped() {
        button.image.sprite = unequipWeaponImage;
        text.text = "Unequip";
        equipped = true;
    }

    public void IsNotEquipped() {
        button.image.sprite = equipWeaponImage;
        text.text = "Equip";
        equipped = false;
    }

    public void EnoughQuantity() {
        button.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
    }

    public void ExceedQuantity() {
        button.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    public void EquipOrUnequipWeapon() {
        if (equipped) {
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
