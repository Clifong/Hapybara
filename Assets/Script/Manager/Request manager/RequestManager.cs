using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequestManager : MonoBehaviour
{
    public PlayerInventorySO playerInventorySO;
    public Transform myContent;
    public Transform requestContent;
    public GameObject requestPanel;
    public GameObject okButton;
    private List<GameObject> allSpawnedPanels = new List<GameObject>();
    private InteractableNPCWithRequest npc;

    public void PopulateInfo(Component component, object obj) {
        npc = (InteractableNPCWithRequest) component;
        foreach (GameObject spawnedRequestPanel in allSpawnedPanels)
        {
            Destroy(spawnedRequestPanel);
        }
        allSpawnedPanels.Clear();
        object[] temp = (object[])obj;
        List<FoodSO> requestFood = (List<FoodSO>)temp[0];
        List<int> requestFoodQty = (List<int>)temp[1];
        for (int i = 0; i < requestFood.Count; i++)
        {
            FoodSO foodSO = requestFood[i];
            int qty = requestFoodQty[i];
            GameObject spawnedRequestPanel = Instantiate(requestPanel, requestContent);
            allSpawnedPanels.Add(spawnedRequestPanel);
            spawnedRequestPanel.GetComponent<RequestPanel>().SetFoodSO(foodSO, qty);

            int myQty = playerInventorySO.GetFoodQty(foodSO);
            if (myQty != -1) {
                GameObject mySpawnedRequestPanel = Instantiate(requestPanel, myContent);
                allSpawnedPanels.Add(mySpawnedRequestPanel);
                mySpawnedRequestPanel.GetComponent<RequestPanel>().SetFoodSO(foodSO, myQty);
            }
        }
        bool canExchange = CheckIfCanExchange(requestFood, requestFoodQty);
        if (!canExchange) {
            okButton.SetActive(false);
        } else {
            okButton.SetActive(true);
        }
    }

    public bool CheckIfCanExchange(List<FoodSO> allFood, List<int> quantityNeeded) {
        for (int i = 0; i < allFood.Count; i++)
        {
            FoodSO foodSO = allFood[i];
            int qty = quantityNeeded[i];

            int myQty = playerInventorySO.GetFoodQty(foodSO);
            if (myQty == -1 || myQty < qty) {
                return false;
            }
        }
        return true;
    }

    public void CompleteRequest() {
        npc.SatisfyRequest();
    }
}
