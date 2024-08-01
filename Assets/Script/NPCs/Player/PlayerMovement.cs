using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 offset;
    private Rigidbody2D rb;
    public float speed;
    private SpriteRenderer[] spriteRenderers;

    void Start() {
        GetAllSpriteRenderer();
        rb = GetComponent<Rigidbody2D>();
    }

    public void GetAllSpriteRenderer() {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    void OnMove(InputValue value) {
        offset = value.Get<Vector2>();
        foreach (SpriteRenderer sr in spriteRenderers) {
            if (sr == null) {
                GetAllSpriteRenderer();
            } else {
                if (offset.x < 0) {
                    sr.flipX = true;
                } else if (offset.x > 0) {
                    sr.flipX = false;
                }
            } 
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + offset * speed);
    }

}
