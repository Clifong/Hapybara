using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Npc
{
    public CrossObjectEvent exitBattle;
    public CrossObjectEventWithData enterBattle;
    public EnemySO enemySO;
    private UpdateHealthBar updateHealthBar;
    public CrossObjectEventWithData dropLoot;
    public GameObject battleZone;

    void Awake() {
        updateHealthBar = GetComponentInChildren<UpdateHealthBar>();
        SetStats(enemySO.health, enemySO.attack, enemySO.defence, enemySO.speed);    
        AlertHealthChange();         
    }

    public override void Die() {
        List<object> loot = enemySO.ReturnLoot();
        dropLoot.TriggerEvent(this, (int) loot[0], (List<WeaponSO>) loot[1], (List<FoodSO>) loot[2], (List<IngredientSO>) loot[3]);
        Destroy(this.gameObject);
    }


    public void AlertHealthChange() {
        updateHealthBar.UpdateHealthBarInfo(GetHealthInfo()[0], GetHealthInfo()[1]);
    }

    public override void GetAttacked(int damage) {
        base.GetAttacked(damage);
        AlertHealthChange();
    }

    public override void UpdateStats(Component component, object obj) {
        base.UpdateStats(component, obj);
        AlertHealthChange();
    }

    public override void EnqueueIntoSpeedQueue(Utils.PriorityQueue<Npc, float> pq) {
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
                updateStatusAlinmentIcon.NoMoreBurn();
            }
        }
        base.EnqueueIntoSpeedQueue(pq);
    }

    public override void Attack(List<Npc> opponentList) {
        int randomNumber = Random.Range(0, 2);
        if (randomNumber == 0) {
            broadCastActionEvent.TriggerEvent(this, enemySO.name + " attacked player");
            base.Attack(opponentList);
        } else {
            int randomNumberForSkills = Random.Range(0, enemySO.allSkills.Count - 1);
            float chance = Random.Range(0, 100f);
            SkillsSO rngSkill = enemySO.ReturnASkill(chance);
            broadCastActionEvent.TriggerEvent(this, enemySO.name + " used " + rngSkill.name);
            AttackWithSkill(opponentList, rngSkill);
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D) {
        Player player = collider2D.GetComponent<Player>();
        if (player != null) {
            PlayerQueue playerQueue = player.GetComponentInParent<PlayerQueue>();
            battleZone.SetActive(true);
            List<Npc> list = new List<Npc>();
            foreach (Player activePlayer in playerQueue.ReturnAllActivePlayer())
            {
                list.Add(activePlayer);
            }
            list.Add(this);
            enterBattle.TriggerEvent(this, list);
        }
    }

    void OnTriggerExit2D(Collider2D collider2D) {
        Player player = collider2D.GetComponent<Player>();
        if (player != null) {   
            battleZone.SetActive(false);
            exitBattle.TriggerEvent();
        }
    }
}
