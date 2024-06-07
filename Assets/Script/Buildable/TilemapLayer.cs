using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class TilemapLayer : MonoBehaviour
{
    protected Tilemap tilemap;

    protected void Awake() {
        tilemap = GetComponent<Tilemap>();
    }
}
