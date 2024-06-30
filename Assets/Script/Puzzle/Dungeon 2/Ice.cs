using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ice : OneTimeObject, Interactables
{
    public GameObject whateverIsToBeSpawned;
    public Transform spawnPoint;
    public GameObject interactPrompt;
    private Animator anime;
    private bool canInteract = false;
    public CrossObjectEvent showMatchstick;
    public CrossObjectEvent hideMatchstick;
    public CrossObjectEventWithData useMatchstick;
    public TextMeshProUGUI matchstickNeeded;

    void Start() {
        IceSO matchstickSO = (IceSO) onetimeObjectSO;
        matchstickSO.SetMatchstickNeeded(matchstickNeeded);
        anime = GetComponent<Animator>();
        InteractableNPCWithRequest interactableNPC = whateverIsToBeSpawned.GetComponent<InteractableNPCWithRequest>();
        if (interactableNPC != null) {
            if (interactableNPC.CheckIfFulfilled()) {
                Spawn();
            }
        }
        base.Start();
    }

    public void Interact() {
        if (canInteract) {
            useMatchstick.TriggerEvent(this, ((IceSO) onetimeObjectSO).matchstickNeeded);
        }
        // anime.SetTrigger("Open");
    }

    void OnTriggerEnter2D(Collider2D other) {
        showMatchstick.TriggerEvent();
        interactPrompt.SetActive(true);
    } 

    void OnTriggerExit2D(Collider2D other) {
        hideMatchstick.TriggerEvent();
        interactPrompt.SetActive(false);
    } 

    public void CheckIfEnough(int amt) {
        IceSO matchstickSO = (IceSO) onetimeObjectSO;
        if (matchstickSO.CheckIfEnough(amt)) {
            canInteract = true;
        } else {
            canInteract = false;
        }
    }

    public void Spawn() {
        SetComplete();
        Instantiate(whateverIsToBeSpawned, spawnPoint.position, spawnPoint.rotation);
        Destroy(this.gameObject);
    }
}
