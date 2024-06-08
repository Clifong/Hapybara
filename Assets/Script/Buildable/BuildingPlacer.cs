using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    public BuildableSO activeBuildable;
    private float maxBuildingDistance = 3f;

    [SerializeField]
    private ConstructionLayer constructionLayer;

    [SerializeField]
    private PreviewLayer previewLayer;

    [SerializeField]
    private ConstructionMouse constructionMouse;

    private void Update() {

        if (!isMouseWithinBuildableRange()) previewLayer.ClearPreview();

        if (constructionLayer == null) return;

        var mousePos = constructionMouse.MousePositionInWorldPosition;
        if (constructionMouse.IsMouseButtonPressed(MouseButton.Right)) {
            constructionLayer.Destroy(mousePos);
        }

        if (activeBuildable == null) return;
        
        previewLayer.ShowPreview(activeBuildable, mousePos, constructionLayer.IsEmpty(constructionMouse.MousePositionInWorldPosition));

        if (constructionMouse.IsMouseButtonPressed(MouseButton.Left) 
        && activeBuildable != null && constructionLayer.IsEmpty(mousePos)) {
            constructionLayer.Build(mousePos, activeBuildable);
        }
    }

    private bool isMouseWithinBuildableRange() {
        return Vector3.Distance(constructionMouse.MousePositionInWorldPosition, transform.position) <= maxBuildingDistance;
    }

    public void SetActiveBuildable(BuildableSO activeFurniture) {
        activeBuildable = activeFurniture;
    }
}
