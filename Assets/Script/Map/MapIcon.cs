using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapIcon : MonoBehaviour
{
    public AchievementSO achievementSO;
    private Image image;
    private Button button;

    void OnEnable()
    {
        if (button == null) {
            button = GetComponent<Button>();
            image = GetComponent<Image>();
        }
        if (achievementSO.obtained) {
            button.enabled = true;
            image.color = new Color(255f,256f,256f,1f);
        } else {
            button.enabled = false;
            image.color = new Color(0f,0f,0f,.2f);
        }
    }
}
