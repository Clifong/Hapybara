using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedTownNPC : MonoBehaviour
{
    public InteractableNPCSO interactableNPCSO;
    public GameObject npc;

    void Start() {
        if (interactableNPCSO.fulfilled) {
            Instantiate(npc, this.transform.position, Quaternion.identity);
        }
    }
}
