using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    private BuildableSO activeBuildable;
    private int qtyAllowed;
    private float maxBuildingDistance = 5f;

    [SerializeField]
    private ConstructionLayer constructionLayer;

    [SerializeField]
    private PreviewLayer previewLayer;

    [SerializeField]
    private ConstructionMouse constructionMouse;
    public CrossObjectEventWithData changeBuildableQty;

    private void Update() {

        if (!isMouseWithinBuildableRange() || qtyAllowed <= 0) {
            previewLayer.ClearPreview();
            return;
        } 

        if (constructionLayer == null) return;

        var mousePos = constructionMouse.MousePositionInWorldPosition;
        if (constructionMouse.IsMouseButtonPressed(MouseButton.Right)) {
            constructionLayer.Destroy(mousePos, changeBuildableQty);
        }

        if (activeBuildable == null) return;
        
        previewLayer.ShowPreview(activeBuildable, mousePos, constructionLayer.IsEmpty(constructionMouse.MousePositionInWorldPosition));

        if (constructionMouse.IsMouseButtonPressed(MouseButton.Left) 
        && activeBuildable != null && constructionLayer.IsEmpty(mousePos)) {
            changeBuildableQty.TriggerEvent(this, activeBuildable, -1);
            constructionLayer.Build(mousePos, activeBuildable);
            qtyAllowed -= 1;
        }
    }

    private bool isMouseWithinBuildableRange() {
        return Vector2.Distance(constructionMouse.MousePositionInWorldPosition, transform.position) <= maxBuildingDistance;
    }

    public void SetActiveBuildable(BuildableSO activeFurniture, int qty) {
        activeBuildable = activeFurniture;
        qtyAllowed = qty;
    }
}
