using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInventoryManager : MonoBehaviour
{
    public PlayerInventorySO playerInventorySO;
    
    public CrossObjectEventWithData broadcastMoney;
    public CrossObjectEventWithData broadcastMemory;
    public CrossObjectEventWithData broadcastExpGained;
    [Header("Checker")]
    public CrossObjectEventWithData checkIfCanCraft;
    private int expGained = 0;

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
        EnemySO enemySO = (EnemySO) temp[0];
        List<object> loot = enemySO.ReturnLoot();

        int money = (int) loot[0];
        int memory = (int) loot[1];
        int exp = (int) loot[2];
        expGained += exp;

        List<WeaponSO> allWeaponToAdd = (List<WeaponSO>)loot[3];
        List<FoodSO> allFoodToAdd = (List<FoodSO>)loot[4];
        List<IngredientSO> allIngredientToAdd = (List<IngredientSO>)loot[5];
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

    public void CheckIfQuestCanBeComplete(Component component, object obj) {
        object[] temp = (object[]) obj;
        RequestQuestSO requestQuestSO = (RequestQuestSO) temp[0];
        requestQuestSO.CheckIfCanComplete(playerInventorySO);
    }

    public void BroadcastExpGained() {
        broadcastExpGained.TriggerEvent(this, expGained);
        expGained = 0;
    }
}
