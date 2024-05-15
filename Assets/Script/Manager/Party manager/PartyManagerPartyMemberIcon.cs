using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyManagerPartyMemberIcon : MonoBehaviour
{
    private PlayerSO playerSO;
    public Image image;

    public void SetInfo(PlayerSO playerSO) {
        this.playerSO = playerSO;
        image.sprite = playerSO.playerIcon;
    }
}
