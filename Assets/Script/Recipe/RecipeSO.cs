using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "RecipeSO", menuName = "Recipe SO", order = 1)]
public class RecipeSO : ScriptableObject
{
    public FoodSO foodSO;
    public Sprite icon;
    public string name;
    public string description;

    public void SetUIInfo(Image image, TextMeshProUGUI text) {
        text.text = name;
        image.sprite = icon;
    }
}
