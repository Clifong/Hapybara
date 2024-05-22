using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillsSO", menuName = "SkillsSO/Poison skills SO", order = 1)]
public class PoisonSkillsSO : SkillsSO
{
    [Header("Alinment infliction")]
    public float poisonChance;
    public int poisonTurn;

    public int GetPosioned() {
        float chance = Random.Range(0.0f, 100.0f);
        if (chance > (100.0f - poisonChance)) {
            return poisonTurn;;
        }
        return 0;
    }
}
