using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyIconWhenFeeding : MonoBehaviour
{
    public Image icon;
    private PlayerSO playerSO;
    public CrossObjectEventWithData setPlayerToFeed;

    public void SetPlayerInfo(PlayerSO playerSO) {
        this.playerSO = playerSO;
        icon.sprite = playerSO.playerIcon;
    }

    public void SetPlayerToFeed() {
        setPlayerToFeed.TriggerEvent(this, playerSO);
    }
}
