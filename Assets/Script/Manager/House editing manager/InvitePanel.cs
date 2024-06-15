using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvitePanel : MonoBehaviour
{
    public Image icon;
    private PlayerSO playerSO;
    public TextMeshProUGUI nameText;
    public CrossObjectEventWithData invitePlayer;
    public GameObject checkMark;

    public void SetInfo(PlayerSO playerSO) {
        this.playerSO = playerSO;
        playerSO.SetInfo(icon, nameText);
        checkMark.SetActive(playerSO.invited);
    }

    public void InvitePlayer() {
        invitePlayer.TriggerEvent(this, playerSO);
    }
}
