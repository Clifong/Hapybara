using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blaster : MonoBehaviour, Interactables
{
    public GameObject interactPrompt;
    private bool canInteract = false;
    private Animator anime;
    private Slider gauge;
    private CircleCollider2D collider2D;
    public int damage;
    public CrossObjectEventWithData broadcastMessage;
    public CrossObjectEventWithData blastEnemy;
    private float amount;

    void Start() {
        anime = GetComponent<Animator>();
        gauge = GetComponentInChildren<Slider>();
        collider2D = GetComponent<CircleCollider2D>();
        gauge.value = 0;
        collider2D.enabled = false;
    }

    public void Interact() {
        anime.SetTrigger("Blast");
        amount -= 1.0f;
        gauge.value = Mathf.Min(amount, 1.0f);
        collider2D.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        interactPrompt.SetActive(true);
    } 

    void OnTriggerExit2D(Collider2D other) {
        interactPrompt.SetActive(false);
    } 

    public void BlastEnemy() {
        blastEnemy.TriggerEvent(this, damage);
    }

    public void FillGauge() {
        amount += 0.1f;
        gauge.value = Mathf.Min(amount, 1.0f);
        if (amount >= 1) {
            broadcastMessage.TriggerEvent(this, "Blaster is filled, try interacting with it");
            collider2D.enabled = true;
        }
    }

}
