using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPyramid : MonoBehaviour
{
    public List<Transform> allSpawnPosition;
    public CrossObjectEvent pyramidCaught;
    private int counter = 0;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<Player>()) {
            if (counter == allSpawnPosition.Count) {
                pyramidCaught.TriggerEvent();
                Destroy(this.gameObject);
            }
            else {
                rb.transform.position = allSpawnPosition[counter].position;
            }
            counter++;
        }
    }
}
