using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "RequestQuestSO", menuName = "All quest SO/Request quest SO", order = 1)]
public class RequestQuestSO : QuestSO
{
    [Header("Required stuff")]
    [SerializedDictionary("Food", "quantity")]
    public SerializedDictionary<FoodSO, int> foodNeeded;
    [SerializedDictionary("Ingredient", "quantity")]
    public SerializedDictionary<IngredientSO, int> ingredientsNeeded;
    [SerializedDictionary("Materials", "quantity")]
    public SerializedDictionary<MaterialSO, int> materialsNeeded;
}
