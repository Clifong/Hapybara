using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Bartender SO", menuName = "NPC/BartenderSO", order = 1)]
public class BartenderSO : ScriptableObject
{
    public List<PlayerSO> allRecruitablePlayer;

    public void RemovePlayer(PlayerSO playerSO) {
        allRecruitablePlayer.Remove(playerSO);
        // EditorUtility.SetDirty(this);
    } 
}
