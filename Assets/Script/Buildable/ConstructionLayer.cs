using UnityEngine;
using UnityEngine.Tilemaps;

public class ConstructionLayer : TilemapLayer
{
    public void Build(Vector3 worldCoord, BuildableSO furniture) {
        var coord = tilemap.WorldToCell(worldCoord);
        if (furniture.tile != null) {
            var tileChangeDelta = new TileChangeData(
                coord,
                furniture.tile,
                Color.white,
                Matrix4x4.Translate(furniture.tileOffset) 
                );
            tilemap.SetTile(tileChangeDelta, false);
        }
    }
}
