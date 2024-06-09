using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GameInput;

public class BuildingSelector : MonoBehaviour
{

    [SerializeField]
    private BuildingPlacer buildingPlacer;

    private int activeBuildingIndex;

    public void SetBuildable(Component component, object obj) {
        object[] temp = (object[])obj;
        BuildableSO furniture = (BuildableSO)temp[0];
        int qty = (int)temp[1];
        buildingPlacer.SetActiveBuildable(furniture, qty);
    }

}
