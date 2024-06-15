using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InviteManager : MonoBehaviour
{
    public PlayerPartySO playerPartySO;
    public GameObject invitePanel;
    public Transform content;
    private List<GameObject> inviteList = new List<GameObject>();
    private PlayerSO playerOfInterest = null;
    public CrossObjectEventWithData spawnInvitedPlayer;
    private Dictionary<PlayerSO, GameObject> soToObject = new Dictionary<PlayerSO, GameObject>();

    [Header("Invite or disincite segment")]
    public GameObject inviteSection;
    public GameObject disinviteSection;

    private void Start() {
        foreach (PlayerSO allPlayer in playerPartySO.allPartyMembers)
        {
            if (allPlayer.invited) {
                spawnInvitedPlayer.TriggerEvent(this, allPlayer, soToObject);
            }
        }
    }

    public void InstantiateInvitePanel() {
        foreach (GameObject instantiatedPanel in inviteList)
        {
            Destroy(instantiatedPanel);
        }
        inviteList.Clear();
        foreach (PlayerSO allPlayer in playerPartySO.allPartyMembers)
        {
            GameObject instantiatedPanel = Instantiate(invitePanel, content);
            instantiatedPanel.GetComponent<InvitePanel>().SetInfo(allPlayer);
            inviteList.Add(instantiatedPanel);
        }
    }

    public void PlayerToBeInvited(Component component, object obj) {
        object[] temp = (object[]) obj;
        playerOfInterest = (PlayerSO) temp[0];
        if (playerOfInterest.invited) {
            disinviteSection.SetActive(true);
        } else {
            inviteSection.SetActive(true);
        }
    }

    public void ActuallyInvite() {
        spawnInvitedPlayer.TriggerEvent(this, playerOfInterest, soToObject);
        playerOfInterest.invited = true;
        InstantiateInvitePanel();
    }

    public void Disinvite() {
        Destroy(soToObject[playerOfInterest]);
        soToObject.Remove(playerOfInterest);
        playerOfInterest.invited = false;
        InstantiateInvitePanel();
    }
}
