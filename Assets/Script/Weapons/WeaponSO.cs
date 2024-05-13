using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Weapon SO", order = 1)]
public class WeaponSO : ScriptableObject
{
    [Header("Information")]
    public Sprite weaponIconWithFrame;
    public Sprite weaponIconWithoutFrame;
    public string weaponName;
    [TextAreaAttribute]
    public string weaponDescription;
    [Header("Stats boost")]
    public int maxHealthChange;
    public int attackChange;
    public int defenceChange;
    
    public int speedChange;
    public bool equipped;
    [Header("Effects")]
    [TextAreaAttribute]
    public string effectsDescription;
}
