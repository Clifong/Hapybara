using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "LanternSO", menuName = "Lantern SO", order = 1)]
public class LanternSO : ScriptableObject
{
    [Header("Information")]
    public int level = 1;
    public int currentDeposit = 0;
    public List<int> levelCost;
    private int counter = 0;
    private bool maxLevel = false;

    public void LevelUp() {
        while (counter < levelCost.Count && currentDeposit >= levelCost[counter]) {
            currentDeposit -= levelCost[counter];
            level++;
            counter++;
        }
        if (counter == levelCost.Count) {
            maxLevel = true;
        }
    } 

    public void PopulateUI(TextMeshProUGUI levelText, TextMeshProUGUI costLevel) {
        levelText.text = level.ToString();
        costLevel.text = "Current: " + currentDeposit.ToString() + "/" + levelCost[counter].ToString();
    }

    public void CheckIfCanLevelUp(Button levelUpButton) {
        if (counter >= levelCost.Count || currentDeposit < levelCost[counter]) {
            levelUpButton.gameObject.SetActive(false);
        } else {
            levelUpButton.gameObject.SetActive(true);
        }
    }
}

