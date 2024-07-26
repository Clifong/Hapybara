using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidBox : OneTimeObject
{
    public GameObject whateverIsToBeSpawned;
    public ChestSO chestContents;
    public Transform spawnPoint;

    void Start() {
        InteractableNPCWithRequest interactableNPC = whateverIsToBeSpawned.GetComponent<InteractableNPCWithRequest>();
        if (interactableNPC != null) {
            if (interactableNPC.CheckIfFulfilled()) {
                Spawn();
            }
        }
        base.Start();
    }

    public void Spawn() {
        SetComplete();
        Instantiate(whateverIsToBeSpawned, spawnPoint.position, spawnPoint.rotation);
        GameObject spawnedObject = Instantiate(whateverIsToBeSpawned, spawnPoint.position, spawnPoint.rotation);
        Chest chest = spawnedObject.GetComponent<Chest>();
        if (chest != null) {
            chest.SetContent(chestContents);
        }
        spawnedObject.transform.SetParent(null);
        spawnedObject.transform.position = spawnPoint.transform.position;
        spawnedObject.transform.localScale = new Vector3(1f, 1f, 1f);
        Destroy(this.gameObject);
    }
}
