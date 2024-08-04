using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Enemy : Npc
{
    public CrossObjectEvent exitBattle;
    public CrossObjectEventWithData enterBattle;
    public EnemySO enemySO;
    protected UpdateHealthBar updateHealthBar;
    public CrossObjectEventWithData dropLoot;
    public GameObject battleZone;

    void Awake() {
        updateHealthBar = GetComponentInChildren<UpdateHealthBar>();
        SetStats(enemySO.health, enemySO.attack, enemySO.defence, enemySO.speed);    
        AlertHealthChange();         
    }

    public override void Die() {
        dropLoot.TriggerEvent(this, enemySO);
        Destroy(this.gameObject);
    }

    public void AlertHealthChange() {
        updateHealthBar.UpdateHealthBarInfo(currHealth, maxHealth);
    }

    public override void GetAttacked(int damage) {
        base.GetAttacked(damage);
        AlertHealthChange();
    }

    public override void UpdateStats(Component component, object obj) {
        base.UpdateStats(component, obj);
        AlertHealthChange();
    }

    public override void Frozen() {
        broadCastActionEvent.TriggerEvent(this, enemySO.name + " is frozen stiffed!");
        base.Frozen();
    }

    public override void EnqueueIntoSpeedQueue(PriorityQueue<Npc, float> pq) {
        if (poisonForHowLong > 0) {
            GetAttacked(1);
            broadCastActionEvent.TriggerEvent(this, enemySO.name + " was hurt by poison");
            poisonForHowLong -= 1;
            if (poisonForHowLong == 0) {
                updateStatusAlinmentIcon.NoMorePoison();
            }
        } 
        if (burnForHowLong > 0) {
            GetAttacked(1);
            broadCastActionEvent.TriggerEvent(this, enemySO.name + " was hurt by burn");
            burnForHowLong -= 1;
            if (burnForHowLong == 0) {
                currDefence += 10;
                updateStatusAlinmentIcon.NoMoreBurn();
            }
        }
        base.EnqueueIntoSpeedQueue(pq);
    }

    public virtual void Attack(List<Npc> opponentList) {
        int randomNumber = Random.Range(0, 2);
        if (randomNumber == 0 || enemySO.allSkills.Count == 0) {
            if (opponentList[0] is Enemy) {
                broadCastActionEvent.TriggerEvent(this, enemySO.name + " blindly attacked its allies");
            } else {
                broadCastActionEvent.TriggerEvent(this, enemySO.name + " attacked player");
            }
            base.Attack(opponentList);
        } else {
            int randomNumberForSkills = Random.Range(0, enemySO.allSkills.Count - 1);
            float chance = Random.Range(0, 100f);
            SkillsSO rngSkill = enemySO.ReturnASkill(chance);
            if (opponentList[0] is Enemy) {
                broadCastActionEvent.TriggerEvent(this, enemySO.name + " blindly used " + rngSkill.name + " On allies");
            } else {
                broadCastActionEvent.TriggerEvent(this, enemySO.name + " used " + rngSkill.name);
            }
            AttackWithSkill(opponentList, rngSkill);
        }
    }

    protected void OnTriggerEnter2D(Collider2D collider2D) {
        Player player = collider2D.GetComponent<Player>();
        if (player != null) {
            enemySO.encountered = true;
            enemySO.SetDirty();
            PlayerQueue playerQueue = player.GetComponentInParent<PlayerQueue>();
            battleZone.SetActive(true);
            List<Npc> list = new List<Npc>();
            foreach (Player activePlayer in playerQueue.ReturnAllActivePlayer())
            {
                list.Add(activePlayer);
            }
            list.Add(this);
            Debug.Log("ENTER");
            enterBattle.TriggerEvent(this, list);
        }
    }

    protected void OnTriggerExit2D(Collider2D collider2D) {
        Player player = collider2D.GetComponent<Player>();
        if (player != null) {   
            battleZone.SetActive(false);
            Debug.Log("EXIT");
            exitBattle.TriggerEvent();
        }
    }
}
