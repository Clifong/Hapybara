using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnDamageText : MonoBehaviour
{
    public GameObject damageText;
    public Transform spawnZone;

    public void SpawnText(int damage) {
        GameObject text = Instantiate(damageText, spawnZone);
        text.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
    }
}
