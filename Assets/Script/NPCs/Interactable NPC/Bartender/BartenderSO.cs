using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bartender SO", menuName = "NPC/BartenderSO", order = 1)]
public class BartenderSO : ScriptableObject
{
    public List<PlayerSO> allRecruitablePlayer;
}
