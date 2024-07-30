using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternPuzzleMaster : OneTimeObject, Interactables
{
    public List<LanternPuzzle> lanternSequence;
    public List<LanternPuzzle> allLantern;
    public ChestSO chestContents;
    public GameObject whateverIsToBeSpawned;
    public Transform spawnPoint;
    public GameObject interactPrompt;
    private bool canInteract = false;
    public CircleCollider2D circleCollider2D;
    private int presentCounter = 0;
    private int gameCounter = 0;
    public float timer;
    

    void Start() {
        Chest chest = whateverIsToBeSpawned.GetComponent<Chest>();
        if (chest != null) {
            chest.SetContent(chestContents);
        }
        base.Start();
    }

    void OnDestroy() {
        Spawn();
    }


    public void Interact() {
        circleCollider2D.enabled = false;
        presentCounter = 0;
        gameCounter = 0;
        DisableLantern();
        StartCoroutine(StartGame());
    }

    void OnTriggerEnter2D(Collider2D other) {
        interactPrompt.SetActive(true);
    } 

    void OnTriggerExit2D(Collider2D other) {
        interactPrompt.SetActive(false);
    } 

    public void Spawn() {
        SetComplete();
        GameObject spawnedObject = Instantiate(whateverIsToBeSpawned, spawnPoint.position, spawnPoint.rotation);
        spawnedObject.transform.SetParent(null);
        spawnedObject.transform.position = spawnPoint.transform.position;
        spawnedObject.transform.localScale = new Vector3(1f, 1f, 1f);
        Destroy(this.gameObject);
    }

    IEnumerator StartGame() {
        LanternPuzzle next = lanternSequence[presentCounter];
        next.Fill(this);
        yield return new WaitForSeconds(timer);
        lanternSequence[presentCounter].UnFill();
        presentCounter++;
        if (presentCounter >= lanternSequence.Count) {
            foreach (LanternPuzzle lantern in allLantern)
            {
                lantern.CanInteractWith();
            }
            StopAllCoroutines();
        } else {
            StartCoroutine(StartGame());
        }
    }

    public void DisableLantern() {
        foreach (LanternPuzzle lantern in allLantern)
        {
            lantern.CannotInteractWith();
            lantern.UnFill();
        }
    }

    public void InteractedWithLantern(LanternPuzzle lantern) {
        if (lantern != lanternSequence[gameCounter]) {
            circleCollider2D.enabled = true;
            DisableLantern();
        } else {
            gameCounter++;
            if (gameCounter >= 2) {
                lanternSequence[gameCounter - 2].UnFill();
            }
            if (gameCounter >= lanternSequence.Count) {
                Destroy(this.gameObject);
                DisableLantern();
            }
        }
    }
}
