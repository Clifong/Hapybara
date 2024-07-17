using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueFlame : MonoBehaviour, Interactables
{
    public CrossObjectEvent wrongAnswer;
    public GameObject interactPrompt;

    public virtual void Interact() {
        wrongAnswer.TriggerEvent();
        DestroyFlame();
    }

    void OnTriggerEnter2D(Collider2D other) {
        interactPrompt.SetActive(true);
    } 

    void OnTriggerExit2D(Collider2D other) {
        interactPrompt.SetActive(false);
    } 

    public void DestroyFlame() {
        Destroy(this.gameObject);
    }
}
