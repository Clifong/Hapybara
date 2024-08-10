using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "FurnitureRecipeSO", menuName = "Furniture recipe SO", order = 1)]
public class FurnitureRecipeSO : RecipeSO
{
    public BuildableSO furnitureSO;

    public void SetUIInfo(Image image, TextMeshProUGUI text) {
        text.text = name;
        image.sprite = icon;
    }

    public void SetInfo(Image image) {
        image.sprite = icon;
    }
}