using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy SO", menuName = "Scriptable objects/EnemySO", order = 1)]
public class EnemySO : ScriptableObject
{
    public int health;
    public int attack;
    public int defence;
    public int speed;
}
