using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Npc
{
    public CrossObjectEventWithData enterBattle;

    public override void Die() {

        base.Die();
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
