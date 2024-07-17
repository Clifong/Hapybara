using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour, Interactables
{
    public GameObject interactPrompt;
    private bool canInteract = false;
    private Animator anime;

    void Start() {
        anime = GetComponent<Animator>();
    }

    public void Interact() {
        anime.SetTrigger("Blast");
    }

    void OnTriggerEnter2D(Collider2D other) {
        interactPrompt.SetActive(true);
    } 

    void OnTriggerExit2D(Collider2D other) {
        interactPrompt.SetActive(false);
    } 

}
