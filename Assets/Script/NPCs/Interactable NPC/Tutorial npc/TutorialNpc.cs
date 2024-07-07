using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialNpc : InteractableNPC
{
    private int counter = 0;
    public List<CrossObjectEvent> allEvent;

    public override void Interact() {
        allEvent[counter].TriggerEvent();
    }
        
    
}
