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
    private ConstructionMouse constructionMouse;

    private void Update() {
        if (!isMouseWithinBuildableRange()) return;
        if (constructionMouse.IsMouseButtonPressed(MouseButton.Left) 
        && activeBuildable != null && constructionLayer != null) {
            constructionLayer.Build(constructionMouse.MousePositionInWorldPosition, activeBuildable);
        }
    }

    private bool isMouseWithinBuildableRange() {
        return Vector3.Distance(constructionMouse.MousePositionInWorldPosition, transform.position) <= maxBuildingDistance;
    }
}
