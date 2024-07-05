using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public class MainUIIconTutorial : MonoBehaviour
{
    public GameObject iconIndicator;
    public GameObject UIInfoPanel;
    [Header("Main UI")]
    [SerializedDictionary("Icon", "Name")]
    public SerializedDictionary<Sprite, string> mainUIIcon;
    [Header("Houae UI")]
    [SerializedDictionary("Icon", "Name")]
    public SerializedDictionary<Sprite, string> homeUIIcon;
    private List<GameObject> allSpawnedIcons = new List<GameObject>();
    public Transform content;

    void OnEnable() {
        PopulateUI();
    }

    public void PopulateUI() {
        foreach (GameObject spawnedIcon in allSpawnedIcons)
        {
            Destroy(spawnedIcon);
        }
        allSpawnedIcons.Clear();
        FIllInIcon(mainUIIcon, "Main UI");
        FIllInIcon(homeUIIcon, "Home UI");
    }

    private void FIllInIcon(SerializedDictionary<Sprite, string> dictionary, string name) {
        GameObject uiIconPanel = Instantiate(UIInfoPanel, content);
        allSpawnedIcons.Add(uiIconPanel);
        TutorialContentInfo tutorialContentInfo = uiIconPanel.GetComponent<TutorialContentInfo>();
        tutorialContentInfo.FillInSectionNameInfo(name);
        foreach (Sprite sprite in dictionary.ReturnKeys())
        {
            GameObject spawnedIconIndicator = Instantiate(iconIndicator, Vector3.zero, Quaternion.identity);
            spawnedIconIndicator.GetComponent<TutorialIconIndicator>().FIllInIcon(sprite, dictionary[sprite]);
            allSpawnedIcons.Add(spawnedIconIndicator);
            tutorialContentInfo.AddIcon(spawnedIconIndicator);
        }
    }
}
