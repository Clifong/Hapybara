using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaliciousObelisk : Boss
{
    public List<Transform> defomedObeliskSpawnpoint;
    public GameObject deformedObelisk;
    private CircleCollider2D circleCollider2D;
    private int deathCounter = 0;
    private Animator anime;
    public CrossObjectEventWithData broadcastMessage;

    void Awake() {
        updateHealthBar = healthBar;
        deathCounter = 0;
        phase = 0;
        enemySO = bossPhaseSO[phase];
        SetStats(enemySO.health, enemySO.attack, enemySO.defence, enemySO.speed);    
        circleCollider2D = GetComponent<CircleCollider2D>();
        anime = GetComponent<Animator>();
    }

    public override void Die() {
        phase += 1;
        if (phase == bossPhaseSO.Count) {
            characterDied.TriggerEvent(this, this);
            dropLoot.TriggerEvent(this, enemySO);
            Destroy(this.gameObject);
        } else {
            enemySO = bossPhaseSO[phase];
            foreach (Transform position in defomedObeliskSpawnpoint)
            {
                Instantiate(deformedObelisk, position);
            }
            circleCollider2D.enabled = false;
            SetStats(enemySO.health, enemySO.attack, enemySO.defence, enemySO.speed);    
            AlertHealthChange();    
            anime.SetBool("Fly", true); 
            broadcastMessage.TriggerEvent(this, "Defeat the deformed obelisk for the malicious obelisk to return!");
        }
    }

    public void IncrementDeathCounter() {
        deathCounter += 1;
        if (deathCounter >= defomedObeliskSpawnpoint.Count) {
            circleCollider2D.enabled = true;
            anime.SetBool("Fly", false); 
        }
    }
}
