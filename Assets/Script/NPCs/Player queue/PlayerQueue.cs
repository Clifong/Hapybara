using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQueue : MonoBehaviour
{
    private List<Transform> allPlayerSpawnPoint = new List<Transform>();
    private List<GameObject> spawnedPlayers = new List<GameObject>();
    public Transform spawnObject;
    public PlayerPartySO playerPartySO;

    void Awake() {
        float cumulativeDecrease = 0.0f;
        for (int i = 0; i < 5; i++) {
            Vector3 newPosition = new Vector3(this.transform.position.x - cumulativeDecrease, this.transform.position.y, this.transform.position.z);
            Transform spawnedPoint = Instantiate(spawnObject.gameObject, newPosition, Quaternion.identity).transform;
            spawnedPoint.SetParent(this.transform);
            allPlayerSpawnPoint.Add(spawnedPoint);
            cumulativeDecrease += 3.0f;
        }
        InstantiatePlayer();
    }

    public void InstantiatePlayer() {
        foreach (GameObject spawnedPlayer in spawnedPlayers)
        {
            Destroy(spawnedPlayer);
        }
        spawnedPlayers.Clear();
        List<PlayerSO> filteredOutPlayer = new List<PlayerSO>();
        foreach (PlayerSO playerSO in playerPartySO.allActivePartyMembers)
        {
            if (playerSO != null) {
                filteredOutPlayer.Add(playerSO);
            }
        }
        for (int i = 0; i < filteredOutPlayer.Count; i++)
        {
            GameObject spawnedPlayer = Instantiate(filteredOutPlayer[i].playerObject, allPlayerSpawnPoint[i]);
            if (i == 0) {
                spawnedPlayer.GetComponent<BoxCollider2D>().enabled = true;
            }
            else if (i > 0) {
                spawnedPlayer.GetComponent<BoxCollider2D>().enabled = false;
            }
            spawnedPlayers.Add(spawnedPlayer);
            spawnedPlayer.transform.SetParent(allPlayerSpawnPoint[i]);
        }
    }

    public List<Player> ReturnAllActivePlayer() {
        List<Player> allPlayers = new List<Player>();
        foreach (GameObject player in spawnedPlayers)
        {
            if (player != null) {
                allPlayers.Add(player.GetComponent<Player>());
            }
        }
        return allPlayers;
    }

    public void DisableAttack() {
        foreach (GameObject player in spawnedPlayers)
        {
            if (player != null) {
                player.GetComponent<PlayerAttack>().DisableAttack();
            }
        }
    }

    public void EnableAttack() {
        foreach (GameObject player in spawnedPlayers)
        {
            if (player != null) {
                player.GetComponent<PlayerAttack>().EnableAttack();
            }
        }
    }
}
