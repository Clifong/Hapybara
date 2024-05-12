using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

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

    [Header("Inventory stuff")]
    [SerializedDictionary("All weapons", "quantity")]
    public SerializedDictionary<WeaponSO, int> allWeapons;
   
    [SerializedDictionary("All food", "quantity")]
    public SerializedDictionary<FoodSO, int> allFood;

    [Header("UI stuff")]
    public Sprite playerIcon;
}
