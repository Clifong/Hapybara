using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternPuzzle : MonoBehaviour, Interactables
{
    public Animator anime;
    public CircleCollider2D circleCollider2D;
    public GameObject interactPrompt;
    private bool fill;
    private LanternPuzzleMaster master;

    void Start() {
        CannotInteractWith();
    }
    
    public void Fill(LanternPuzzleMaster master) {
        circleCollider2D.enabled = false;
        anime.SetBool("fill", true);
        this.master = master;
    }

    public void UnFill() {
        anime.SetBool("fill", false);
    }

    public void Interact() {
        master.InteractedWithLantern(this);
        anime.SetBool("fill", true);
    }

    void OnTriggerEnter2D(Collider2D other) {
        interactPrompt.SetActive(true);
    } 

    void OnTriggerExit2D(Collider2D other) {
        interactPrompt.SetActive(false);
    } 

    public void CanInteractWith() {
        circleCollider2D.enabled = true;
    }

    public void CannotInteractWith() {
        circleCollider2D.enabled = false;
    }
}
