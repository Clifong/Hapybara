using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillsSO", menuName = "SkillsSO/Blinding Skills SO", order = 1)]
public class BlindingSkillsSO : SkillsSO
{
    [Header("Alinment infliction")]
    public float blindingChance;
    public int blindingTurn;

    public int GetBlind() {
        float chance = Random.Range(0.0f, 100.0f);
        if (chance > (100.0f - blindingChance)) {
            return blindingTurn;;
        }
        return 0;
    }
}
