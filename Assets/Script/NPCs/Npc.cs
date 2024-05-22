using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Npc : MonoBehaviour
{
    private int currHealth;
    private int currAttack;
    private int currDefence;
    private int currSpeed;
    private int maxHealth;
    private int attack;
    private int defence;
    private int speed;
    public CrossObjectEventWithData broadCastActionEvent;
    public CrossObjectEventWithData characterDied;
    private SpawnDamageText spawnDamageTextScript;
    private int poisonForHowLong = 0;
    private int burnForHowLong = 0;


    protected void SetStats(int health, int attack, int defence, int speed) {
        this.maxHealth = health;
        this.attack = attack;   
        this.defence = defence; 
        this.speed = speed;

        this.currHealth = maxHealth;
        this.currAttack = attack;
        this.currDefence = defence;
        this.currSpeed = -speed;
        spawnDamageTextScript = GetComponent<SpawnDamageText>();
    }

    public virtual void GetAttacked(int damage) {
        spawnDamageTextScript.SpawnText(damage);
        currHealth -= damage;
        if (currHealth <= 0) {
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

    public virtual void UpdateStats(Component component, object obj) {
        object[] temp = (object[])obj;
        PlayerSO playerSO = (PlayerSO)temp[0];
        maxHealth = playerSO.health;
        attack = playerSO.attack;
        defence = playerSO.defence;
        speed = playerSO.speed;

        this.currHealth = Mathf.Min(this.currHealth, maxHealth);
    }

    public virtual void Attack(List<Npc> opponentList) {
        Npc target = opponentList[Random.Range(0, opponentList.Count)];
        if (target != null) {
            target.GetAttacked(attack);
        }
    }

    public void AttackWithSkill(List<Npc> opponentList, SkillsSO skillSO) {
        Npc target = opponentList[Random.Range(0, opponentList.Count)];
        if (target != null) {
            target.GetAttacked(attack + skillSO.damage);
        }
    }

    protected List<int> GetHealthInfo() {
        return new List<int>{currHealth, maxHealth};
    }

    public virtual void Attack(List<Npc> opponentList, int attackType) {}
}
