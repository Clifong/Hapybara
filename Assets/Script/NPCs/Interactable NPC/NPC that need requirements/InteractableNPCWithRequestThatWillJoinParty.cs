using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPCWithRequestThatWillJoinParty : InteractableNPCWithRequest
{
    public CrossObjectEventWithData joinParty;
    public PlayerSO playerSO;
    public override void Interact() {
        if (counter >= allRequest.Count) {
            joinParty.TriggerEvent(this, playerSO);
            Destroy(this.gameObject);
            return;
        }
        NPCRequestSO request = allRequest[counter];
        if (request is NPCRequestFoodSO) {
            ((NPCRequestFoodSO) request).Invoke(this);
        }
    }
}
