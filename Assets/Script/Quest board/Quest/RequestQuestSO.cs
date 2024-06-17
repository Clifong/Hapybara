using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "RequestQuestSO", menuName = "All quest SO/Request quest SO", order = 1)]
public class RequestQuestSO : QuestSO
{
    [Header("Required stuff")]
    [SerializedDictionary("Food", "quantity")]
    public SerializedDictionary<FoodSO, int> foodNeeded = new SerializedDictionary<FoodSO, int>();
    [SerializedDictionary("Ingredient", "quantity")]
    public SerializedDictionary<IngredientSO, int> ingredientsNeeded = new SerializedDictionary<IngredientSO, int>();
    [SerializedDictionary("Materials", "quantity")]
    public SerializedDictionary<MaterialSO, int> materialsNeeded = new SerializedDictionary<MaterialSO, int>();
    private PlayerInventorySO playerInventorySO;

    public void CheckIfCanComplete(PlayerInventorySO playerInventorySO) {
        this.playerInventorySO = playerInventorySO;
        canComplete = playerInventorySO.CheckIfCanComplete(foodNeeded, ingredientsNeeded, materialsNeeded);
    }

    public override void CompleteQuest() {
        foreach (FoodSO foodSO in foodNeeded.ReturnKeys())
        {
            playerInventorySO.ReduceFood(foodSO, foodNeeded[foodSO]);
        }
        foreach (IngredientSO ingredientSO in ingredientsNeeded.ReturnKeys())
        {
            playerInventorySO.ReduceIngredient(ingredientSO, ingredientsNeeded[ingredientSO]);
        }
        foreach (MaterialSO materialSO in materialsNeeded.ReturnKeys())
        {
            playerInventorySO.ReduceMaterial(materialSO, materialsNeeded[materialSO]);
        }
        base.CompleteQuest(playerInventorySO);
    }
}
