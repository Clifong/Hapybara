using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;
using UnityEngine.UI;
using TMPro;   

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

    public void SetInfo(Image icon) {
        icon.sprite = foodIconWithoutFrame;
    }

    public void SetUIInfoWithFrame(Image icon, TextMeshProUGUI text) {
        icon.sprite = foodIconWithFrame;
        text.text = foodName;
    }

    public void SetUIInfoWithoutFrame(Image icon, TextMeshProUGUI text) {
        icon.sprite = foodIconWithoutFrame;
        text.text = foodName;
    }

    public void FillUpDefaultInfo(TextMeshProUGUI currentHealthChangeText, TextMeshProUGUI maxHealthChangeText, TextMeshProUGUI attackChangeText, TextMeshProUGUI defenceChangeText, TextMeshProUGUI speedChangeText, TextMeshProUGUI effectsDescriptionText) {
        currentHealthChangeText.text = currentHealthChange.ToString();
        maxHealthChangeText.text = maxHealthChange.ToString();
        attackChangeText.text = attackChange.ToString();
        defenceChangeText.text = defenceChange.ToString();
        speedChangeText.text = speedChange.ToString();
        effectsDescriptionText.text = effectsDescription;
    }

    public void ReduceIngredient(PlayerInventorySO playerInventory) {
        foreach (IngredientSO ingredient in ingredientsNeeded.ReturnKeys())
        {
            playerInventory.ReduceIngredient(ingredient, ingredientsNeeded[ingredient]);
        }
    }
}
