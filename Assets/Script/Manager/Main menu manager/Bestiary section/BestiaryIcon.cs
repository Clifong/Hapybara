using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestiaryIcon : MonoBehaviour
{
    public Image spriteIcon;
    public Button button;
    public CrossObjectEventWithData bradcastEnemyInfoForDisplay;
    private EnemySO enemySO;

   
    public void SetInfo(EnemySO enemySO) {
        this.enemySO = enemySO;
        enemySO.FillBestiaryInfo(spriteIcon, button);
    }

    public void BroadcastInfo() {
        bradcastEnemyInfoForDisplay.TriggerEvent(this, enemySO);
    }
}
