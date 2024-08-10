using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpRewardSkillPanel : SkillPanel
{
    public GameObject cleared;
    public TextMeshProUGUI levelText;

    public void SetSkillSO(SkillsSO skillsSO, bool clear, int level) {
        this.skillsSO = skillsSO;
        skillName.text = skillsSO.skillName;
        skillIcon.sprite = skillsSO.skillIcon;
        levelText.text = level.ToString();
        enlargedPopupText.text = skillsSO.skillDescription;
        if (clear) {
            cleared.SetActive(true);
        }
    } 
}
