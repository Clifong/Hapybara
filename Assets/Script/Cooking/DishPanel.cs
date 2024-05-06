using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DishPanel : MonoBehaviour
{
    public Image foodIcon;
    public TextMeshProUGUI foodName;
    private FoodSO foodSO;
    public CrossObjectEventWithData broadcastFoodSEvent;

    public void SetFoodSO(FoodSO foodSO) {
        this.foodSO = foodSO;
        foodIcon.sprite = foodSO.foodIconWithFrame;
        foodName.text = foodSO.foodName;
    }

    public void BroadcastFoodSOInfo() {
        broadcastFoodSEvent.TriggerEvent(this, foodSO);
    }
}
