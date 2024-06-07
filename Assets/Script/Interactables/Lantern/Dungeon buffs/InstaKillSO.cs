using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InstaKillSO", menuName = "Buffs/Insta kill skill", order = 1)]
public class InstaKillSO : DungeonBuffSO
{
    public void CheckIfCanInstaKillEnemy(List<Npc> playerParty, List<Npc> enemyParty) {
        int playerLevel = 0;
        int enemyLevel = 0;
        foreach (Player player in playerParty)
        {
            playerLevel += player.playerSO.level;
        }
        foreach (Enemy enemy in enemyParty)
        {
            enemyLevel += enemy.enemySO.level;
        }
        List<Npc> copy = new List<Npc>(enemyParty);
        if (playerLevel >= enemyLevel * 0.5) {
            for (int i = 0; i < copy.Count; i++) {
                enemyParty[i].Die();
            }
        }
    }
}
