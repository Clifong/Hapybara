using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyMemberIcon : MonoBehaviour
{
    public Image icon;
    private PlayerSO playerSO;
    public CrossObjectEventWithData populateUIInfo;

    public void SetPlayerInfo(PlayerSO playerSO) {
        this.playerSO = playerSO;
        icon.sprite = playerSO.playerIcon;
    }

    public void PopulateUI() {
        populateUIInfo.TriggerEvent(this, playerSO);
    }
}
