using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientSO", menuName = "Ingredient SO", order = 1)]
public class IngredientSO : ScriptableObject
{
    [Header("Information")]
    public Sprite ingredientIconWithFrame;
    public Sprite ingredientIconWithoutFrame;
    public GameObject ingredientObject;
    public string ingredientName;
    [TextAreaAttribute]
    public string ingredientDescription;
}

