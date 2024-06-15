using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingManager : MonoBehaviour
{
    public CrossObjectEventWithData goToCookingPot;
    private FoodSO foodSO;
    public PlayerInventorySO playerInventorySO;
    public GameObject cookButton; 
    
    public void StoreFoodSO(Component component, object obj) {
        object[] temp = (object[]) obj;
        this.foodSO = (FoodSO) temp[0];
    }

    public void GoToCookingPot() {
        goToCookingPot.TriggerEvent(this, foodSO);
    }

    public void AddFoodToInventory() {
        if (playerInventorySO.allFood.ContainsKey(foodSO)) {
            playerInventorySO.allFood[foodSO] += 1;
        } else {
            playerInventorySO.allFood[foodSO] = 1;
        }
        
        foodSO.ReduceIngredient(playerInventorySO);
    }

    public void CheckIfCanCook(Component component, object obj) {
        object[] temp = (object[]) obj;
        FoodSO foodSO = (FoodSO) temp[0];
        bool canCook = playerInventorySO.CanCook(foodSO);
        cookButton.SetActive(canCook);
    }
}
