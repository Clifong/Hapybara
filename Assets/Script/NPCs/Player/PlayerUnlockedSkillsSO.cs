using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player unlocked skills", menuName = "All player SO/Player unlocked skills so", order = 1)]
public class PlayerUnlockedSkillsSO : ScriptableObject
{
    public List<SkillsSO> allUnlockedSkills;
}
