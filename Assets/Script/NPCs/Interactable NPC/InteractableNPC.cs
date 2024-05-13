using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : Npc, Interactables 
{
    public GameObject interactPrompt;
    private bool canInteract = false;

    public virtual void Interact() {}

    void OnTriggerEnter2D(Collider2D other) {
        interactPrompt.SetActive(true);
    } 

    void OnTriggerExit2D(Collider2D other) {
        interactPrompt.SetActive(false);
    } 

}
