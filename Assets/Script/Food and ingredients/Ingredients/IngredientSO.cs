using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientSO", menuName = "Ingredient SO", order = 1)]
public class IngredientSO : ScriptableObject
{
    [Header("Information")]
    public Sprite ingredientIconWithFrame;
    public Sprite ingredientIconWithoutFrame;
<<<<<<< HEAD
    public GameObject ingredientObject;
=======
>>>>>>> V3-Added-more-assets-to-cooking-menu
    public string ingredientName;
    [TextAreaAttribute]
    public string ingredientDescription;
}
