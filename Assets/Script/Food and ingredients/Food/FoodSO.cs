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
    public Sprite foodIcon;
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
    public int currAttackChange;
    public int attackChangeDuration;
    public int currDefenceChange;
    public int defenceChangeDuration;
    public int maxSpeedChange;
    public int speedChangeDuration;

    public void SetInfo(Image icon) {
        icon.sprite = foodIcon;
    }

    public void SetUIInfo(Image icon, TextMeshProUGUI text) {
        icon.sprite = foodIcon;
        text.text = foodName;
    }

    public void FillUpDefaultInfo(TextMeshProUGUI currentHealthChangeText, TextMeshProUGUI maxHealthChangeText, TextMeshProUGUI attackChangeText, TextMeshProUGUI defenceChangeText, TextMeshProUGUI speedChangeText, TextMeshProUGUI effectsDescriptionText) {
        currentHealthChangeText.text = currentHealthChange.ToString();
        attackChangeText.text = currAttackChange.ToString();
        defenceChangeText.text = currDefenceChange.ToString();
        speedChangeText.text = maxSpeedChange.ToString();
        effectsDescriptionText.text = effectsDescription;
    }

    public void ReduceIngredient(PlayerInventorySO playerInventory) {
        foreach (IngredientSO ingredient in ingredientsNeeded.ReturnKeys())
        {
            playerInventory.ReduceIngredient(ingredient, ingredientsNeeded[ingredient]);
        }
    }

    public void GainBuffFromEating(PlayerSO playerSO) {
        playerSO.currentHealth += currentHealthChange; 
        playerSO.currAttackBuff += currAttackChange;
        playerSO.currAttackBuffDuration += attackChangeDuration;
        playerSO.currDefenceBuff += currDefenceChange;
        playerSO.currDefenceBuffDuration += defenceChangeDuration;
        playerSO.maxSpeedBuff += maxSpeedChange;
        playerSO.maxSpeedBuffDuration += speedChangeDuration;

        playerSO.attack += currAttackChange;
        playerSO.defence += currDefenceChange;
        playerSO.speed += maxSpeedChange;
    }
}
