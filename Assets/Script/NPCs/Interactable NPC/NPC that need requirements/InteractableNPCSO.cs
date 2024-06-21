using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableNPCSO", menuName = "Interactable NPC SO", order = 1)]
public class InteractableNPCSO : ScriptableObject
{
    public bool fulfilled = false;

    public void Fulfill() {
        fulfilled = true;
    }
}
