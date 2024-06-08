using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ConstructionLayer : TilemapLayer
{
    private Dictionary<Vector3Int, Buildable> buildables = new();
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

    public void Destroy(Vector3 worldCoord) {
        var coord = tilemap.WorldToCell(worldCoord);
        if (!buildables.ContainsKey(coord)) return;

        var buildable = buildables[coord];  
        buildables.Remove(coord);
        buildable.Destroy();
    }

    public bool IsEmpty(Vector3 worldCoord) {
        var coord = tilemap.WorldToCell(worldCoord);
        return !buildables.ContainsKey(coord) && tilemap.GetTile(coord) == null;
    }
}
