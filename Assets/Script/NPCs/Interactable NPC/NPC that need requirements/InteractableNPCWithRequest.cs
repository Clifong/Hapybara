using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPCWithRequest : InteractableNPC
{
    public List<NPCRequestSO> allRequest;
    [TextAreaAttribute]
    public List<string> allDialogueText;
    protected int counter = 0;

    public override void Interact() {
        if (counter >= allRequest.Count) {
            Destroy(this.gameObject);
            return;
        }
        NPCRequestSO request = allRequest[counter];
        if (request is NPCRequestFoodSO) {
            ((NPCRequestFoodSO) request).Invoke(this);
        }
    }

    public void SatisfyRequest() {
        NPCRequestSO request = allRequest[counter];
        if (request is NPCRequestFoodSO) {
            ((NPCRequestFoodSO) request).SatisfyRequest(this);
        }
        counter += 1;
        Interact();
    }
}
