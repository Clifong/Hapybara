using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 offset;
    private Rigidbody2D rb;
    public float speed;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value) {
        offset = value.Get<Vector2>();
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + offset * speed);
    }

}
