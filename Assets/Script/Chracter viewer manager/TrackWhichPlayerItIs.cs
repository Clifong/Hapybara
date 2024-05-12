using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackWhichPlayerItIs : MonoBehaviour
{
    private PlayerSO selectedPlayer;
    private WeaponSO weaponSO;

    public void SetPlayerSO(Component component, object obj) {
        object[] temp = (object[]) obj;
        selectedPlayer = (PlayerSO) temp[0];
    }

    public void SetWeaponLookingAt(Component component, object obj) {
        object[] temp = (object[]) obj;
        weaponSO = (WeaponSO) temp[0];
    }

    public void EquipWeapon() {
        selectedPlayer.weaponEquipped = weaponSO;
    }
}
