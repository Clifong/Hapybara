using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTileMapColliderChecker : MonoBehaviour
{
    public List<GameObject> myColliders;

    void Start() {
        foreach (GameObject collider in myColliders)
        {
            collider.SetActive(false);
        }
    }
}
