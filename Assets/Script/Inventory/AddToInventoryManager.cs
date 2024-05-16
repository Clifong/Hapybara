using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInventoryManager : MonoBehaviour
{
    public PlayerInventorySO playerInventorySO;
    
    public CrossObjectEventWithData broadcastMoney;

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
        List<WeaponSO> allWeaponToAdd = (List<WeaponSO>)temp[1];
        List<FoodSO> allFoodToAdd = (List<FoodSO>)temp[2];
        List<IngredientSO> allIngredientToAdd = (List<IngredientSO>)temp[3];
        playerInventorySO.AddMoney(money);
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

    public void BroadcastMoney() {
        broadcastMoney.TriggerEvent(this, playerInventorySO.money);
    }

    public void MinusMoney(Component component, object obj) {
        object[] temp = (object[])obj;
        playerInventorySO.MinusMoney((int)temp[0]);
    }
}
