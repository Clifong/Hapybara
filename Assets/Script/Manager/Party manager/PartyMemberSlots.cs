using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyMemberSlots : MonoBehaviour
{
    public Image slotImage;
    public Sprite emptySlot;
    private Sprite numberingSlot;
    private PlayerSO playerSO;
    private int position;
    public CrossObjectEventWithData slotLookingAt;
    private Sprite inParty;

    public void Start() {
        ResetData();
    }
    
    public void SetPartyMemberImage(PlayerSO playerSO) {
        this.playerSO = playerSO;
        slotImage.sprite = playerSO.playerAppearance;
    }

    public void SetPosition(Sprite sprite, int position) {
        inParty = sprite;
        this.position = position;
    }

    public void TellPlayerManagerWhichPlayerItIs() {
        slotLookingAt.TriggerEvent(this, position);
    }

    public void ResetData() {
        slotImage.sprite = emptySlot;
    }

    public void SelectThePlayer(PlayerSO playerSO, PartyManagerPartyMemberIcon playerIcon) {
        slotImage.sprite = playerSO.playerAppearance;
        playerIcon.SetInParty(inParty);
    }
}
