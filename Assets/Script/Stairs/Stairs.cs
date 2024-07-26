using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour, Interactables 
{
    public GameObject interactPrompt;
    public CrossObjectEvent interactWithStairs;
    public LevelChangerHelper levelChangeHelper;
    private bool canInteract = false;

    public void Interact() {
        interactWithStairs.TriggerEvent();
        levelChangeHelper.ChangeLevel();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<PlayerInteract>() != null) {
            interactPrompt.SetActive(true);
        }
    } 

    void OnTriggerExit2D(Collider2D other) {
        if (other.GetComponent<PlayerInteract>() != null) {
            interactPrompt.SetActive(false);
        }
    } 

}