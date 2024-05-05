using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingBonfire : MonoBehaviour, Interactables 
{
    public CrossObjectEvent interactWithPot;
    public GameObject interactPrompt;
    private bool canInteract = false;

    public void Interact() {
        interactWithPot.TriggerEvent();
    }

    void OnTriggerEnter2D(Collider2D other) {
        interactPrompt.SetActive(true);
    } 

    void OnTriggerExit2D(Collider2D other) {
        interactPrompt.SetActive(false);
    } 

}
