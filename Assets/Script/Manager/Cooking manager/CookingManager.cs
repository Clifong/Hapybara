using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingManager : MonoBehaviour
{
    public CrossObjectEventWithData goToCookingPot;
    private FoodSO foodSO;
    public PlayerSO playerSO;
    
    public void StoreFoodSO(Component component, object obj) {
        object[] temp = (object[]) obj;
        this.foodSO = (FoodSO) temp[0];
    }

    public void GoToCookingPot() {
        goToCookingPot.TriggerEvent(this, foodSO);
    }

    public void AddFoodToInventory() {
        if (playerSO.allFood.ContainsKey(foodSO)) {
            playerSO.allFood[foodSO] += 1;
        } else {
            playerSO.allFood[foodSO] = 1;
        }
    }
}
