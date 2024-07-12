using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    private int phase = 0;
    public List<EnemySO> bossPhaseSO;
    void Awake() {
        phase = 0;
        enemySO = bossPhaseSO[phase];
        updateHealthBar = GetComponentInChildren<UpdateHealthBar>();
        SetStats(enemySO.health, enemySO.attack, enemySO.defence, enemySO.speed);    
        AlertHealthChange();         
    }


    public override void Die() {
        phase += 1;
        if (phase == bossPhaseSO.Count) {
            dropLoot.TriggerEvent(this, enemySO);
            Destroy(this.gameObject);
        } else {
            enemySO = bossPhaseSO[phase];
        }
    }
}
