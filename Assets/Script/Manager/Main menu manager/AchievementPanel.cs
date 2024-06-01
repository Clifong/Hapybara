using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementPanel : MonoBehaviour
{
    public Sprite obtainedVersion;
    public Sprite notObtainedVersion;
    public Image panel;
    private AchievementSO achievementSO;
    public TextMeshProUGUI achievementName;
    public TextMeshProUGUI achievementDescription;
    public TextMeshProUGUI achievementHowToObtainText;

    public void SetInfo(AchievementSO achievementSO) {
        this.achievementSO = achievementSO;
        bool isObtained = achievementSO.SetInfo(achievementName, achievementDescription, achievementHowToObtainText);
        if (isObtained) {
            panel.sprite = obtainedVersion;
        } else {
            panel.sprite = notObtainedVersion;
        }
    }
}
