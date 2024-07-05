using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialIconIndicator : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI nameText;

    public void FIllInIcon(Sprite image, string name) {
        icon.sprite = image;
        nameText.text = name;
    }
}
