using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopulateHouseCraftingPanel : MonoBehaviour
{
    public Image furnitureIcon;
    public TextMeshProUGUI furnitureName;
    public TextMeshProUGUI furnitureDescription;
    private BuildableSO furnitureSO;

    public void PopulateUI(Component component, object obj) {
        object[] temp = (object[]) obj;
        this.furnitureSO = (BuildableSO) temp[0];
        furnitureSO.SetUIInfo(furnitureIcon, furnitureName);
        furnitureDescription.text = furnitureSO.description;
    }

}
