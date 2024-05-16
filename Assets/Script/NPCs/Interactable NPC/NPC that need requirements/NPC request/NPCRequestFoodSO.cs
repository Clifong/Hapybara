using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "NPCRequestFoodSO", menuName = "NPC request/Food", order = 1)]
public class NPCRequestFoodSO : NPCRequestSO
{
    [SerializedDictionary("Food request", "quantity")]
    public SerializedDictionary<FoodSO, int> allFoodRequest;
    public CrossObjectEventWithData requestForFood;
    public CrossObjectEventWithData reduceFoodAndQuantity;

    public void Invoke(InteractableNPCWithRequest npc) {
        List<FoodSO> allFood = allFoodRequest.ReturnKeys();
        List<int> quantity = new List<int>();
        foreach (FoodSO foodSO in allFood)
        {
            quantity.Add(allFoodRequest[foodSO]);
        }
        requestForFood.TriggerEvent(npc, allFood, quantity);
    }

    public void SatisfyRequest(InteractableNPCWithRequest npc) {
        List<FoodSO> allFood = allFoodRequest.ReturnKeys();
        List<int> quantity = new List<int>();
        foreach (FoodSO foodSO in allFood)
        {
            quantity.Add(allFoodRequest[foodSO]);
        }
        reduceFoodAndQuantity.TriggerEvent(npc, allFood, quantity);
    }
}
