using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour, Interactables 
{
    public GameObject interactPrompt;
    public CrossObjectEvent interactWithStairs;
    public CrossObjectEventListener listener;
    private bool canInteract = false;

    public void Interact() {
        interactWithStairs.TriggerEvent();
    }

    void OnTriggerEnter2D(Collider2D other) {
        listener.enabled = true;
        interactPrompt.SetActive(true);
    } 

    void OnTriggerExit2D(Collider2D other) {
        listener.enabled = false;
        interactPrompt.SetActive(false);
    } 

}