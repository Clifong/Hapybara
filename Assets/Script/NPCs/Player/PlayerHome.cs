using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHome : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private float time = 5.0f;
    private float speed = 1.0f;
    private Vector2 newPosition = Vector2.zero;


    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void RandomPosition() {
        float randomOffset = Random.Range(-3.0f, 3.0f);
        float randomOffset2 = Random.Range(-3.0f, 3.0f);
        newPosition = rigidbody2D.position + new Vector2(randomOffset, randomOffset2);
    }

    void Update() {
        time -= Time.deltaTime;
        rigidbody2D.position = Vector3.MoveTowards(rigidbody2D.position, newPosition, speed * Time.deltaTime);
        if (time <= 0) {
            RandomPosition();
            time = Random.Range(3.0f, 5.0f);
        }
    }
    
}
