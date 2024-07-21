using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Player : Npc
{
    public PlayerSO playerSO;
    private UpdateHealthBar updateHealthBar;
    private PlayerAttack playerAttack;

    void Awake() {
        updateHealthBar = GetComponentInChildren<UpdateHealthBar>();
        SetStats(playerSO.health, playerSO.attack, playerSO.defence, playerSO.speed);  
        playerAttack = GetComponent<PlayerAttack>();
        playerAttack.enabled = false;
        AlertHealthChange();  
    }

    public void EnableAttack() {
        playerAttack.EnableAttack();
    }

    public void DisableAttack() {
        playerAttack.DisableAttack();
    }

    public void AlertHealthChange() {
        updateHealthBar.UpdateHealthBarInfo(GetHealthInfo()[0], GetHealthInfo()[1]);
    }

    public override void GetAttacked(int damage) {
        base.GetAttacked(damage);
        AlertHealthChange();
    }

    public override void Frozen() {
        broadCastActionEvent.TriggerEvent(this, playerSO.name + " is frozen stiffed!");
        base.Frozen();
    }

    public override void UpdateStats(Component component, object obj) {
        base.UpdateStats(component, obj);
        AlertHealthChange();
    }

    public override void Attack(List<Npc> opponentList) {
        if (opponentList[0] is Player) {
            broadCastActionEvent.TriggerEvent(this, playerSO.name + " blindly attacked its allies");
        } else {
            broadCastActionEvent.TriggerEvent(this, playerSO.name + " attacked enemy");
        }
        base.Attack(opponentList);
    }

    public override void EnqueueIntoSpeedQueue(PriorityQueue<Npc, float> pq) {
        if (poisonForHowLong > 0) {
            GetAttacked(1);
            broadCastActionEvent.TriggerEvent(this, playerSO.name + " was hurt by poison");
            poisonForHowLong -= 1;
            if (poisonForHowLong == 0) {
                updateStatusAlinmentIcon.NoMorePoison();
            }
        } 
        if (burnForHowLong > 0) {
            GetAttacked(1);
            broadCastActionEvent.TriggerEvent(this, playerSO.name + " was hurt by melting");
            burnForHowLong -= 1;
            if (burnForHowLong == 0) {
                currDefence += 10;
                updateStatusAlinmentIcon.NoMoreBurn();
            }
        }
        base.EnqueueIntoSpeedQueue(pq);
    }

    public override void Attack(List<Npc> opponentList, int attackType) {
        if (attackType == -1 || playerSO.allSkills.Count == 0) {
            Attack(opponentList);
        } else if (attackType == 1) {
            int randomNumber = Random.Range(0, playerSO.allSkills.Count);
            broadCastActionEvent.TriggerEvent(this, playerSO.name + " used " + playerSO.allSkills[randomNumber].name);
            AttackWithSkill(opponentList, playerSO.allSkills[randomNumber]);
        }
    }

}
