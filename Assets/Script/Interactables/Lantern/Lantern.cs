using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Lantern : MonoBehaviour, Interactables 
{
    public UnityEvent interactWithLantern;
    public UnityEvent finishInteractingWithLantern;
    public LanternSO lanternSO;
    public GameObject interactPrompt;
    public GameObject lanternBackground;
    private bool canInteract = false;
    [Header("UI")]
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI costLevel;
    public Button levelUpButton;
    [Header("Lantern buffs")]
    public Transform buffContent;
    public GameObject unlockedBuffCard;
    public GameObject lockedBuffCard;
    public CrossObjectEventWithData broadcastBuff;
    private List<GameObject> unlockedBuffCardList = new List<GameObject>();
    private List<GameObject> lockedBuffCardList = new List<GameObject>();

    void Start() {
        foreach (GameObject unlockedCard in unlockedBuffCardList)
        {
            Destroy(unlockedCard);
        }
        foreach (GameObject lockedCard in lockedBuffCardList)
        {
            Destroy(lockedCard);
        }
        unlockedBuffCardList = new List<GameObject>();
        lockedBuffCardList = new List<GameObject>();

        List<DungeonBuffSO> unlockedBuff = new List<DungeonBuffSO>();
        for (int i = 0; i < lanternSO.level; i++) {
            if (lanternSO.levelAndBuffs.ContainsKey(i + 1)) {
                unlockedBuff.Add(lanternSO.levelAndBuffs[i + 1]);
                GameObject instantiatedUnlockedBuff = Instantiate(unlockedBuffCard, buffContent);
                instantiatedUnlockedBuff.GetComponent<UnlockedBuffCard>().SetBuffSO(lanternSO.levelAndBuffs[i + 1]);
                unlockedBuffCardList.Add(instantiatedUnlockedBuff);
            }
        }

        foreach (int level in lanternSO.levelAndBuffs.ReturnKeys())
        {
            if (lanternSO.level < level) {
                GameObject instantiatedLockedBuff = Instantiate(lockedBuffCard, buffContent);
                lockedBuffCardList.Add(instantiatedLockedBuff);
            }
        }

        broadcastBuff.TriggerEvent(this, unlockedBuff);
    }

    public void Interact() {
        interactWithLantern?.Invoke();
        lanternBackground.SetActive(true);
        lanternSO.PopulateUI(levelText, costLevel);
        lanternSO.CheckIfCanLevelUp(levelUpButton);
    }

    public void Deposit(Component component, object obj) {
        object[] temp = (object[])obj;
        int memoryDeposit = (int) temp[0];
        lanternSO.Deposit(memoryDeposit);
    }

    public void PopulateUI(Component component, object obj) {
        object[] temp = (object[])obj;
        int currentMemory = (int)temp[0];
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<PlayerInteract>() != null) {
            interactPrompt.SetActive(true);
        }
    } 

    void OnTriggerExit2D(Collider2D other) {
        if (other.GetComponent<PlayerInteract>() != null) {
            interactPrompt.SetActive(false);
        }
    } 

    public void CloseLanternMenu() {
        finishInteractingWithLantern?.Invoke();
    }
}
