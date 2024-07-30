using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidBox : OneTimeObject
{
    public GameObject whateverIsToBeSpawned;
    public ChestSO chestContents;
    public Transform spawnPoint;

    void Start() {
        Chest chest = whateverIsToBeSpawned.GetComponent<Chest>();
        if (chest != null) {
            chest.SetContent(chestContents);
        }
        base.Start();
    }

    void OnDestroy() {
        Spawn();
    }

    public void Spawn() {
        SetComplete();
        GameObject spawnedObject = Instantiate(whateverIsToBeSpawned, spawnPoint.position, spawnPoint.rotation);
        spawnedObject.transform.SetParent(null);
        spawnedObject.transform.position = spawnPoint.transform.position;
        spawnedObject.transform.localScale = new Vector3(1f, 1f, 1f);
        Destroy(this.gameObject);
    }
}
