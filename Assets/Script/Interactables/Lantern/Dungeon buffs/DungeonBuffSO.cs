using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class DungeonBuffSO : ScriptableObject
{
    public Sprite icon;
    public string name;
    [TextAreaAttribute]
    public string description;

    public void PopulateUI(Image buffImage, TextMeshProUGUI buffName, TextMeshProUGUI buffDescription) {
        buffImage.sprite = icon;
        buffName.text = name;
        buffDescription.text = description;
    }
}
