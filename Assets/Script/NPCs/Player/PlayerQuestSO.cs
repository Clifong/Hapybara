using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "PlayerQuestSO", menuName = "All player SO/PlayerQuestSO", order = 1)]
public class PlayerQuestSO : ScriptableObject
{
    public List<QuestSO> acceptedQuest = new List<QuestSO>();

    public void AddQuest(QuestSO questSO) {
        acceptedQuest.Add(questSO);
        // EditorUtility.SetDirty(this);
    }

    public void CompleteQuest(QuestSO questSO) {
        questSO.CompleteQuest();
        acceptedQuest.Remove(questSO);
        // EditorUtility.SetDirty(this);
    }
}
