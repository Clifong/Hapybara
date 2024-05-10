using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Npc
{
    public CrossObjectEventWithData enterBattle;
    public EnemySO enemySO;

    void Awake() {
        SetStats(enemySO.health, enemySO.attack, enemySO.defence, enemySO.speed);    
    }

    public override void Attack(List<Npc> opponentList) {
        broadCastActionEvent.TriggerEvent(this, "The enemy attacked player");
        base.Attack(opponentList);
    }

    void OnTriggerEnter2D(Collider2D collider2D) {
        Player player = collider2D.GetComponent<Player>();
        if (player != null) {
            List<Npc> list = new List<Npc>();
            list.Add(player);
            list.Add(this);
            enterBattle.TriggerEvent(this, list);
        }
    }
}
