using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "ChestSO", menuName = "ChestSO", order = 1)]
public class ChestSO : OneTimeObjectSO
{
    [SerializedDictionary("All Weapons", "quantity")]
    public SerializedDictionary<WeaponSO, int> allWeapons = new SerializedDictionary<WeaponSO, int>();
    [SerializedDictionary("All Food", "quantity")]
    public SerializedDictionary<FoodSO, int> allFood = new SerializedDictionary<FoodSO, int>();
    [SerializedDictionary("All ingredients", "quantity")]
    public SerializedDictionary<IngredientSO, int> allIngredient = new SerializedDictionary<IngredientSO, int>();
    [SerializedDictionary("All materials", "quantity")]
    public SerializedDictionary<MaterialSO, int> allMaterials = new SerializedDictionary<MaterialSO, int>();
    [SerializedDictionary("All furniture", "quantity")]
    public SerializedDictionary<BuildableSO, int> allFurniture = new SerializedDictionary<BuildableSO, int>();
    [SerializedDictionary("All recipe", "quantity")]
    public SerializedDictionary<RecipeSO, int> allRecipe = new SerializedDictionary<RecipeSO, int>();
    public int money;

    public void AddChestItem(PlayerInventorySO playerInventorySO, 
    CrossObjectEventWithData broadcastNumberOfWeaponAdded,
    CrossObjectEventWithData broadcastNumberOfFoodAdded,
    CrossObjectEventWithData broadcastNumberOfFurnitureAdded,
    AddToInventoryManager monoBehaviourObj) {
        playerInventorySO.AddMoney(money);

        int weaponAdded = 0;
        List<WeaponSO> weapons = new List<WeaponSO>();
        foreach (WeaponSO weaponSO in allWeapons.ReturnKeys()) 
        {
            playerInventorySO.AddWeapon(weaponSO, allWeapons[weaponSO]);
            weaponAdded += allWeapons[weaponSO];
        }
        broadcastNumberOfWeaponAdded.TriggerEvent(monoBehaviourObj, weaponAdded);
        
        int foodAdded = 0;
        foreach (FoodSO foodSO in allFood.ReturnKeys()) 
        {
            playerInventorySO.AddFood(foodSO, allFood[foodSO]);
            foodAdded += allFood[foodSO];
        }
        broadcastNumberOfWeaponAdded.TriggerEvent(monoBehaviourObj, foodAdded);

        foreach (IngredientSO ingredientSO in allIngredient.ReturnKeys()) 
        {
            playerInventorySO.AddIngredient(ingredientSO, allIngredient[ingredientSO]);
        }

        foreach (MaterialSO materialSO in allMaterials.ReturnKeys()) 
        {
            playerInventorySO.AddMaterial(materialSO, allMaterials[materialSO]);
        }

        int furnitureAdded = 0;
        foreach (BuildableSO furnitureSO in allFurniture.ReturnKeys()) 
        {
            playerInventorySO.AddFurniture(furnitureSO, allFurniture[furnitureSO]);
            furnitureAdded += allFurniture[furnitureSO];
        }
        broadcastNumberOfFurnitureAdded.TriggerEvent(monoBehaviourObj, furnitureAdded);
    }

    public void AddChestItemRecipe(PlayerUnlockedDishesSO playerUnlockedDishesSO) {
        playerUnlockedDishesSO.AddRecipe(allRecipe.ReturnKeys());
    }
}
