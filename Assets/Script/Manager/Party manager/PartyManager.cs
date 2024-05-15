using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyManager : MonoBehaviour
{
    public PlayerPartySO playerPartySO;
    private List<PlayerSO> activeParty;
    private List<PlayerSO> allPartyMembers;
    public List<Image> activeMembersImages;
    public GameObject partyMemberIcon;
    public Transform content;
    private List<GameObject> allInstantiatedPartyMemberIcons = new List<GameObject>();

    public void PopulateUI() {
        foreach (GameObject instantiatedPartyMemberIcon in allInstantiatedPartyMemberIcons)
        {
            Destroy(instantiatedPartyMemberIcon);
        }
        allInstantiatedPartyMemberIcons.Clear();
        activeParty = playerPartySO.allActivePartyMembers;
        allPartyMembers = playerPartySO.allPartyMembers;
        foreach (PlayerSO playerSO in allPartyMembers)
        {
            GameObject instantiatedPartyMemberIcon = Instantiate(partyMemberIcon, content);
            allInstantiatedPartyMemberIcons.Add(instantiatedPartyMemberIcon);
            instantiatedPartyMemberIcon.GetComponent<PartyManagerPartyMemberIcon>().SetInfo(playerSO);
        }
        for (int i = 0; i < activeParty.Count; i++)
        {
            if (activeParty[i] == null) {
                break;
            } else {
                activeMembersImages[i].sprite = activeParty[i].playerAppearance;
            }
        }
    }
    
}
