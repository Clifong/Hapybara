using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedingManager : MonoBehaviour
{
    private PlayerSO playerSO;
    public CrossObjectEventWithData reduceFood;
    private FoodSO foodSO;

    public void SetPlayerToFeed(Component component, object obj) {
        object[] temp = (object[])obj;
        playerSO = (PlayerSO)temp[0];
    }

    public void SetFoodToFeed(Component component, object obj) {
        object[] temp = (object[])obj;
        this.foodSO = (FoodSO) temp[0];
    }
    
    public void FeedPlayer() {
        List<FoodSO> food = new List<FoodSO>();
        List<int> num = new List<int>();
        food.Add(foodSO);
        num.Add(1);
        reduceFood.TriggerEvent(this, food, num);
        playerSO.Feed(foodSO);
    }
}
