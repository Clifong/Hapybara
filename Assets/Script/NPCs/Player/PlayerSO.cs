using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player SO", menuName = "All player SO/PlayerSO", order = 1)]
public class PlayerSO : ScriptableObject
{
    public int level = 1;
    public int currentExp = 0;
    public int expNeededForNextLevel = 0;
    public int health;
    public int attack;
    public int defence;
    public int speed;
    public WeaponSO weaponEquipped;

    void Awake() {
        CalculateExpNeededForNextLevel();
    }

    private void CalculateExpNeededForNextLevel() {
        expNeededForNextLevel = (int)(level * 100 * 1.25);
    }

    public void LevelUp() {
        while (currentExp > expNeededForNextLevel) {
            currentExp = Mathf.Max(0, currentExp - expNeededForNextLevel);
            level += 1;
            CalculateExpNeededForNextLevel();
        }
    }

    public void EquipWeapon(WeaponSO weaponSO) {
        weaponEquipped = weaponSO;
        health += weaponEquipped.maxHealthChange;
        attack += weaponEquipped.attackChange;
        defence += weaponEquipped.defenceChange;
        speed += weaponEquipped.speedChange;
        weaponSO.equipped = true;
    }

    public void UnequipWeapon() {
        health -= weaponEquipped.maxHealthChange;
        attack -= weaponEquipped.attackChange;
        defence -= weaponEquipped.defenceChange;
        speed -= weaponEquipped.speedChange;
        weaponEquipped.equipped = false;
        weaponEquipped = null;
    }
    [Header("UI stuff")]
    public Sprite playerIcon;
    public Sprite playerAppearance;
}
