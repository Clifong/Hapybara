using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player SO", menuName = "Scriptable objects/PlayerSO", order = 1)]
public class PlayerSO : ScriptableObject
{
    public int health;
    public int attack;
    public int defence;
    public int speed;
}
