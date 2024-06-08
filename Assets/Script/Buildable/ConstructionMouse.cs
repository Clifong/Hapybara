using System;
using UnityEngine;
using UnityEngine.InputSystem;
using GameInput;

public enum MouseButton {
    Left, Right
}
public class ConstructionMouse : MonoBehaviour
{
    private InputInHome inputActions;
    private Vector3 mousePosition;
    public Vector2 MousePositionInWorldPosition => Camera.main.ScreenToWorldPoint(mousePosition);
    public bool leftMouseClicked;
    public bool rightMouseClicked;

    void OnEnable() {
        inputActions = InputInHome.instance;
        inputActions.Input.MousePosition.performed += OnMousePositionPerformed;
        inputActions.Input.PerformAction.performed += OnPerformActionPerformed;
        inputActions.Input.PerformAction.canceled += OnPerformActionCancelled;
        inputActions.Input.CancelAction.performed += OnCancelActionPerformed;
        inputActions.Input.CancelAction.canceled += OnCancelActionCancelled;
    }

    void OnDisable() {
        inputActions.Input.MousePosition.performed -= OnMousePositionPerformed;
        inputActions.Input.PerformAction.performed -= OnPerformActionPerformed;
        inputActions.Input.PerformAction.canceled -= OnPerformActionCancelled;
        inputActions.Input.CancelAction.performed -= OnCancelActionPerformed;
        inputActions.Input.CancelAction.canceled -= OnCancelActionCancelled;
    }

    private void OnMousePositionPerformed(InputAction.CallbackContext ctx) {
        mousePosition = ctx.ReadValue<Vector2>();
        mousePosition.z = 10;
    }

    private void OnPerformActionPerformed(InputAction.CallbackContext ctx) {
        leftMouseClicked = true;
    }

    private void OnPerformActionCancelled(InputAction.CallbackContext ctx) {
        leftMouseClicked = false;
    }

    private void OnCancelActionPerformed(InputAction.CallbackContext ctx) {
        rightMouseClicked = true;
    }

    private void OnCancelActionCancelled(InputAction.CallbackContext ctx) {
        rightMouseClicked = false;
    }


    public bool IsMouseButtonPressed(MouseButton button) {
        return button == MouseButton.Left ? leftMouseClicked : rightMouseClicked;
    }

}
