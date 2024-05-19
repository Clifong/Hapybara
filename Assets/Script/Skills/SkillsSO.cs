using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillsSO", menuName = "SkillsSO/Skills SO", order = 1)]
public class SkillsSO : ScriptableObject
{
    public Sprite skillIcon;
    public string skillName;
    [TextAreaAttribute]
    public string skillDescription;
    public int damage;

    [Header("Alinment infliction")]
    public bool causeBurn;
    public float burnChance;
    public bool causePoison;
    public float poisonChance;
}
