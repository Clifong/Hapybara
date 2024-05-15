using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidBox : MonoBehaviour
{
    public GameObject whateverIsToBeSpawned;
    public Transform spawnPoint;
    
    public void Spawn() {
        Instantiate(whateverIsToBeSpawned, spawnPoint.position, spawnPoint.rotation);
        Destroy(this.gameObject);
    }
}
