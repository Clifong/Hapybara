using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "Player Inventory SO", menuName = "All player SO/PlayerInventorySO", order = 1)]
public class PlayerInventorySO : ScriptableObject
{
    [Header("Inventory stuff")]
    [SerializedDictionary("All weapons", "quantity")]
    public SerializedDictionary<WeaponSO, int> allWeapons = new SerializedDictionary<WeaponSO, int>();
   
    [SerializedDictionary("All food", "quantity")]
    public SerializedDictionary<FoodSO, int> allFood = new SerializedDictionary<FoodSO, int>();
    [SerializedDictionary("All ingredients", "quantity")]
    public SerializedDictionary<IngredientSO, int> allIngredints = new SerializedDictionary<IngredientSO, int>();
    [SerializedDictionary("All furnitures", "quantity")]
    public SerializedDictionary<BuildableSO, int> allFurniture = new SerializedDictionary<BuildableSO, int>();
    [SerializedDictionary("All materials", "quantity")]
    public SerializedDictionary<MaterialSO, int> allMaterials = new SerializedDictionary<MaterialSO, int>();

    [Header("Money")]
    public int money;
    [Header("Memory")]
    public int memory;
    [Header("Matchstick")]
    public int matchstick;

    public void AddWeapon(WeaponSO weaponSO) {
        if (allWeapons.ContainsKey(weaponSO)) {
            allWeapons[weaponSO] += 1;
        } else {
            allWeapons[weaponSO] = 1;
        }
        this.SetDirty();
    }

    public void AddWeapon(WeaponSO weaponSO, int qty) {
        if (allWeapons.ContainsKey(weaponSO)) {
            allWeapons[weaponSO] += qty;
        } else {
            allWeapons[weaponSO] = qty;
        }
        this.SetDirty();
    }

    public void AddFood(FoodSO foodSO) {
        if (allFood.ContainsKey(foodSO)) {
            allFood[foodSO] += 1;
        } else {
            allFood[foodSO] = 1;
        }
        this.SetDirty();
    }

    public void AddFood(FoodSO foodSO, int quantity) {
        if (allFood.ContainsKey(foodSO)) {
            allFood[foodSO] += quantity;
        } else {
            allFood[foodSO] = quantity;
        }
        this.SetDirty();
    }

    public void AddIngredient(IngredientSO ingredientSO) {
        if (allIngredints.ContainsKey(ingredientSO)) {
            allIngredints[ingredientSO] += 1;
        } else {
            allIngredints[ingredientSO] = 1;
        }
        this.SetDirty();
    }

    public void AddIngredient(IngredientSO ingredientSO, int quantity) {
        if (allIngredints.ContainsKey(ingredientSO)) {
            allIngredints[ingredientSO] += quantity;
        } else {
            allIngredints[ingredientSO] = quantity;
        }
        this.SetDirty();
    }


    public void ReduceFood(FoodSO foodSO, int quantity) {
        if (allFood.ContainsKey(foodSO)) {
            allFood[foodSO] -= quantity;
            if (allFood[foodSO] <= 0) {
                allFood.Remove(foodSO);
            }
        }
        this.SetDirty();
    }

    public void ReduceIngredient(IngredientSO ingredientSO, int quantity) {
        if (allIngredints.ContainsKey(ingredientSO)) {
            allIngredints[ingredientSO] -= quantity;
            if (allIngredints[ingredientSO] <= 0) {
                allIngredints.Remove(ingredientSO);
            }
        }
        this.SetDirty();
    }

    public void AddFurniture(BuildableSO furniture, int qty) {
        if (allFurniture.ContainsKey(furniture)) {
            allFurniture[furniture] += qty;
        } else {
            allFurniture[furniture] = qty;
        }
        this.SetDirty();
    }

    public void ReduceFurniture(BuildableSO furniture, int qty) {
        if (allFurniture.ContainsKey(furniture)) {
            allFurniture[furniture] -= qty;
            if (allFurniture[furniture] <= 0) {
                allFurniture.Remove(furniture);
            }
        }
        this.SetDirty();
    }

    public void AddMaterial(MaterialSO materialSO, int qty) {
        if (allMaterials.ContainsKey(materialSO)) {
            allMaterials[materialSO] += qty;
        } else {
            allMaterials[materialSO] = qty;
        }
        this.SetDirty();
    }

    public void ReduceMaterial(MaterialSO materialSO, int quantity) {
        if (allMaterials.ContainsKey(materialSO)) {
            allMaterials[materialSO] -= quantity;
            if (allMaterials[materialSO] <= 0) {
                allMaterials.Remove(materialSO);
            }
        }
        this.SetDirty();
    }

    public int GetFoodQty(FoodSO foodSO) {
        if (allFood.ContainsKey(foodSO)) {
            return allFood[foodSO];
        }
        return -1;
    }

    public void AddMoney(int money) {
        this.money += money;
        this.SetDirty();
    }

    public void MinusMoney(int money) {
        this.money -= money;
        this.SetDirty();
    }

    public void AddMemory(int memory) {
        this.memory += memory;
        this.SetDirty();
    }

    public void MinusMemory(int memory) {
        this.memory -= memory;
        this.SetDirty();
    }

    public void MinusMatchstick(int matchstick) {
        this.matchstick -= matchstick;
        this.SetDirty();
    }

    public bool CanCook(FoodSO foodSO) {
        foreach (IngredientSO ingredient in foodSO.ingredientsNeeded.ReturnKeys()) 
        {
            if (!allIngredints.ContainsKey(ingredient)) {
                return false;
            } else {
                if (allIngredints[ingredient] < foodSO.ingredientsNeeded[ingredient]) {
                    return false;
                }
            }
        }
        return true;
    }

    public bool CanCraft(BuildableSO furniture) {
        foreach (MaterialSO material in furniture.materialsNeeded.ReturnKeys()) 
        {
            if (!allMaterials.ContainsKey(material)) {
                return false;
            } else {
                if (allMaterials[material] < furniture.materialsNeeded[material]) {
                    return false;
                }
            }
        }
        return true;
    }

    public bool CheckIfCanComplete(SerializedDictionary<FoodSO, int> foodNeeded, SerializedDictionary<IngredientSO, int> ingredientsNeeded, SerializedDictionary<MaterialSO, int> materialsNeeded) {
        foreach (FoodSO foodSO in foodNeeded.ReturnKeys())
        {
            if (!allFood.ContainsKey(foodSO)) {
                return false;
            } else if (allFood[foodSO] < foodNeeded[foodSO]) {
                return false;
            }
        }
        foreach (IngredientSO ingredientSO in ingredientsNeeded.ReturnKeys())
        {
            if (!allIngredints.ContainsKey(ingredientSO)) {
                return false;
            } else if (allIngredints[ingredientSO] < ingredientsNeeded[ingredientSO]) {
                return false;
            }
        }
        foreach (MaterialSO materialSO in materialsNeeded.ReturnKeys())
        {
            if (!allMaterials.ContainsKey(materialSO)) {
                return false;
            } else if (allMaterials[materialSO] < materialsNeeded[materialSO]) {
                return false;
            }
        }
        return true;
    }

     public void CheckIfEnoughToEquip(WeaponSO weapon, EquipButton equipButton) {
        if (weapon.owner.Count + 1 > allWeapons[weapon]) {
            equipButton.ExceedQuantity();
        } else {
            equipButton.EnoughQuantity();
        }
     }

}
