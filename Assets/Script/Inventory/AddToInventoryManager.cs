using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInventoryManager : MonoBehaviour
{
    public PlayerInventorySO playerInventorySO;
    public PlayerUnlockedDishesSO playerUnlockedDishesSO;
    
    public CrossObjectEventWithData broadcastMoney;
    public CrossObjectEventWithData broadcastMemory;
    public CrossObjectEventWithData broadcastMatchstick;
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

    public void AddChestLootToInventory(Component component, object obj) {
        object[] temp = (object[]) obj;
        ChestSO chestSO = (ChestSO) temp[0];
        chestSO.AddChestItem(playerInventorySO);
        chestSO.AddChestItemRecipe(playerUnlockedDishesSO);
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

    public void AddRecipeOnlyToInventory(Component component, object obj) {
        object[] temp = (object[])obj;
        List<RecipeSO> allRecipeToAdd = (List<RecipeSO>)temp[0];
        playerUnlockedDishesSO.AddRecipe(allRecipeToAdd);
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
        enemySO.AddLoot(playerInventorySO);
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

    public void BroadcastMatchstick() {
        broadcastMatchstick.TriggerEvent(this, playerInventorySO.matchstick);
    }

    public void MinusMoney(Component component, object obj) {
        object[] temp = (object[])obj;
        playerInventorySO.MinusMoney((int)temp[0]);
    }

    public void MinusMemory() {
        broadcastMemory.TriggerEvent(this, playerInventorySO.memory);
        playerInventorySO.MinusMemory(playerInventorySO.memory);
    }

    public void AddMatchstick(Component component, object obj){
        object[] temp = (object[])obj;
        playerInventorySO.MinusMatchstick(-(int) temp[0]);
    }

    public void MinusMatchstick(Component component, object obj){
        object[] temp = (object[])obj;
        playerInventorySO.MinusMatchstick((int) temp[0]);
        BroadcastMatchstick();
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
}
