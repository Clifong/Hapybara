using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAndDestroyObject : MonoBehaviour
{
    public CrossObjectEvent touchObjectEvent;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<Player>() != null) {
            touchObjectEvent.TriggerEvent();
            Destroy(this.gameObject);
        }
    }
}
