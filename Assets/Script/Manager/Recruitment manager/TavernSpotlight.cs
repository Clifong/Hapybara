using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TavernSpotlight : MonoBehaviour
{
    public Image icon;
    public CrossObjectEventWithData broadcastPlayerSO;
    private PlayerSO playerSO;

    public void SetIcon(PlayerSO playerSO) {
        this.playerSO = playerSO;
        icon.sprite = playerSO.playerAppearance;
    }

    public void BroadcastData() {
        broadcastPlayerSO.TriggerEvent(this, playerSO);
    } 
}
