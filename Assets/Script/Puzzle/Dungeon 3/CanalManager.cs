using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using AYellowpaper.SerializedCollections;

public class CanalManager : MonoBehaviour
{
    public Tilemap canalMap;
    [SerializedDictionary("Unfilled canal", "Filled canal")]
    public SerializedDictionary<TileBase, TileBase> tileMapping = new SerializedDictionary<TileBase, TileBase>();
    private Vector3Int specialEndPoint;

    public void BFSFill(Component component, object obj) {
        object[] temp = (object[])obj;
        Vector3Int position = (Vector3Int) temp[0];
        if (temp[1] != null) {
            specialEndPoint = (Vector3Int) temp[1];
        }
        Queue<Vector3Int> q = new Queue<Vector3Int>();
        List<Vector3Int> repeated = new List<Vector3Int>();
        q.Enqueue(position);
        while (q.Count != 0) {
            Vector3Int popped = q.Dequeue();

            if (popped == specialEndPoint) {
                canalMap.SetTile(popped, tileMapping[canalMap.GetTile(popped)]);
                ((LavaCube) component).ReachEnd();
                return;
            }

            if (repeated.Contains(popped)) {
                continue;
            }

            TileBase poppedTile = canalMap.GetTile(popped);
            repeated.Add(popped);
            if (poppedTile != null && tileMapping.ContainsKey(poppedTile)) {
                canalMap.SetTile(popped, tileMapping[poppedTile]);
                q.Enqueue(popped + new Vector3Int(-1, 0, 0));
                q.Enqueue(popped + new Vector3Int(1, 0, 0));
                q.Enqueue(popped + new Vector3Int(0, 1, 0));
                q.Enqueue(popped + new Vector3Int(0, -1, 0));
            }
        }
    }
}
