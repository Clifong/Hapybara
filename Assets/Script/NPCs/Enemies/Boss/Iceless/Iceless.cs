using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceless : Boss
{
    public List<Transform> icelessSpielSpawnpoint;
    public GameObject icelessSpiel;
    private CircleCollider2D circleCollider2D;
    private Animator anime;
    public CrossObjectEventWithData broadcastMessage;
    public CrossObjectEvent castTheGreatFlare;
    private List<GameObject> spawnedIceSpeils = new List<GameObject>();
    private int attackCounter = 0;
    private List<Npc> tempOpponentList;

    void Awake() {
        updateHealthBar = healthBar;
        attackCounter = 0;
        phase = 0;
        enemySO = bossPhaseSO[phase];
        SetStats(enemySO.health, enemySO.attack, enemySO.defence, enemySO.speed);    
        circleCollider2D = GetComponent<CircleCollider2D>();
        anime = GetComponentInChildren<Animator>();
        spawnedIceSpeils.Clear();
    }

    public override void Die() {
        phase += 1;
        if (phase == bossPhaseSO.Count) {
            characterDied.TriggerEvent(this, this);
            dropLoot.TriggerEvent(this, enemySO);
            foreach (GameObject spawnedIceSpiel in spawnedIceSpeils)
            {
                Destroy(spawnedIceSpiel);
            }
            broadcastAchievementGained.TriggerEvent(this, allAchievementObtainable);
            Destroy(this.gameObject);
        } else {
            enemySO = bossPhaseSO[phase]; 
            SetStats(enemySO.health, enemySO.attack, enemySO.defence, enemySO.speed);   
            if (phase == 1) {
                foreach (Transform position in icelessSpielSpawnpoint)
                {
                  GameObject spawnedIceSpiel = Instantiate(icelessSpiel, position);
                  spawnedIceSpeils.Add(spawnedIceSpiel);
                  currAttack += 5;
                }
                broadcastMessage.TriggerEvent(this, "Ice spiels spawned will buff Iceless temporarily!");
            } else if (phase == 2) {
                broadcastMessage.TriggerEvent(this, "Iceless is resting...");
            }   
            AlertHealthChange();    
        }
    }

    public override void Attack(List<Npc> opponentList) {
        tempOpponentList = opponentList;
        if (phase == 2) {
            switch (attackCounter) {
                case 0:
                    broadcastMessage.TriggerEvent(this, "Iceless is preparing...");
                    break;
                case 1:
                    broadcastMessage.TriggerEvent(this, "The parasites grow restless...");
                    break;
                case 2:
                    broadcastMessage.TriggerEvent(this, "The air is turning heavy and cold...");
                    break;
                case 3:
                    broadcastMessage.TriggerEvent(this, "The great rage will cometh in the next turn...");
                    break;
                case 4:
                    broadcastMessage.TriggerEvent(this, "THe great flare befalls on all.");
                    anime.SetTrigger("Flare");
                    castTheGreatFlare.TriggerEvent();
                    break;
            }
            attackCounter += 1;
            attackCounter = attackCounter % 5;
        } else {
            int randomNumber = Random.Range(0, 2);
            if (randomNumber == 0 || enemySO.allSkills.Count == 0) {
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
    }

    public void GreatFlareEndThenAttack() {
        base.AttackAllEnemyWithSkill(tempOpponentList, enemySO.ReturnASkill(100));
    }

    public void RemoveBuff() {
        currAttack -= 5;
    }
}
