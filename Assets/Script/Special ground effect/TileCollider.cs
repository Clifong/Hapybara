using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCollider : MonoBehaviour
{
    private Tavern5GroundManager tileBody;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<Npc>() != null) {
            tileBody.Spawn(transform.position);
        }
    }

    public void SetTilemap(Tavern5GroundManager tavern5GroundManager) {
        tileBody = tavern5GroundManager;
    }
}
