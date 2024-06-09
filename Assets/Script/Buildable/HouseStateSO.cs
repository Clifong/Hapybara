using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "HouseStateSO", menuName = "House state SO", order = 1)]
public class HouseStateSO : ScriptableObject
{
    [SerializedDictionary("Coordinates", "furniture")]
    public SerializedDictionary<Vector3Int, BuildableSO> buildables;
}
