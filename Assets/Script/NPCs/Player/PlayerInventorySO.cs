using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "Player Inventory SO", menuName = "All player SO/PlayerInventorySO", order = 1)]
public class PlayerInventorySO : ScriptableObject
{
    [Header("Inventory stuff")]
    [SerializedDictionary("All weapons", "quantity")]
    public SerializedDictionary<WeaponSO, int> allWeapons;
   
    [SerializedDictionary("All food", "quantity")]
    public SerializedDictionary<FoodSO, int> allFood;

    [Header("Money")]
    public int money;

    public void AddWeapon(WeaponSO weaponSO) {
        if (allWeapons.ContainsKey(weaponSO)) {
            allWeapons[weaponSO] += 1;
        } else {
            allWeapons[weaponSO] = 1;
        }
    }

    public void AddFood(FoodSO foodSO) {
        if (allFood.ContainsKey(foodSO)) {
            allFood[foodSO] += 1;
        } else {
            allFood[foodSO] = 1;
        }
    }

    public void MinusMoney(int money) {
        this.money -= money;
    }
}
