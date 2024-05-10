using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Npc : MonoBehaviour
{
    private int health;
    private int attack;
    private int defence;
    private int speed;
    private int currSpeed;
    public CrossObjectEventWithData broadCastActionEvent;
    public CrossObjectEventWithData characterDied;
    private SpawnDamageText spawnDamageTextScript;

    protected void SetStats(int health, int attack, int defence, int speed) {
        this.health = health;
        this.attack = attack;   
        this.defence = defence; 
        this.speed = speed;
        this.currSpeed = -speed;
        spawnDamageTextScript = GetComponent<SpawnDamageText>();
    }

    public virtual void GetAttacked(int damage) {
        spawnDamageTextScript.SpawnText(damage);
        health -= damage;
        if (health <= 0) {
            characterDied.TriggerEvent(this, this);
            Die();
        }
    }

    public virtual void Die() {
        Destroy(this.gameObject);
    }

    public virtual void EnqueueIntoSpeedQueue(Utils.PriorityQueue<Npc, float> pq) {
        pq.Enqueue(this, currSpeed);
    }

    public virtual void DecreaseSpeed() {
        currSpeed = currSpeed + Random.Range(0, 3);
        if (currSpeed >= 0) {
            currSpeed = currSpeed - speed;
        }
    }

    public virtual void Attack(List<Npc> opponentList) {
        Npc target = opponentList[Random.Range(0, opponentList.Count)];
        target.GetAttacked(attack);
        if (target != null) {
            target.GetAttacked(attack);
            broadCastActionEvent.TriggerEvent(this, "The player attacked enemy");
        }
    }

    public virtual void Attack(List<Npc> opponentList, int attackType) {}
}
