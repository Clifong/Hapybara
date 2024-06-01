using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lantern : MonoBehaviour, Interactables 
{
    public CrossObjectEvent interactWithLantern;
    public LanternSO lanternSO;
    public GameObject interactPrompt;
    public GameObject lanternBackground;
    private bool canInteract = false;
    [Header("UI")]
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI costLevel;
    public Button levelUpButton;

    public void Interact() {
        interactWithLantern.TriggerEvent();
        lanternBackground.SetActive(true);
        lanternSO.PopulateUI(levelText, costLevel);
        lanternSO.CheckIfCanLevelUp(levelUpButton);
    }

    void OnTriggerEnter2D(Collider2D other) {
        interactPrompt.SetActive(true);
    } 

    void OnTriggerExit2D(Collider2D other) {
        interactPrompt.SetActive(false);
    } 
}
