using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;
using TMPro;

public class QuestSO : ScriptableObject
{
    public string questName;
    [TextAreaAttribute]
    public string questDescription;
    [Header("Rewards")]
    [SerializedDictionary("Weapons", "quantity")]
    public SerializedDictionary<WeaponSO, int> weaponRewards = new SerializedDictionary<WeaponSO, int>();
    [SerializedDictionary("Food", "quantity")]
    public SerializedDictionary<FoodSO, int> foodRewards = new SerializedDictionary<FoodSO, int>();
    [SerializedDictionary("Ingredient", "quantity")]
    public SerializedDictionary<IngredientSO, int> ingredientsRewards = new SerializedDictionary<IngredientSO, int>();
    [SerializedDictionary("Furniture", "quantity")]
    public SerializedDictionary<BuildableSO, int> furnituresRewards = new SerializedDictionary<BuildableSO, int>();
    [SerializedDictionary("Materials", "quantity")]
    public SerializedDictionary<MaterialSO, int> materialsRewards = new SerializedDictionary<MaterialSO, int>();
    public int money;
    
    public void SetInfo(TextMeshProUGUI nameText, TextMeshProUGUI descriptionText, Transform rewardContent, GameObject rewardIcon, List<GameObject> iconList) {
        nameText.text = questName;
        descriptionText.text = questDescription;
        foreach (WeaponSO weaponSO in weaponRewards.ReturnKeys())
        {
            GameObject instantiatedIcon = Instantiate(rewardIcon, rewardContent);
            rewardIcon.GetComponent<RewardIcon>().SetInfo(weaponSO, weaponRewards[weaponSO]);
            iconList.Add(instantiatedIcon);
        }
        foreach (FoodSO foodSO in foodRewards.ReturnKeys())
        {
            GameObject instantiatedIcon = Instantiate(rewardIcon, rewardContent);
            rewardIcon.GetComponent<RewardIcon>().SetInfo(foodSO, foodRewards[foodSO]);
            iconList.Add(instantiatedIcon);
        }
        foreach (IngredientSO ingredientSO in ingredientsRewards.ReturnKeys())
        {
            GameObject instantiatedIcon = Instantiate(rewardIcon, rewardContent);
            rewardIcon.GetComponent<RewardIcon>().SetInfo(ingredientSO, ingredientsRewards[ingredientSO]);
            iconList.Add(instantiatedIcon);
        }
        foreach (BuildableSO buildableSO in furnituresRewards.ReturnKeys())
        {
            GameObject instantiatedIcon = Instantiate(rewardIcon, rewardContent);
            rewardIcon.GetComponent<RewardIcon>().SetInfo(buildableSO, furnituresRewards[buildableSO]);
            iconList.Add(instantiatedIcon);
        }
        foreach (MaterialSO materialSO in materialsRewards.ReturnKeys())
        {
            GameObject instantiatedIcon = Instantiate(rewardIcon, rewardContent);
            rewardIcon.GetComponent<RewardIcon>().SetInfo(materialSO, materialsRewards[materialSO]);
            iconList.Add(instantiatedIcon);
        }
    }
}
