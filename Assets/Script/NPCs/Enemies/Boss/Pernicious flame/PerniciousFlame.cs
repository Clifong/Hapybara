using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerniciousFlame : Boss
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
            broadcastAchievementGained.TriggerEvent(this, allAchievementObtainable);
            Destroy(this.gameObject);
        } else {
            enemySO = bossPhaseSO[phase]; 
            SetStats(enemySO.health, enemySO.attack, enemySO.defence, enemySO.speed);
            broadcastMessage.TriggerEvent(this, "Pernicious flame wants to play a game!", startFirstGame);   
            AlertHealthChange();   
            moveToFirstGame.TriggerEvent(); 
        }
    }

    public void FirstGameFail() {
        Debug.Log(currAttack);
        currAttack += 20;
        Debug.Log(currAttack);
    }

    public void SecondGameFail() {
        Debug.Log(maxHealth);
        maxHealth += 300;
        currHealth = maxHealth;
        Debug.Log(maxHealth);
    }

    public void ThirdGameFail() {
        Debug.Log(currDefence);
        currDefence += 20;
        Debug.Log(currDefence);
    }

}

