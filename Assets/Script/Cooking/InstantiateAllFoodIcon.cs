using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAllFoodIcon : MonoBehaviour
{
    public Transform content;
    public GameObject foodPanel;
    private List<GameObject> foodList = new List<GameObject>();
    public PlayerUnlockedDishesSO unlockedDishesSO;

    public void InstantiateFoodIcon() {
        foreach (GameObject icon in foodList)
        {
            Destroy(icon);
        }
        foodList.Clear();
        foreach (FoodSO food in unlockedDishesSO.unlockedDishes)
        {
            GameObject instantiatedFoodPanel = Instantiate(foodPanel, content);
            instantiatedFoodPanel.GetComponent<DishPanel>().SetFoodSO(food);
            foodList.Add(instantiatedFoodPanel);
        }
    }
}
