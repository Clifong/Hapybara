using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewLayer : TilemapLayer
{
    [SerializeField]
    private SpriteRenderer previewRenderer;

    public void ShowPreview(BuildableSO buildableSO, Vector3 worldCoord, bool isValid) {
        var coord = tilemap.WorldToCell(worldCoord);
        previewRenderer.enabled = true;
        previewRenderer.transform.position = tilemap.CellToWorld(coord) + tilemap.cellSize/2 + buildableSO.tileOffset;
        previewRenderer.sprite = buildableSO.previewSprite;
        previewRenderer.color = isValid ? new Color(0, 1, 0, 0.5f) : new Color(1, 0, 0, 0.5f);
    }

    public void ClearPreview() {
        previewRenderer.enabled = false;
    }
}
