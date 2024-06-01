using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "AchievementSO", menuName = "Collectibles/Achievements", order = 1)]
public class AchievementSO : ScriptableObject
{
    [TextAreaAttribute]
    public string achievementName;
    [TextAreaAttribute]
    public string achievementDescription;
    [TextAreaAttribute]
    public string achievementHowToObtain;
    public bool obtained = false;

    public bool SetInfo(TextMeshProUGUI achievementNameText, TextMeshProUGUI achievementDescriptionText, TextMeshProUGUI achievementHowToObtainText) {
        achievementNameText.text = achievementName;
        achievementDescriptionText.text = achievementDescription;
        achievementHowToObtainText.text = achievementHowToObtain;
        return obtained;
    }

    public void UnlockAchievement() {
        obtained = true;
    }
}
