using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleMessageManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void ModifyText(Component component, object obj) {
        object[] temp = (object[]) obj;
        text.text = (string) temp[0];
    }
}
