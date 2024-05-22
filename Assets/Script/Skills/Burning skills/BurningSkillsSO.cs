using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillsSO", menuName = "SkillsSO/Burning skills SO", order = 1)]
public class BurningSkillsSO : SkillsSO
{
    [Header("Alinment infliction")]
    public float burnChance;
    public int burnTurn;

    public int GetBurnt() {
        float chance = Random.Range(0.0f, 100.0f);
        if (chance > (100.0f - burnChance)) {
            return burnTurn;;
        }
        return 0;
    }
}

