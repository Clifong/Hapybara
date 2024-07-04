using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillsSO", menuName = "SkillsSO/Frozen skills sO", order = 1)]
public class FrozenSkillsSO : SkillsSO
{
    [Header("Alinment infliction")]
    public float frozenChance;
    public int frozenTurn;

    public int GetFrozen() {
        float chance = Random.Range(0.0f, 100.0f);
        if (chance > (100.0f - frozenChance)) {
            return frozenTurn;;
        }
        return 0;
    }
}
