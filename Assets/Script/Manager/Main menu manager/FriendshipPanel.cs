using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FriendshipPanel : MonoBehaviour
{
    public Image frame;
    public Image objectOfFaith;
    public Button objectOfFaithButton;
    public Image playerIcon;
    public TextMeshProUGUI loreText;
    public CrossObjectEventWithData broadcastOOFInfo;
    private PlayerSO playerSO;

    public void SetInfo(PlayerSO playerSO) {
        this.playerSO = playerSO;
        playerSO.SetFrameInfo(frame, objectOfFaith, playerIcon, loreText, objectOfFaithButton);
    }

    public void SetEnlargedInfo() {
        broadcastOOFInfo.TriggerEvent(this, playerSO);
    }

}
