using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Npc : MonoBehaviour
{
    [SerializeField]
    protected int currHealth;
    [SerializeField]
    protected int currAttack;
    [SerializeField]
    protected int currDefence;
    [SerializeField]
    protected int currSpeed;
    protected int maxHealth;
    protected int attack;
    protected int defence;
    protected int speed;
    public CrossObjectEventWithData broadCastActionEvent;
    public CrossObjectEventWithData characterDied;
    protected SpawnDamageText spawnDamageTextScript;
    [SerializeField]
    protected int poisonForHowLong = 0;
    [SerializeField]
    protected int burnForHowLong = 0;
    [SerializeField]
    protected int blindForHowLong = 0;
    [SerializeField]
    protected int frozenForHowLong = 0;
    protected UpdateStatusAlinmentIcon updateStatusAlinmentIcon;
    protected SpriteRenderer spriteRenderer;


    protected void SetStats(int health, int attack, int defence, int speed) {
        this.maxHealth = health;
        this.attack = attack;   
        this.defence = defence; 
        this.speed = speed;

        this.currHealth = maxHealth;
        this.currAttack = attack;
        this.currDefence = defence;
        this.currSpeed = 100 + speed;
        spawnDamageTextScript = GetComponent<SpawnDamageText>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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
        frozenForHowLong = 0;
        blindForHowLong = 0;
        updateStatusAlinmentIcon.Reset();
    }

    public bool IsFrozen() {
        return frozenForHowLong > 0;
    }

    public bool IsBurn() {
        return burnForHowLong > 0;
    }

    public bool IsBlind() {
        return blindForHowLong > 0;
    }

    public bool BlindAttack() {
        return Random.Range(0, 1) == 0;
    }

    public virtual void Frozen() {
        frozenForHowLong -= 1;
        if (IsFrozen()) {
            spriteRenderer.color = new Color(0, 192, 255);
            return;
        } else {
            spriteRenderer.color = new Color(255, 255, 255);
        }
    }

    public virtual void GetAttacked(int damage, SkillsSO skillSO) {
        if (skillSO is PoisonSkillsSO) {
            poisonForHowLong = ((PoisonSkillsSO) skillSO).GetPosioned();
            if (poisonForHowLong > 0) {
                updateStatusAlinmentIcon.SpawnSomeIcon((PoisonSkillsSO) skillSO);
            }
        }
        if (skillSO is BurningSkillsSO) {
            int burnTime = ((BurningSkillsSO) skillSO).GetBurnt();

            if (!IsBurn() && burnTime > 0) {
                currDefence -= 10;
                updateStatusAlinmentIcon.SpawnSomeIcon((BurningSkillsSO) skillSO);
            } 
            
            if (burnTime > 0) {
                burnForHowLong = burnTime;
            }
 
        }    
        if (skillSO is FrozenSkillsSO) {
            int frozenTime = ((FrozenSkillsSO) skillSO).GetFrozen();

            if (!IsFrozen() && frozenTime > 0) {
                frozenForHowLong = frozenTime;
                spriteRenderer.color = new Color(0, 192, 255);
                updateStatusAlinmentIcon.SpawnSomeIcon((FrozenSkillsSO) skillSO);
            }
        }  
        if (skillSO is BlindingSkillsSO) {
            int tempBlindTime = ((BlindingSkillsSO) skillSO).GetBlind();

            if (!IsBlind() && tempBlindTime > 0) {
                blindForHowLong = tempBlindTime; 
                updateStatusAlinmentIcon.SpawnSomeIcon((BlindingSkillsSO) skillSO);
            } 
            
        }   
        GetAttacked(damage);
    }

    public virtual void Die() {
        Destroy(this.gameObject);
    }

    public virtual void EnqueueIntoSpeedQueue(Utils.PriorityQueue<Npc, float> pq) {
        pq.Enqueue(this, -currSpeed);
    }

    public virtual void DecreaseSpeed() {
        currSpeed -= Random.Range(1, 5);
        if (currSpeed <= 0) {
           ResetSpeed();
        }
    }

    public void ResetSpeed() {
        currSpeed = 100 + speed;
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
            target.GetAttacked(currAttack);
        }
    }

    public virtual void AttackAllEnemyWithSkill(List<Npc> opponentList, SkillsSO skillSO) {
        List<Npc> copiedOpponentList = new List<Npc>(opponentList);
        foreach (Npc person in copiedOpponentList)
        {
            person.GetAttacked(currAttack + skillSO.damage, skillSO);
        }
    }

    public void AttackWithSkill(List<Npc> opponentList, SkillsSO skillSO) {
        Npc target = opponentList[Random.Range(0, opponentList.Count)];
        if (target != null) {
            target.GetAttacked(skillSO.damage, skillSO);
        }
    }

    protected List<int> GetHealthInfo() {
        return new List<int>{currHealth, maxHealth};
    }

    public virtual void Attack(List<Npc> opponentList, int attackType) {}
}
