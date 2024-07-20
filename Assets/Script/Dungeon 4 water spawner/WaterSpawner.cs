using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    public GameObject dropletFish;
    public Transform spawnPoint;
    public CrossObjectEventWithData broadcastSpawnedDroplet;
    
    public void SpawnEnemy() {
        GameObject spawnedObject = Instantiate(dropletFish, spawnPoint);
        spawnedObject.transform.SetParent(null);
        spawnedObject.transform.position = spawnPoint.transform.position;
        spawnedObject.transform.localScale = new Vector3(1f, 1f, 1f);
        broadcastSpawnedDroplet.TriggerEvent(this, spawnedObject);
        Destroy(this.gameObject);
    }
}
