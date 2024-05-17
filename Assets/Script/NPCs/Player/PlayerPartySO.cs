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

    
}
