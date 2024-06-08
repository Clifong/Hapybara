using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GameInput;

public class BuildingSelector : MonoBehaviour
{
    [SerializeField]
    private List<BuildableSO> buildables;

    [SerializeField]
    private BuildingPlacer buildingPlacer;

    private int activeBuildingIndex;

    private void OnEnable() {
        InputInHome.instance.Input.NextItem.performed += OnNextItemPerformed;
    }

    private void OnNextItemPerformed(InputAction.CallbackContext ctx) {
        NextItem();
    }

    private void NextItem() {
        activeBuildingIndex = (activeBuildingIndex + 1) % buildables.Count;
        buildingPlacer.SetActiveBuildable(buildables[activeBuildingIndex]);
    }
}
