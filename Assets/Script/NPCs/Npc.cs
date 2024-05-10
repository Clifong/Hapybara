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

    void Start() {
        currSpeed = speed;
    }

    public virtual bool GetAttacked(int damage) {
        health -= damage;
        if (health <= 0) {
            return true;
        }
        return false;
    }

    public virtual void Die() {
        Destroy(this.gameObject);
    }

    public virtual void EnqueueIntoSpeedQueue(Utils.PriorityQueue<Npc, float> pq) {
        pq.Enqueue(this, currSpeed);
    }

    public virtual void DecreaseSpeed() {
        currSpeed = Mathf.Max(0, currSpeed - 1);
        if (currSpeed == 0) {
            currSpeed = speed;
        }
    }

    public virtual void Attack(List<Npc> opponentList) {
        Npc target = opponentList[Random.Range(0, opponentList.Count)];
<<<<<<< Updated upstream
        bool isDead = target.GetAttacked(attack);
        if (isDead) {
            opponentList.Remove(target);
            target.Die();
=======
        if (target != null) {
            target.GetAttacked(attack);
            broadCastActionEvent.TriggerEvent(this, "The player attacked enemy");
>>>>>>> Stashed changes
        }
    }
}
