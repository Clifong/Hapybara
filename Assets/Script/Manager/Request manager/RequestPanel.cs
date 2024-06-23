using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RequestPanel : MonoBehaviour
{
    private FoodSO foodSO;
    public Image icon;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI quantityText;

    public void SetFoodSO(FoodSO foodSO, int qty) {
        this.foodSO = foodSO;
        quantityText.text = qty.ToString();
        this.foodSO.SetUIInfo(icon, nameText);
    }
}
