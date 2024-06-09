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
    [SerializedDictionary("All ingredients", "quantity")]
    public SerializedDictionary<IngredientSO, int> allIngredints;
    [SerializedDictionary("All furnitures", "quantity")]
    public SerializedDictionary<BuildableSO, int> allFurniture;

    [Header("Money")]
    public int money;
    [Header("Memory")]
    public int memory;

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

    public void AddIngredient(IngredientSO ingredientSO) {
        if (allIngredints.ContainsKey(ingredientSO)) {
            allIngredints[ingredientSO] += 1;
        } else {
            allIngredints[ingredientSO] = 1;
        }
    }

    public void ReduceFood(FoodSO foodSO, int quantity) {
        if (allFood.ContainsKey(foodSO)) {
            allFood[foodSO] -= quantity;
            if (allFood[foodSO] <= 0) {
                allFood.Remove(foodSO);
            }
        }
    }

    public void ReduceIngredient(IngredientSO ingredientSO, int quantity) {
        if (allIngredints.ContainsKey(ingredientSO)) {
            allIngredints[ingredientSO] -= quantity;
            if (allIngredints[ingredientSO] <= 0) {
                allIngredints.Remove(ingredientSO);
            }
        }
    }

    public void AddFurniture(BuildableSO furniture, int qty) {
        if (allFurniture.ContainsKey(furniture)) {
            allFurniture[furniture] += qty;
        } else {
            allFurniture[furniture] = qty;
        }
    }

    public void ReduceFurniture(BuildableSO furniture, int qty) {
        if (allFurniture.ContainsKey(furniture)) {
            allFurniture[furniture] -= qty;
            if (allFurniture[furniture] <= 0) {
                allFurniture.Remove(furniture);
            }
        }
    }

    public int GetFoodQty(FoodSO foodSO) {
        if (allFood.ContainsKey(foodSO)) {
            return allFood[foodSO];
        }
        return -1;
    }

    public void AddMoney(int money) {
        this.money += money;
    }

    public void MinusMoney(int money) {
        this.money -= money;
    }

    public void AddMemory(int memory) {
        this.memory += memory;
    }

    public void MinusMemory(int memory) {
        this.memory -= memory;
    }

}
