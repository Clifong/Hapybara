using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "TutorialAssetSO", menuName = "Tutorial/TutorialAssetSO", order = 1)]
public class TutorialAssetSO : ScriptableObject
{
    public Sprite image;
    public string name;
    [TextAreaAttribute]
    public string description;

    public void SetUIInfo(Image tutorialImage, TextMeshProUGUI nameText, TextMeshProUGUI descriptionText) {
        tutorialImage.sprite = image;
        nameText.text = name;
        descriptionText.text = description;
    }
}
