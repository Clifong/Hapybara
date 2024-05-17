using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class TurnManager : MonoBehaviour
{
    private PriorityQueue<Npc, float> turnQueue = new PriorityQueue<Npc, float>();
    [SerializeField]
    private List<Npc> allEnemies = new List<Npc>();
    [SerializeField]
    private List<Npc> allPlayers = new List<Npc>();
    private Turn turn;
    public CrossObjectEvent showItIsEnemyTurn;
    public CrossObjectEvent showItIsPlayerTurn;
    public CrossObjectEventWithData playerWon;
    public CrossObjectEvent playerLoss;
    private Npc currentActionTaker;

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

    public void ExitBattle() {
        allEnemies.Clear();
        allPlayers.Clear();
    }

    public void ChangeTurn() {
        if (allEnemies.Count == 0) {
            playerWon.TriggerEvent(this, new List<int>());
            return;
        } else if (allPlayers.Count == 0) {
            playerLoss.TriggerEvent();
            return;
        }
        currentActionTaker = turnQueue.Dequeue();
        while (currentActionTaker.GetComponent<Enemy>() != null) {
            showItIsEnemyTurn.TriggerEvent();
            turn = Turn.EnemyTurn;
            currentActionTaker.Attack(allPlayers);
            currentActionTaker.DecreaseSpeed();
            currentActionTaker.EnqueueIntoSpeedQueue(turnQueue);
            currentActionTaker = turnQueue.Dequeue();
        }
        turn = Turn.PlayerTurn;
        showItIsPlayerTurn.TriggerEvent();
    }

    public void RemoveCharacterFromList(Component component, object obj) {
        object[] temp = (object[]) obj;
        Npc npc = (Npc) temp[0];
        if (npc.GetComponent<Enemy>() != null) {
            allEnemies.Remove(npc);
        } else {
            allPlayers.Remove(npc);
        }
    }

    public void PlayerSelectedAction(Component component, object obj) {
        object[] temp = (object[]) obj;
        int attackType = (int)Mathf.Round((float) temp[0]);
        currentActionTaker.Attack(allEnemies, attackType);
        currentActionTaker.DecreaseSpeed();
        currentActionTaker.EnqueueIntoSpeedQueue(turnQueue);
        ChangeTurn();
    }
}
