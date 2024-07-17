using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleMessageManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    private CrossObjectEvent specialEventToTrigger;

    public void ModifyText(Component component, object obj) {
        object[] temp = (object[]) obj;
        if (temp.Length > 1) {
            specialEventToTrigger = (CrossObjectEvent) temp[1];
        }
        text.text = (string) temp[0];
    }

    public void TriggerSpecialEventIfAny() {
        if (specialEventToTrigger != null) {
            specialEventToTrigger.TriggerEvent();
            specialEventToTrigger = null;
        }
    }
}
