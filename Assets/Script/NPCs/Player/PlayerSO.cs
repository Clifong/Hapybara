using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "Player SO", menuName = "All player SO/PlayerSO", order = 1)]
public class PlayerSO : ScriptableObject
{
    public int health;
    public int attack;
    public int defence;
    public int speed;

    [Header("Inventory stuff")]
    [SerializedDictionary("All weapons", "quantity")]
    public SerializedDictionary<WeaponSO, int> allWeapons;
   
    [SerializedDictionary("All food", "quantity")]
    public SerializedDictionary<FoodSO, int> allFood;
}
