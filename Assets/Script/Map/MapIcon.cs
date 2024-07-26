using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapIcon : MonoBehaviour
{
    public AchievementSO achievementSO;
    public string townName;
    public GameObject playerPointer;
    private Image image;
    private Button button;

    void OnEnable()
    {
        playerPointer.SetActive(false);

        if (LevelChanger.GetCurrentLevel() == townName) {
            playerPointer.SetActive(true);
        }

        if (button == null) {
            button = GetComponent<Button>();
            image = GetComponent<Image>();
        }

        if (achievementSO == null) {
            return;
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
