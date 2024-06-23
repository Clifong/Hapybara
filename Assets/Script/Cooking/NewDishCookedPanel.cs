using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewDishCookedPanel : MonoBehaviour
{
    public Image foodImage;
    public TextMeshProUGUI finishedText;
    private FoodSO foodSO;

    public void PopulateUI(Component component, object obj) {
        object[] temp = (object[]) obj;
        this.foodSO = (FoodSO) temp[0];
        foodImage.sprite = this.foodSO.foodIcon;
        finishedText.text = "You have cooked 1 " + this.foodSO.foodName;
    }
}
