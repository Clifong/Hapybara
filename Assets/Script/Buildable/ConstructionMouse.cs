using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum MouseButton {
    Left, Right
}
public class ConstructionMouse : MonoBehaviour
{
    private Vector2 mousePosition;
    public Vector2 MousePositionInWorldPosition => Camera.main.ScreenToWorldPoint(mousePosition);
    private bool leftMouseClicked;
    private bool rightMouseClicked;

    void OnMousePosition(InputValue value) {
        mousePosition = value.Get<Vector2>();
    }

    void OnPerformAction() {
        leftMouseClicked = true;
        Debug.Log(leftMouseClicked);
    }

    void OnCancelAction() {
        rightMouseClicked = true;
    }

    public bool IsMouseButtonPressed(MouseButton button) {
        return button == MouseButton.Left ? leftMouseClicked : rightMouseClicked;
    }

    void Update() {
        leftMouseClicked = false;
        rightMouseClicked = false;
    }
}
