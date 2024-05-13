using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "Shopkeeper SO", menuName = "NPC/ShopkeeperSO", order = 1)]
public class ShopkeeperSO : ScriptableObject
{
    [SerializedDictionary("All Weapons", "quantity")]
    public SerializedDictionary<WeaponSO, int> allWeaponsSold;
    [SerializedDictionary("All Food", "quantity")]
    public SerializedDictionary<FoodSO, int> allFoodSold;
}
