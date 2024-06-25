using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "IngredientSO", menuName = "Ingredient SO", order = 1)]
public class IngredientSO : ScriptableObject
{
    [Header("Information")]
    public Sprite ingredientIcon;
    public GameObject ingredientObject;
    public string ingredientName;
    [TextAreaAttribute]
    public string ingredientDescription;

    public void SetInfo(Image icon) {
        icon.sprite = ingredientIcon;
    }
}

