using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public CrossObjectEventWithData typeOfAttack;
    private bool canAttack = false;

    void Start() {
        DisableAttack();
    }

    void OnAttack(InputValue value) {
        if (canAttack) {
            typeOfAttack.TriggerEvent(this, value.Get<float>());
        }
    }

    public void EnableAttack() {
        canAttack = true;
    }

    public void DisableAttack() {
        canAttack = false;
    }

    void OnSwitch(InputValue value) {
        Debug.Log(value);
    }
}
