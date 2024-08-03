using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Player : Npc
{
    public PlayerSO playerSO;
    public CrossObjectEvent recoverSkillPoint;
    public CrossObjectEventWithData consumeSkillPoint;
    private UpdateHealthBar updateHealthBar;
    private bool cannotUseSkill;
    private PlayerAttack playerAttack;
    private int playerSkillValue = 0;


    void Awake() {
        updateHealthBar = GetComponentInChildren<UpdateHealthBar>();
        SetStats(playerSO.currentHealth, playerSO.health, playerSO.attack, playerSO.defence, playerSO.speed);  
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
        updateHealthBar.UpdateHealthBarInfo(playerSO.currentHealth, playerSO.health);
    }

    public override void GetAttacked(int damage) {
        base.GetAttacked(damage);
        playerSO.currentHealth = this.currHealth;
        playerSO.SetDirty();
    }

    public override void Frozen() {
        broadCastActionEvent.TriggerEvent(this, playerSO.name + " is frozen stiffed!");
        base.Frozen();
    }

    public override void UpdateStats(Component component, object obj) {
        base.UpdateStats(component, obj);
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
        if (attackType == -1 || playerSO.activeSkills.Count == 0 || cannotUseSkill) {
            recoverSkillPoint.TriggerEvent();
            Attack(opponentList);
        } else if (attackType == 1) {
            int randomNumber = Random.Range(0, playerSO.activeSkills.Count);
            SkillsSO chosenSkill = playerSO.activeSkills[playerSkillValue];
            broadCastActionEvent.TriggerEvent(this, playerSO.name + " used " + chosenSkill.name);
            consumeSkillPoint.TriggerEvent(this, chosenSkill.skillCost);
            AttackWithSkill(opponentList, chosenSkill);
        }
    }

    public void SetSkill(Component component, object obj) {
        object[] temp = (object[]) obj;
        playerSkillValue = (int) temp[0];
        if (playerSkillValue >= playerSO.activeSkills.Count) {
            playerSkillValue = playerSO.activeSkills.Count - 1;
        }
    }

    public void CountDownBuffTimer() {
        playerSO.CountDownBuffTimer();
        this.currHealth = Mathf.Min(currHealth, maxHealth);
        this.attack = attack;   
        this.defence = defence; 
        this.speed = 100 + speed;
        playerSO.SetDirty();
    }

    public void EmptyTummy() {
        playerSO.EmptyTummy();
        playerSO.SetDirty();
    }

    public void CannotUseSkill() {
        cannotUseSkill = true;
    }

    public void CanUseSkill() {
        cannotUseSkill = false;
    }

    void Update() {
        AlertHealthChange();
    }

}
