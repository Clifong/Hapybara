using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "Shopkeeper SO", menuName = "NPC/ShopkeeperSO", order = 1)]
public class ShopkeeperSO : ScriptableObject
{
    [SerializedDictionary("All Weapons", "quantity/cost")]
    public SerializedDictionary<WeaponSO, SerializedDictionary<int, int>> allWeaponsSold;
    [SerializedDictionary("All Food", "quantity/cost")]
    public SerializedDictionary<FoodSO, SerializedDictionary<int, int>> allFoodSold;
    [SerializedDictionary("All special item", "quantity/cost")]
    public SerializedDictionary<RecipeSO, SerializedDictionary<int, int>> allSpecialItem;

    public void BuyWeapon(WeaponSO weaponSO, int quantity) {
        int quantityCurrently = allWeaponsSold[weaponSO].ReturnKeys()[0];
        int cost = allWeaponsSold[weaponSO][quantityCurrently];
        allWeaponsSold[weaponSO].Remove(quantityCurrently);
        quantityCurrently -= quantity;
        if (quantityCurrently <= 0) {
            allWeaponsSold.Remove(weaponSO);
        } else {
            allWeaponsSold[weaponSO][quantityCurrently] = cost;
        }
    }

    public void BuyFood(FoodSO foodSO, int quantity) {
        int quantityCurrently = allFoodSold[foodSO].ReturnKeys()[0];
        int cost = allFoodSold[foodSO][quantityCurrently];
        allFoodSold[foodSO].Remove(quantityCurrently);
        quantityCurrently -= quantity;
        if (quantityCurrently <= 0) {
            allFoodSold.Remove(foodSO);
        } else {
            allFoodSold[foodSO][quantityCurrently] = cost;
        }
    }

    public void BuySpecialItem(RecipeSO recipeSO, int quantity) {
        int quantityCurrently = allSpecialItem[recipeSO].ReturnKeys()[0];
        int cost = allSpecialItem[recipeSO][quantityCurrently];
        allSpecialItem[recipeSO].Remove(quantityCurrently);
        quantityCurrently -= quantity;
        if (quantityCurrently <= 0) {
            allSpecialItem.Remove(recipeSO);
        } else {
            allSpecialItem[recipeSO][quantityCurrently] = cost;
        }
    }
}
