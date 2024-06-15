using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInvitedPlayerManager : MonoBehaviour
{
    public Transform transform;

    public void SpawnPlayer(Component component, object obj) {
        object[] temp = (object[]) obj;
        PlayerSO player = (PlayerSO) temp[0];
        Dictionary<PlayerSO, GameObject> soToObject = (Dictionary<PlayerSO, GameObject>) temp[1];
        GameObject spanwedPlayer = Instantiate(player.homePlayerObject, transform);
        soToObject[player] = spanwedPlayer; 
    }
}
