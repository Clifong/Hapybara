using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestboardSO", menuName = "Quest board SO", order = 1)]
public class QuestBoardSO : ScriptableObject
{
    public List<QuestSO> allQuests;

    public void RemoveQuest(QuestSO questSO) {
        allQuests.Remove(questSO);
    }
}
