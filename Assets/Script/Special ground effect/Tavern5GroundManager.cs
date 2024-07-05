using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tavern5GroundManager : MonoBehaviour
{
    public GameObject ripples;
    public GameObject colldierObject;
    private Tilemap tilemap;

    void Start() {
        tilemap = GetComponent<Tilemap>();
        // tilemap.CompressBounds();
        BoundsInt bounds = tilemap.cellBounds;
        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {   
            TileCollider tileCollider = Instantiate(colldierObject, pos, Quaternion.identity).GetComponent<TileCollider>();
            tileCollider.SetTilemap(this);
        }
    }

    public void Spawn(Vector3 position) {
        Instantiate(ripples, position, Quaternion.identity);
    }

    
}
