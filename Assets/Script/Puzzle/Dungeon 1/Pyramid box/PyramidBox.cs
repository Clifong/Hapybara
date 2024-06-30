using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidBox : OneTimeObject
{
    public GameObject whateverIsToBeSpawned;
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
        Destroy(this.gameObject);
    }
}
