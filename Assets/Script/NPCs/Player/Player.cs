using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Npc
{
    public PlayerSO playerSO;
    private bool interact = false;
    private Interactables interactable = null;
    private UpdateHealthBar updateHealthBar;

    void Awake() {
        updateHealthBar = GetComponentInChildren<UpdateHealthBar>();
        SetStats(playerSO.health, playerSO.attack, playerSO.defence, playerSO.speed);  
        AlertHealthChange();  
    }

    public void AlertHealthChange() {
        updateHealthBar.UpdateHealthBarInfo(GetHealthInfo()[0], GetHealthInfo()[1]);
    }

    public override void GetAttacked(int damage) {
        base.GetAttacked(damage);
        AlertHealthChange();
    }

    public override void UpdateStats(Component component, object obj) {
        base.UpdateStats(component, obj);
        AlertHealthChange();
    }

    public override void Attack(List<Npc> opponentList) {
        broadCastActionEvent.TriggerEvent(this, "The player attacked enemy");
        base.Attack(opponentList);
    }

    public override void Attack(List<Npc> opponentList, int attackType) {
        if (attackType == -1) {
            Debug.Log("Basic attack");
            Attack(opponentList);
        } else if (attackType == 1) {
            Debug.Log("Special attack! (To implement)");
            Attack(opponentList);
        }
    }

    public void OnInteract() {
        if (interactable != null) {
            interactable.Interact();
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        interactable = other.gameObject.GetComponent<Interactables>();
    }

    public void OnTriggerExit2D(Collider2D other) {
        interactable = null;
    }
}
