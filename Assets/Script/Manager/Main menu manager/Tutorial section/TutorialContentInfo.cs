using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialContentInfo : MonoBehaviour
{
    public TextMeshProUGUI sectionText;
    public Transform content;

    public void FillInSectionNameInfo(string name) {
        sectionText.text = name;
    }

    public void AddIcon(GameObject iconIndicator) {
        iconIndicator.transform.SetParent(content);
    }
}
