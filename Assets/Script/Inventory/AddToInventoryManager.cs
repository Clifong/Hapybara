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

    public void BroadcastMoney() {
        broadcastMoney.TriggerEvent(this, playerInventorySO.money);
    }

    public void MinusMoney(Component component, object obj) {
        object[] temp = (object[])obj;
        playerInventorySO.MinusMoney((int)temp[0]);
    }
}
