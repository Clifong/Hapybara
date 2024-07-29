using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCube : OneTimeObject, Interactables
{
    public GameObject whateverIsToBeSpawned;
    public Transform spawnPoint;
    public ChestSO chestContents;
    public CrossObjectEventWithData fillCanal;
    public Vector3Int startingPoint;
    public Vector3Int endPoint;
    public GameObject interactPrompt;
    public Sprite active;
    public CircleCollider2D circleCollider2D;
    public bool activeCube;
    public SpriteRenderer spriteRenderer;
    public List<LavaCube> cubesThatDependsOnMe = new List<LavaCube>();

    void Start() {
        if (onetimeObjectSO.complete) {
            activeCube = true;
            Activate();
            Interact();
        }
        else if (activeCube) {
            Activate();
        }
    }

    public void Activate() {
        spriteRenderer.sprite = active;
    }

    public void Interact() {
        if (spriteRenderer.sprite == active) {
            fillCanal.TriggerEvent(this, startingPoint, endPoint);
            SetComplete();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (spriteRenderer.sprite == active) {
            interactPrompt.SetActive(true);
        }
    } 

    void OnTriggerExit2D(Collider2D other) {
        interactPrompt.SetActive(false);
    } 

    public void ReachEnd() {
        circleCollider2D.enabled = false;
        Destroy(interactPrompt);
        if (cubesThatDependsOnMe.Count == 0) {
            Spawn();
            return;
        }
        foreach (LavaCube cube in cubesThatDependsOnMe)
        {
            cube.Activate();
        }
    }

    public void Spawn() {
        SetComplete();
        if (whateverIsToBeSpawned != null) {
            GameObject spawnedObject = Instantiate(whateverIsToBeSpawned, spawnPoint.position, spawnPoint.rotation);
            Chest chest = spawnedObject.GetComponent<Chest>();
            if (chest != null) {
                chest.SetContent(chestContents);
            }
            spawnedObject.transform.SetParent(null);
            spawnedObject.transform.position = spawnPoint.transform.position;
            spawnedObject.transform.localScale = new Vector3(1f, 1f, 1f);
            Instantiate(whateverIsToBeSpawned, spawnPoint.position, spawnPoint.rotation);
        }
    }

    protected override void SetComplete() {
        if (onetimeObjectSO != null) {
            onetimeObjectSO.SetComplete();
            onetimeObjectSO.SetDirty();
        }
    }
}
