using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "FoodSO", menuName = "Food SO", order = 1)]
public class FoodSO : ScriptableObject
{
    [Header("Information")]
    public Sprite foodIconWithFrame;
    public Sprite foodIconWithoutFrame;
    public string foodName;
    public bool unlocked;
    [TextAreaAttribute]
    public string foodDescription;

    [Header("Effects description")]
    [TextAreaAttribute]
    public string effectsDescription;
    [Header("Ingredients needed")]
    
    [SerializedDictionary("Ingredient type", "quantity")]
    public SerializedDictionary<IngredientSO, int> ingredientsNeeded;
    
    [Header("Stats change")]
    public int currentHealthChange;
    public int maxHealthChange;
    public int attackChange;
    public int defenceChange;
    public int speedChange;
}
