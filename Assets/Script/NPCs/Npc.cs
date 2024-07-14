using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Npc : MonoBehaviour
{
    protected int currHealth;
    protected int currAttack;
    protected int currDefence;
    protected int currSpeed;
    protected int maxHealth;
    protected int attack;
    protected int defence;
    protected int speed;
    public CrossObjectEventWithData broadCastActionEvent;
    public CrossObjectEventWithData characterDied;
    protected SpawnDamageText spawnDamageTextScript;
    protected int poisonForHowLong = 0;
    protected int burnForHowLong = 0;
    protected UpdateStatusAlinmentIcon updateStatusAlinmentIcon;


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
        updateStatusAlinmentIcon = GetComponentInChildren<UpdateStatusAlinmentIcon>();
    }

    public virtual void GetAttacked(int damage) {
        spawnDamageTextScript.SpawnText(damage);
        currHealth -= damage;
        if (currHealth <= 0) {
            characterDied.TriggerEvent(this, this);
            Die();
        }
    }

    public virtual void ResetAlinment() {
        poisonForHowLong = 0;
        burnForHowLong = 0;
        updateStatusAlinmentIcon.Reset();
    }

    public virtual void GetAttacked(int damage, SkillsSO skillSO) {
        if (skillSO is PoisonSkillsSO) {
            poisonForHowLong = ((PoisonSkillsSO) skillSO).GetPosioned();
            if (poisonForHowLong > 0) {
                updateStatusAlinmentIcon.SpawnSomeIcon((PoisonSkillsSO) skillSO);
            }
        }
        if (skillSO is BurningSkillsSO) {
            burnForHowLong = ((BurningSkillsSO) skillSO).GetBurnt();
            if (burnForHowLong > 0) {
                updateStatusAlinmentIcon.SpawnSomeIcon((BurningSkillsSO) skillSO);
            }
        }     
        GetAttacked(damage);
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

    public virtual void AttackAllEnemyWithSkill(List<Npc> opponentList, SkillsSO skillSO) {
        foreach (Npc person in opponentList)
        {
            person.GetAttacked(attack + skillSO.damage, skillSO);
        }
    }

    public void AttackWithSkill(List<Npc> opponentList, SkillsSO skillSO) {
        Npc target = opponentList[Random.Range(0, opponentList.Count)];
        if (target != null) {
            target.GetAttacked(attack + skillSO.damage, skillSO);
        }
    }

    protected List<int> GetHealthInfo() {
        return new List<int>{currHealth, maxHealth};
    }

    public virtual void Attack(List<Npc> opponentList, int attackType) {}
}
