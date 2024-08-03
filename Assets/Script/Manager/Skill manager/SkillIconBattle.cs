using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIconBattle : MonoBehaviour
{
    public Image skillImage;
    public GameObject glow;

    public void DisplayIcon(SkillsSO skillSO) {
        skillSO.DisplayIcon(skillImage);
        skillImage.color = new Color(256, 256, 256, 100.0f);
    }

    public void ActivateGlow() {
        glow.SetActive(true);
    }

    public void DeactivateGlow() {
        glow.SetActive(false);
    }

}
