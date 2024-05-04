using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Npc
{
    public override bool GetAttacked(int damage) {
        return base.GetAttacked(damage);
    }
}
