using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class ConstructionLayer : TilemapLayer
{
    public HouseStateSO houseStateSO;
    private Dictionary<Vector3Int, Buildable> buildables = new();

    private void Start() {
        Debug.Log(houseStateSO.buildables.Keys.Count);
        foreach (Vector3Int coord in houseStateSO.buildables.ReturnKeys())
        {
            if (houseStateSO.buildables[coord] != null) {
                Build(coord, houseStateSO.buildables[coord]);
            }
        }
    }

    public void Save() {
        foreach (Vector3Int coord in houseStateSO.buildables.ReturnKeys())
        {
            if (houseStateSO.buildables[coord] == null) {
                houseStateSO.buildables.Remove(coord);
            }
        }
        foreach (Vector3Int coord in buildables.Keys)
        {
            houseStateSO.buildables[coord] = buildables[coord].buildableType;
        }
        EditorUtility.SetDirty(houseStateSO);
    }

    public void Build(Vector3 worldCoord, BuildableSO furniture) {

        GameObject furnitureObject = null;
        var coord = tilemap.WorldToCell(worldCoord);
        
        if (furniture.tile != null) {
            var tileChangeData = new TileChangeData(
                coord,
                furniture.tile,
                Color.white,
                Matrix4x4.Translate(furniture.tileOffset) 
                );
            tilemap.SetTile(tileChangeData, false);
        }

        if (furniture.gameObject != null) {
            furnitureObject = Instantiate(
                furniture.gameObject,
                tilemap.CellToWorld(coord) + tilemap.cellSize/2 + furniture.tileOffset,
                Quaternion.identity
            );
        }

        var buildable = new Buildable(furniture, coord, tilemap, furnitureObject);
        buildables.Add(coord, buildable);
    }

    public void Destroy(Vector3 worldCoord, CrossObjectEventWithData changeBuildableQty) {
        var coord = tilemap.WorldToCell(worldCoord);
        if (!buildables.ContainsKey(coord)) return;

        var buildable = buildables[coord]; 
        changeBuildableQty.TriggerEvent(this, buildable.buildableType, 1); 
        buildables.Remove(coord);
        houseStateSO.buildables[coord] = null;
        buildable.Destroy();
    }

    public bool IsEmpty(Vector3 worldCoord) {
        var coord = tilemap.WorldToCell(worldCoord);
        return !buildables.ContainsKey(coord) && tilemap.GetTile(coord) == null;
    }
    
}
