using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerQuestSO", menuName = "All player SO/PlayerQuestSO", order = 1)]
public class PlayerQuestSO : ScriptableObject
{
    public List<QuestSO> acceptedQuest = new List<QuestSO>();

    public void AddQuest(QuestSO questSO) {
        acceptedQuest.Add(questSO);
    }

    public void CompleteQuest(QuestSO questSO) {
        questSO.CompleteQuest();
        acceptedQuest.Remove(questSO);
    }
}
