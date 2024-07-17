using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgottenSpire : Boss
{
    private CircleCollider2D circleCollider2D;
    private Animator anime;
    public CrossObjectEventWithData broadcastMessage;
    public CrossObjectEvent moveToFirstGame;
    public CrossObjectEvent startFirstGame;

    void Awake() {
        updateHealthBar = healthBar;
        phase = 0;
        enemySO = bossPhaseSO[phase];
        SetStats(enemySO.health, enemySO.attack, enemySO.defence, enemySO.speed);    
        circleCollider2D = GetComponent<CircleCollider2D>();
        anime = GetComponentInChildren<Animator>();
    }

    public override void Die() {
        phase += 1;
        if (phase == bossPhaseSO.Count) {
            characterDied.TriggerEvent(this, this);
            dropLoot.TriggerEvent(this, enemySO);
            Destroy(this.gameObject);
        } else {
            enemySO = bossPhaseSO[phase]; 
            SetStats(enemySO.health, enemySO.attack, enemySO.defence, enemySO.speed);
            AlertHealthChange();   
        }
    }
}
