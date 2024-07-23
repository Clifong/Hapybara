using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    protected int phase = 0;
    public List<EnemySO> bossPhaseSO;
    public UpdateHealthBar healthBar;
    public List<AchievementSO> allAchievementObtainable = new List<AchievementSO>();
    public CrossObjectEventWithData broadcastAchievementGained;

    void Awake() {
        updateHealthBar = healthBar;
        phase = 0;
        enemySO = bossPhaseSO[phase];
        SetStats(enemySO.health, enemySO.attack, enemySO.defence, enemySO.speed);         
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
            AlertHealthChange();        
        }
    }

    public override void GetAttacked(int damage) {
        spawnDamageTextScript.SpawnText(damage);
        currHealth -= damage;
        AlertHealthChange();
        if (currHealth <= 0) {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D) {
        updateHealthBar.gameObject.SetActive(true);
        if (updateStatusAlinmentIcon == null) {
            updateStatusAlinmentIcon = GetComponentInChildren<UpdateStatusAlinmentIcon>();
        }     
        AlertHealthChange();  
        base.OnTriggerEnter2D(collider2D);
    }

    void OnTriggerExit2D(Collider2D collider2D) {
        updateHealthBar.gameObject.SetActive(false);
        base.OnTriggerExit2D(collider2D);
    }
}
