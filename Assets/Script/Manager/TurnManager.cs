using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class TurnManager : MonoBehaviour
{
    private PriorityQueue<Npc, float> turnQueue = new PriorityQueue<Npc, float>();
    private List<Npc> allEnemies = new List<Npc>();
    private List<Npc> allPlayers = new List<Npc>();
    private Turn turn;

    private enum Turn
    {
        PlayerTurn,
        EnemyTurn,
    }

    //Only called once whenever you enter into battle in situ
    public void InsertIntoQueue(Component component, object obj) {
        object[] temp = (object[]) obj;
        List<Npc> allNpc = (List<Npc>) temp[0];
        turnQueue.Clear();
        foreach (Npc npc in allNpc)
        {
            if (npc.GetComponent<Player>() != null) {
                allPlayers.Add(npc);
            } else {
                allEnemies.Add(npc);
            }
            npc.EnqueueIntoSpeedQueue(turnQueue);
        }
        ChangeTurn();
    }

    public void ChangeTurn() {
        while (allEnemies.Count > 0 && allPlayers.Count > 0) {
            Npc npc = turnQueue.Dequeue();
            if (npc.GetComponent<Enemy>()) {
                turn = Turn.EnemyTurn;
                npc.Attack(allPlayers);
            } else {
                turn = Turn.PlayerTurn;
                npc.Attack(allEnemies);
            }
            npc.DecreaseSpeed();
            npc.EnqueueIntoSpeedQueue(turnQueue);
        }
    }
}
