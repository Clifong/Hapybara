using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyManagerPartyMemberIcon : MonoBehaviour
{
    private PlayerSO playerSO;
    public Image image;
    public Image inParty;
    public Button button;
    public CrossObjectEventWithData selectThisPlayer;

    void Start() {
        button.enabled = false;
    }

    public void SetInfo(PlayerSO playerSO) {
        this.playerSO = playerSO;
        image.sprite = playerSO.playerIcon;
        inParty.gameObject.SetActive(false);
    }

    public void SetInParty(Sprite inPartyImage) {
        inParty.gameObject.SetActive(true);
        inParty.sprite = inPartyImage;
    }

    public void CanSelectPlayer() {
        button.enabled = true;
    }

    public void DoneSelecting() {
        button.enabled = false;
    }

    public void SelectThisPlayer() {
        selectThisPlayer.TriggerEvent(this, playerSO);
    }
}
