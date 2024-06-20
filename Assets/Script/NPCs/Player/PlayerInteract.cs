using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private bool interact = false;
    private Interactables interactable = null;

    public void OnInteract() {
        if (interactable != null) {
            interactable.Interact();
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        interactable = other.gameObject.GetComponent<Interactables>();
    }

    public void OnTriggerExit2D(Collider2D other) {
        interactable = null;
    }
}
