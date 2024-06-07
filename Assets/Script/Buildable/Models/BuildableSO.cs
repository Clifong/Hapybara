using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "BuildableSO", menuName = "Buildable SO", order = 1)]
public class BuildableSO : ScriptableObject
{
    public string name;
    public TileBase tile;
    public Vector3 tileOffset;
}
