using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "BuildableSO", menuName = "Buildable SO", order = 1)]
public class BuildableSO : ScriptableObject
{
    public string name;
    public string description;
    public TileBase tile;
    public Vector3 tileOffset;
    public Sprite previewSprite;
    public GameObject gameObject;
    [SerializedDictionary("Materials", "quantity")]
    public SerializedDictionary<MaterialSO, int> materialsNeeded;

    public void SetUIInfo(Image icon, TextMeshProUGUI nameText) {
        icon.sprite = previewSprite;
        nameText.text = name;
    }
    
    public void SetMaterialIcon(GameObject ingredientIcon, Transform content) {
        foreach (MaterialSO materialSO in materialsNeeded.ReturnKeys())
        {
            GameObject instantiatedIngredientIcon = Instantiate(ingredientIcon, content);
            instantiatedIngredientIcon.GetComponent<MaterialIcon>().PopulateMaterialIconInfo(materialSO, materialsNeeded[materialSO]);
        }
    }

    public void ReduceMaterial(PlayerInventorySO playerInventory) {
        foreach (MaterialSO material in materialsNeeded.ReturnKeys())
        {
            playerInventory.ReduceMaterial(material, materialsNeeded[material]);
        }
    }
}
