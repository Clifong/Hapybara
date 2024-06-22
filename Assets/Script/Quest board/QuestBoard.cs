using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestBoard : MonoBehaviour, Interactables 
{
    public GameObject interactPrompt;
    private bool canInteract = false;
    public QuestBoardSO questBoardSO;
    public GameObject questCanvas;
    public GameObject questPanel;
    public Transform content;
    private List<GameObject> instantiatedQuestPanels = new List<GameObject>();
    private QuestSO currentQuestSO;

    public void Interact() {
        questCanvas.SetActive(true);
        foreach (GameObject instantiatedPanel in instantiatedQuestPanels)
        {
            Destroy(instantiatedPanel);
        }
        instantiatedQuestPanels.Clear();
        foreach (QuestSO questSO in questBoardSO.allQuests)
        {
            GameObject instantiatedPanel = Instantiate(questPanel, content);
            instantiatedPanel.GetComponent<QuestPanel>().SetInfo(questSO);
            instantiatedQuestPanels.Add(instantiatedPanel);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        interactPrompt.SetActive(true);
    } 

    void OnTriggerExit2D(Collider2D other) {
        interactPrompt.SetActive(false);
    } 

    public void SetQuest(Component component, object obj) {
        object[] temp = (object[])obj;
        currentQuestSO = (QuestSO) temp[0];
    }

    public void RemoveQuest() {
        questBoardSO.RemoveQuest(currentQuestSO);
        currentQuestSO = null;
        EditorUtility.SetDirty(questBoardSO);
    }


}
