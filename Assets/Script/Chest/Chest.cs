using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Chest : OneTimeObject, Interactables
{
    public ChestSO chestSO;
    public GameObject interactPrompt;
    private bool canInteract = false;
    public CrossObjectEventWithData addChestItemToInventory;
    private Animator anime;

    void Start() {
        chestSO.CheckIfComplete(this, associatedObject);
    }

    public void SetContent(ChestSO chestSO) {
        this.chestSO = chestSO;
    }

    public void Interact() {
        SetComplete();
        anime = GetComponentInChildren<Animator>();
        anime.SetTrigger("Open");
        addChestItemToInventory.TriggerEvent(this, chestSO);
    }

    protected override void SetComplete() {
        chestSO.SetComplete();
        chestSO.SetDirty();
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

    public void DestroyChest() {
        Destroy(this.gameObject);
    }

}
