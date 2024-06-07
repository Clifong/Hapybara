using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class Buildable
{
    public Tilemap parentTileMap;
    public BuildableSO buildableType;
    public GameObject gameObject;
    public Vector3Int coordinates;

    public Buildable(BuildableSO type, Vector3Int coords, Tilemap tilemap, GameObject gameObject = null) {
        parentTileMap = tilemap;
        buildableType = type;
        coordinates = coords;
        this.gameObject = gameObject;
    }
}
