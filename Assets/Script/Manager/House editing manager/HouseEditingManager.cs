using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseEditingManager : MonoBehaviour
{
    public PlayerInventorySO playerInventorySO;
    public Transform content;
    public GameObject furnitureIcon;
    private List<GameObject> allSpawnedIcons = new List<GameObject>();

    public void PopulateFurnitureUI() {
        foreach (GameObject instantiatedIcon in allSpawnedIcons)
        {
            Destroy(instantiatedIcon);
        }
        allSpawnedIcons.Clear();
        List<BuildableSO> allFurniture = playerInventorySO.allFurniture.ReturnKeys();
        foreach (BuildableSO furnitureSO in allFurniture)
        {
            GameObject instantiatedFurnitureIcon = Instantiate(furnitureIcon, content);
            instantiatedFurnitureIcon.GetComponent<FurnitureIconHouseEditing>().SetInfo(furnitureSO, playerInventorySO.allFurniture[furnitureSO]);
            allSpawnedIcons.Add(instantiatedFurnitureIcon);
        }
    }
}
