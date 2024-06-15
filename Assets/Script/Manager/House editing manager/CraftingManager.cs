using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public Transform content;
    public GameObject furniturePanel;
    private List<GameObject> furniturePanelList = new List<GameObject>();
    public PlayerUnlockedFurnitureSO unlockedFurnitureSO;
    public CrossObjectEventWithData addFurniture;
    public GameObject craftButton;
    private BuildableSO furnitureToBuilt;
    public CrossObjectEventWithData broadcastFurnitureSOToChangeButton;
    public CrossObjectEventWithData craftFurniture;

    public void InstantiateFurnitureIcon() {
        foreach (GameObject icon in furniturePanelList)
        {
            Destroy(icon);
        }
        furniturePanelList.Clear();
        foreach (BuildableSO furnitureSO in unlockedFurnitureSO.unlockedFurniture)
        {
            GameObject instantiatedFurniturePanel = Instantiate(furniturePanel, content);
            instantiatedFurniturePanel.GetComponent<FurnitureCraftingPanel>().SetFurnitureSO(furnitureSO);
            furniturePanelList.Add(instantiatedFurniturePanel);
        }
    }

    public void SetFurnitureToBuild(Component component, object obj) {
        object[] temp = (object[])obj;
        furnitureToBuilt = (BuildableSO) temp[0];
    }

    public void Craft() {
        addFurniture.TriggerEvent(this, furnitureToBuilt, 1);
        craftFurniture.TriggerEvent(this, furnitureToBuilt, 1);
        broadcastFurnitureSOToChangeButton.TriggerEvent(this, furnitureToBuilt);
    }

    public void EnableCraftButton(Component component, object obj) {
        object[] temp = (object[]) obj;
        bool canCraft = (bool) temp[0];
        craftButton.SetActive(canCraft);
    }
}
