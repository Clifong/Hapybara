using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player party SO", menuName = "All player SO/Player party SO", order = 1)]
public class PlayerPartySO : ScriptableObject
{
    public List<PlayerSO> allActivePartyMembers;
    public List<PlayerSO> allPartyMembers;

    public void AddPlayerToActiveParty(PlayerSO player, int slot) {
        allActivePartyMembers[slot] = player;
    }

    public void AddPlayerToActiveParty(PlayerSO player) {
        if (!allPartyMembers.Contains(player)) {
            allPartyMembers.Add(player);
        } else {
            return;
        }
        if (!allActivePartyMembers.Contains(player)) {
            for (int i = 0; i < allActivePartyMembers.Count; i++) {
                if (allActivePartyMembers[i] == null) {
                    allActivePartyMembers[i] = player;
                    return;
                }
            }
        }
    }

    public int GetNumberOfActivePartyMembers() {
        int count = 0;
        for (int i = 0; i < allActivePartyMembers.Count; i++) {
                if (allActivePartyMembers[i] != null) {
                    count += 1;
                }
            }
        return count;
    }

    public void AddExpIndividually(int individualExp) {
        for (int i = 0; i < allActivePartyMembers.Count; i++) {
            if (allActivePartyMembers[i] != null) {
                allActivePartyMembers[i].GainExp(individualExp);
            }
        }
    }

    public void AddRelationshipExpIndividually(int individualExp) {
        for (int i = 0; i < allActivePartyMembers.Count; i++) {
            if (allActivePartyMembers[i] != null) {
                allActivePartyMembers[i].GainRelationshipExp(individualExp);
            }
        }
    }

    public void TownRecovery() {
        foreach (PlayerSO playerSO in allActivePartyMembers)
        {
            playerSO.RecoverMaxHealth();
        }
    }

    
}
