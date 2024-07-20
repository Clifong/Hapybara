using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinner : Boss
{
    public List<GameObject> attackSpawn;
    private Animator anime;
    public CrossObjectEventWithData broadcastMessage;
    private List<Npc> opponentList;
    private int randomNumberForSkills;
    private GameObject playerQueue;
    private SkillsSO skill;

    void Awake() {
        updateHealthBar = healthBar;
        anime = GetComponentInChildren<Animator>();
        enemySO = bossPhaseSO[0];
        SetStats(enemySO.health, enemySO.attack, enemySO.defence, enemySO.speed);
        playerQueue = GameObject.Find("Player queue");
    }

    public override void Attack(List<Npc> opponentList) {
        this.opponentList = opponentList;
        randomNumberForSkills = Random.Range(0, enemySO.allSkills.Count - 1);
        switch (randomNumberForSkills) {
            case 0:
                anime.SetTrigger("Attack1");
                break;
            case 1:
                anime.SetTrigger("Attack2");
                break;
            case 2:
                anime.SetTrigger("Attack3");
                break;  
        }
        GameObject spawn = Instantiate(attackSpawn[randomNumberForSkills], playerQueue.transform);
        spawn.transform.position += new Vector3(0, 2.0f, 0);
    }
    public void DealDamage() {
        skill = enemySO.ReturnASkillDefinite(randomNumberForSkills);
        AttackWithSkill(opponentList, skill);
    }

    public void BroadcastAttackFinished() {
        Debug.Log("END");
        broadCastActionEvent.TriggerEvent(this, enemySO.name + " used " + skill.name);
    }
}
