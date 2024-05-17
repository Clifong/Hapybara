using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyManager : MonoBehaviour
{
    public PlayerPartySO playerPartySO;
    private List<PlayerSO> activeParty;
    private List<PlayerSO> allPartyMembers;
    public List<PartyMemberSlots> activeMembersImages;
    public GameObject partyMemberIcon;
    public Transform content;
    public Sprite inParty;
    private int slotLookingAt;
    private List<GameObject> allInstantiatedPartyMemberIcons = new List<GameObject>();

    public void PopulateUI() {
        foreach (GameObject instantiatedPartyMemberIcon in allInstantiatedPartyMemberIcons)
        {
            Destroy(instantiatedPartyMemberIcon);
        }
        allInstantiatedPartyMemberIcons.Clear();
        activeParty = playerPartySO.allActivePartyMembers;
        allPartyMembers = playerPartySO.allPartyMembers;
        for (int i = 0; i < allPartyMembers.Count; i++) {
            GameObject instantiatedPartyMemberIcon = Instantiate(partyMemberIcon, content);
            allInstantiatedPartyMemberIcons.Add(instantiatedPartyMemberIcon);
            PartyManagerPartyMemberIcon script = instantiatedPartyMemberIcon.GetComponent<PartyManagerPartyMemberIcon>();
            script.SetInfo(allPartyMembers[i]);
            if (activeParty.Contains(allPartyMembers[i])) {
                script.SetInParty(inParty);
            }
        }
        for (int i = 0; i < activeMembersImages.Count; i++) {
            activeMembersImages[i].SetPosition(inParty, i);
            if (activeParty[i] != null) {
                activeMembersImages[i].SetPartyMemberImage(activeParty[i]);
            } else {
                activeMembersImages[i].ResetData();
            }
        }
    }

    public void AddPlayerToActiveParty(Component component, object obj) {
        object[] temp = (object[])obj;
        PlayerSO player = (PlayerSO) temp[0];
        if (activeParty.Contains(player)) {
            int posOfPlayer = activeParty.IndexOf(player);
            activeMembersImages[posOfPlayer].ResetData();
            playerPartySO.allActivePartyMembers[posOfPlayer] = null;
            if (activeParty[slotLookingAt] != null) {
                PlayerSO currentPlayer = activeParty[slotLookingAt];
                activeMembersImages[posOfPlayer].SetPartyMemberImage(currentPlayer);
                playerPartySO.allActivePartyMembers[posOfPlayer] = currentPlayer;
            }
            playerPartySO.allActivePartyMembers[slotLookingAt] = player;
        }
        activeMembersImages[slotLookingAt].SelectThePlayer(player, (PartyManagerPartyMemberIcon) component);
        playerPartySO.AddPlayerToActiveParty(player, slotLookingAt);
    }

    public void SetPlayerSlotLookingAt(Component component, object obj) {
        object[] temp = (object[])obj;
        int slot = (int) temp[0];
        this.slotLookingAt = slot;
        Debug.Log(slotLookingAt);
    }
    
}
