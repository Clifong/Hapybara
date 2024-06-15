using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInventoryManager : MonoBehaviour
{
    public PlayerInventorySO playerInventorySO;
    
    public CrossObjectEventWithData broadcastMoney;
    public CrossObjectEventWithData broadcastMemory;
    [Header("Checker")]
    public CrossObjectEventWithData checkIfCanCraft;

    public void AddToInventory(Component component, object obj) {
        object[] temp = (object[])obj;
        List<WeaponSO> allWeaponToAdd = (List<WeaponSO>)temp[0];
        List<FoodSO> allFoodToAdd = (List<FoodSO>)temp[1];
        foreach (WeaponSO weapon in allWeaponToAdd)
        {
            playerInventorySO.AddWeapon(weapon);
        }
        foreach (FoodSO foodSO in allFoodToAdd)
        {
            playerInventorySO.AddFood(foodSO);
        }
    }
    
    public void AddWeaponOnlyToInventory(Component component, object obj) {
        object[] temp = (object[])obj;
        List<WeaponSO> allWeaponToAdd = (List<WeaponSO>)temp[0];
        foreach (WeaponSO weapon in allWeaponToAdd)
        {
            playerInventorySO.AddWeapon(weapon);
        }
    }

    public void AddFoodOnlyToInventory(Component component, object obj) {
        object[] temp = (object[])obj;
        List<FoodSO> allFoodToAdd = (List<FoodSO>)temp[0];
        foreach (FoodSO foodSO in allFoodToAdd)
        {
            playerInventorySO.AddFood(foodSO);
        }
    }

    public void ReduceFoodOnlyInInventory(Component component, object obj) {
        object[] temp = (object[])obj;
        List<FoodSO> allFoodToChange = (List<FoodSO>)temp[0];
        List<int> quantityToRemove = (List<int>)temp[1];
        for (int i = 0; i < allFoodToChange.Count; i++)
        {
            playerInventorySO.ReduceFood(allFoodToChange[i], quantityToRemove[i]);
        }
    }

    public void AddLootFromEnemy(Component component, object obj) {
        object[] temp = (object[])obj;
        int money = (int) temp[0];
        int memory = (int) temp[1];
        List<WeaponSO> allWeaponToAdd = (List<WeaponSO>)temp[2];
        List<FoodSO> allFoodToAdd = (List<FoodSO>)temp[3];
        List<IngredientSO> allIngredientToAdd = (List<IngredientSO>)temp[4];
        playerInventorySO.AddMoney(money);
        playerInventorySO.AddMemory(memory);
        foreach (WeaponSO weapon in allWeaponToAdd)
        {
            playerInventorySO.AddWeapon(weapon);
        }
        foreach (FoodSO foodSO in allFoodToAdd)
        {
            playerInventorySO.AddFood(foodSO);
        }
        foreach (IngredientSO ingredientSO in allIngredientToAdd)
        {
            playerInventorySO.AddIngredient(ingredientSO);
        }
    }

    public void ChangeBuildableQty(Component component, object obj) {
        object[] temp = (object[])obj;
        BuildableSO furniture = (BuildableSO) temp[0];
        int qty = (int) temp[1];
        if (qty < 0) {
            playerInventorySO.ReduceFurniture(furniture, -qty);
        } else {
            playerInventorySO.AddFurniture(furniture, qty);
        }
    }

    public void CraftFurniture(Component component, object obj) {
        object[] temp = (object[])obj;
        BuildableSO furniture = (BuildableSO) temp[0];
        int qty = (int) temp[1];
        for (int i = 0; i < qty; i++)
        {
            furniture.ReduceMaterial(playerInventorySO);
        }
    }

    public void BroadcastMoney() {
        broadcastMoney.TriggerEvent(this, playerInventorySO.money);
    }

    public void MinusMoney(Component component, object obj) {
        object[] temp = (object[])obj;
        playerInventorySO.MinusMoney((int)temp[0]);
    }

    public void MinusMemory() {
        broadcastMemory.TriggerEvent(this, playerInventorySO.memory);
        playerInventorySO.MinusMemory(playerInventorySO.memory);
    }

    public void CheckIfCanCraft(Component component, object obj) {
        object[] temp = (object[]) obj;
        BuildableSO furniture = (BuildableSO) temp[0];
        bool canCraft = playerInventorySO.CanCraft(furniture);
        checkIfCanCraft.TriggerEvent(this, canCraft);
    }
}
