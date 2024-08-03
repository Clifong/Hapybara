using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public CrossObjectEventWithData typeOfAttack;
    public CrossObjectEventWithData typeOfSkill;
    private bool canAttack = false;

    void Start() {
        DisableAttack();
    }

    void OnAttack(InputValue value) {
        if (canAttack) {
            typeOfAttack.TriggerEvent(this, value.Get<float>());
        }
    }

    void OnSkill1(InputValue value) {
        if (canAttack) {
            typeOfSkill.TriggerEvent(this, 0);
        }
    }

    void OnSkill2(InputValue value) {
        if (canAttack) {
            typeOfSkill.TriggerEvent(this, 1);
        }
    }

    void OnSkill3(InputValue value) {
        if (canAttack) {
            typeOfSkill.TriggerEvent(this, 2);
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
