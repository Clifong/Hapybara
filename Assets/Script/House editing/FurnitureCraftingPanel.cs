using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FurnitureCraftingPanel : MonoBehaviour
{
    public Image furnitureIcon;
    public TextMeshProUGUI furnitureName;
    private BuildableSO furnitureSO;
    public CrossObjectEventWithData broadcastFurnitureEvent;
    public GameObject materialIcon;
    public Transform content;

    public void SetFurnitureSO(BuildableSO furnitureSO) {
        this.furnitureSO = furnitureSO;
        furnitureSO.SetUIInfo(furnitureIcon, furnitureName);
        furnitureSO.SetMaterialIcon(materialIcon, content);
    }

    public void BroadcastFurnitureSOInfo() {
        broadcastFurnitureEvent.TriggerEvent(this, furnitureSO);
    }
}
