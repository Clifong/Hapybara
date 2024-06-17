using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public PlayerQuestSO playerQuestSO;
    private QuestSO currentQuest;
    private QuestSO currentQuestToComplete;
    private QuestPanel paper;
    public Transform content;
    public Transform canCompleteContent;
    public GameObject questPanel;
    public GameObject completedQuestPanel;
    public CrossObjectEventWithData checkIfQuestCanComplete;
    private List<GameObject> instantiatedPanelList = new List<GameObject>();

    public void PopulateUI() {
        foreach (GameObject panel in instantiatedPanelList)
        {
            Destroy(panel);
        }
        instantiatedPanelList.Clear();
        foreach (QuestSO quest in playerQuestSO.acceptedQuest)
        {
            checkIfQuestCanComplete.TriggerEvent(this, quest);
            if (!quest.canComplete) {
                GameObject instantiatedPanel = Instantiate(questPanel, content);
                instantiatedPanel.GetComponent<QuestPanelInManager>().SetInfo(quest);
                instantiatedPanelList.Add(instantiatedPanel);
            } else {
                GameObject instantiatedPanel = Instantiate(completedQuestPanel, canCompleteContent);
                instantiatedPanel.GetComponent<QuestPanelInManager>().SetInfo(quest);
                instantiatedPanelList.Add(instantiatedPanel);
            }
        }
    }

    public void SetQuest(Component component, object obj) {
        object[] temp = (object[])obj;
        paper = (QuestPanel) component;
        QuestSO quest = (QuestSO) temp[0];
        currentQuest = quest;
    }

    public void SetQuestToComplete(Component component, object obj) {
        object[] temp = (object[])obj;
        QuestSO quest = (QuestSO) temp[0];
        currentQuestToComplete = quest;
    }

    public void CompleteQuest() {
        playerQuestSO.CompleteQuest(currentQuestToComplete);
        currentQuestToComplete = null;
        PopulateUI();
    }

    public void AddQuest() {
        paper.SetRemove();
        playerQuestSO.AddQuest(currentQuest);
        currentQuest = null;
        paper = null;
    }
}
