using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialCanvas : MonoBehaviour
{
    public Button nextButton;
    public Button prevButton;
    public List<TutorialAssetSO> tutorialAsset;
    private int counter = 0;
    [Header("UI")]
    public Image image;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    
    void OnEnable() {
        prevButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(true);
        SetUIInfo();
    }

    public void Next() {
        counter += 1;
        if (counter == tutorialAsset.Count - 1) {
            nextButton.gameObject.SetActive(false);
            prevButton.gameObject.SetActive(true);
        } else {
            prevButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
        }
        SetUIInfo();
    }

    public void Back() {
        counter -= 1;
        if (counter == 0) {
            nextButton.gameObject.SetActive(true);
            prevButton.gameObject.SetActive(false);
        } else {
            prevButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
        }
        SetUIInfo();
    }

    private void SetUIInfo() {
        if (tutorialAsset.Count == 1) {
            prevButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
        }
        tutorialAsset[counter].SetUIInfo(image, nameText, descriptionText);
    }
}
