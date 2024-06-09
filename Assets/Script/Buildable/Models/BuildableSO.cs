using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "BuildableSO", menuName = "Buildable SO", order = 1)]
public class BuildableSO : ScriptableObject
{
    public string name;
    public string description;
    public TileBase tile;
    public Vector3 tileOffset;
    public Sprite previewSprite;
    public GameObject gameObject;

    public void SetUIInfo(Image icon, TextMeshProUGUI nameText) {
        icon.sprite = previewSprite;
        nameText.text = name;
    }
}
