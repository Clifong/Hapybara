using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestPanelInManager : MonoBehaviour
{
    public TextMeshProUGUI name;
    private QuestSO questSO;
    public CrossObjectEventWithData broadcastQuest;
    public void SetInfo(QuestSO questSO) {
        this.questSO = questSO;
        name.text = questSO.questName;
    }

    public void BroadcastQuest() {
        broadcastQuest.TriggerEvent(this, questSO);
    }
}
