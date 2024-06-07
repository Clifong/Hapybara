using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DungeonBuffContainerSO", menuName = "DungeonBuffContainerSO", order = 1)]
public class DungeonBuffContainerSO : ScriptableObject
{
    public InstaKillSO instaKillSO = null;

    public void CheckIfCanInstaKillEnemy(List<Npc> allPlayers, List<Npc> allEnemies) {
        if (instaKillSO != null) {
            instaKillSO.CheckIfCanInstaKillEnemy(allPlayers, allEnemies);
        }
    }

    public void ResetAllSkills() {
        instaKillSO = null;
    }
}
