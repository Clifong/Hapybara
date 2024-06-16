using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public PlayerQuestSO playerQuestSO;
    private QuestSO currentQuest;
    private QuestPanel paper;

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
