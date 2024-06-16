using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public PlayerQuestSO playerQuestSO;
    private QuestSO currentQuest;
    private QuestPanel paper;
    public Transform content;
    public GameObject questPanel;
    private List<GameObject> instantiatedPanelList = new List<GameObject>();

    public void PopulateUI() {
        foreach (GameObject panel in instantiatedPanelList)
        {
            Destroy(panel);
        }
        instantiatedPanelList.Clear();
        foreach (QuestSO quest in playerQuestSO.acceptedQuest)
        {
            GameObject instantiatedPanel = Instantiate(questPanel, content);
            instantiatedPanel.GetComponent<QuestPanelInManager>().SetInfo(quest);
            instantiatedPanelList.Add(instantiatedPanel);
        }
    }

    public void SetQuest(Component component, object obj) {
        object[] temp = (object[])obj;
        paper = (QuestPanel) component;
        QuestSO quest = (QuestSO) temp[0];
        currentQuest = quest;
    }

    public void AddQuest() {
        paper.SetRemove();
        playerQuestSO.AddQuest(currentQuest);
        currentQuest = null;
        paper = null;
    }
}
