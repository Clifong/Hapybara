using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenBg : MonoBehaviour
{
    public Animator anime;
    public float chance;

    public void TriggerChance() {
        float random = Random.Range(0f, 1f);
        if (random >= chance) {
            anime.SetTrigger("Blow");
        }
    }
}
