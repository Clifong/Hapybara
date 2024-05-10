using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientObject : MonoBehaviour
{
    public GameObject waterSplash;
    void OnTriggerEnter2D(Collider2D other) {
        Instantiate(waterSplash, gameObject.transform);
        Destroy(gameObject);
    }
}
