using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackWhichPlayerItIs : MonoBehaviour
{
    private PlayerSO selectedPlayer;
    private WeaponSO weaponSO;
    public CrossObjectEventWithData checkIfExceed;

    public void SetPlayerSO(Component component, object obj) {
        object[] temp = (object[]) obj;
        selectedPlayer = (PlayerSO) temp[0];
    }

    public void SetWeaponLookingAt(Component component, object obj) {
        object[] temp = (object[]) obj;
        weaponSO = (WeaponSO) temp[0];
    }

    public void CheckIfEquipped(Component component, object obj) {
        EquipButton equipButton = (EquipButton) component;
        if (weaponSO.owner.Contains(selectedPlayer)) {
            equipButton.IsEquipped();
        } else {
            equipButton.IsNotEquipped();
        }
    }

    public void CheckIfExceed(Component component, object obj) {
        EquipButton equipButton = (EquipButton) component;
        if (!weaponSO.owner.Contains(selectedPlayer)) {
            checkIfExceed.TriggerEvent(this, weaponSO, equipButton);
        }
    }

    public void EquipWeapon() {
        selectedPlayer.EquipWeapon(weaponSO);
    }

    public void UnequipWeapon() {
        selectedPlayer.UnequipWeapon();
    }
}
