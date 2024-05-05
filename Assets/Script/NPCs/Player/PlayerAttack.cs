using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public CrossObjectEventWithData typeOfAttack;

    void Start() {
        this.enabled = false;
    }

    void OnAttack(InputValue value) {
        if (this.enabled) {
            typeOfAttack.TriggerEvent(this, value.Get<float>());
        }
    }
}
