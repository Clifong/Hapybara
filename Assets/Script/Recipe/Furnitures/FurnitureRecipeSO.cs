using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "FurnitureRecipeSO", menuName = "Furniture recipe SO", order = 1)]
public class FurnitureRecipeSO : ScriptableObject
{
    public BuildableSO furnitureSO;
    public Sprite icon;
    public string name;
    public string description;

    public void SetUIInfo(Image image, TextMeshProUGUI text) {
        text.text = name;
        image.sprite = icon;
    }
}