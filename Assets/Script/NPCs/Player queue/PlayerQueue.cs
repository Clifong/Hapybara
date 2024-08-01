using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQueue : MonoBehaviour
{
    private List<Transform> allPlayerSpawnPoint = new List<Transform>();
    private List<Player> spawnedPlayers = new List<Player>();
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
        foreach (Player spawnedPlayer in spawnedPlayers)
        {
            Destroy(spawnedPlayer.gameObject);
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
            spawnedPlayers.Add(spawnedPlayer.GetComponent<Player>());
            spawnedPlayer.gameObject.transform.SetParent(allPlayerSpawnPoint[i]);
        }
    }

    public List<Player> ReturnAllActivePlayer() {
        return spawnedPlayers;
    }

    public void DisableAttack() {
        foreach (Player player in spawnedPlayers)
        {
            if (player != null) {
                player.gameObject.GetComponent<PlayerAttack>().DisableAttack();
            }
        }
    }

    public void EnableAttack() {
        foreach (Player player in spawnedPlayers)
        {
            if (player != null) {
                player.gameObject.GetComponent<PlayerAttack>().EnableAttack();
            }
        }
    }

    public void CountDownBuffTimer() {
        foreach (Player player in spawnedPlayers)
        {
            if (player != null) {
                player.CountDownBuffTimer();
            }
        }
    }

    public void EmptyTummy() {
        foreach (Player player in spawnedPlayers)
        {
            if (player != null) {
                player.EmptyTummy();
            }
        }
    }


}
