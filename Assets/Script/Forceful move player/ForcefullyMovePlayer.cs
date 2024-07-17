using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcefullyMovePlayer : MonoBehaviour
{
    private GameObject playerQueue;

    void Start() {
        playerQueue = ((PlayerQueue[]) GameObject.FindObjectsOfType<PlayerQueue>())[0].gameObject;
    }

    public void MovePlayer() {
       
        playerQueue.transform.position = gameObject.transform.position;
    }
}
