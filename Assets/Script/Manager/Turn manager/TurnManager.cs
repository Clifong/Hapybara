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
    public CrossObjectEventWithData checkDungeonBuffs;
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
        foreach (Npc npc in allNpc)
        {
            if (npc.GetComponent<Player>() != null) {
                allPlayers.Add(npc);
            } else {
                allEnemies.Add(npc);
            }
            npc.EnqueueIntoSpeedQueue(turnQueue);
        }
        checkDungeonBuffs.TriggerEvent(this, allPlayers, allEnemies);

        ChangeTurn(this, null);
    }

    public void ExitBattle() {
        foreach (Npc npc in allPlayers)
        {
            npc.ResetAlinment();
            npc.ResetSpeed();
            ((Player) npc).DisableAttack();
        }
        foreach (Npc npc in allEnemies)
        {
            npc.ResetAlinment();
            npc.ResetSpeed();
        }
        allEnemies.Clear();
        allPlayers.Clear();
        turnQueue.Clear();
    }

    public void ChangeTurn(Component component, object obj) {
        if (allEnemies.Count == 0) {
            playerWon.TriggerEvent(this, new List<int>());
            return;
        } else if (allPlayers.Count == 0) {
            playerLoss.TriggerEvent();
            return;
        }

        StartCoroutine(Delay());
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
        ((Player) currentActionTaker).DisableAttack();
        if (currentActionTaker.IsBlind()) {
            if (currentActionTaker.BlindAttack()) {
                currentActionTaker.Attack(allPlayers, attackType);
            } else {
                currentActionTaker.Attack(allEnemies, attackType);   
            }
        } else {
            currentActionTaker.Attack(allEnemies, attackType);   
        }
    }

    IEnumerator Delay() {
        Debug.Log(turnQueue.Count);
        currentActionTaker = turnQueue.Dequeue();
        currentActionTaker.DecreaseSpeed();
        currentActionTaker.EnqueueIntoSpeedQueue(turnQueue);
        
        if (currentActionTaker is Player) {
            turn = Turn.PlayerTurn;
            showItIsPlayerTurn.TriggerEvent();
        } else {
            showItIsEnemyTurn.TriggerEvent();
            turn = Turn.EnemyTurn;  
        }
        yield return new WaitForSeconds(0.1f);
        
        if (currentActionTaker.IsFrozen()) {
            currentActionTaker.DecreaseSpeed();
            currentActionTaker.EnqueueIntoSpeedQueue(turnQueue); 
            currentActionTaker.Frozen();
            yield break;  
        }

        if (currentActionTaker is Player) {
            ((Player) currentActionTaker).EnableAttack();
        } else {
            if (currentActionTaker.IsBlind()) {
                if (currentActionTaker.BlindAttack()) {
                    ((Enemy) currentActionTaker).Attack(allEnemies);
                }   
                else {
                    ((Enemy) currentActionTaker).Attack(allPlayers);
                }
            } else {
                ((Enemy) currentActionTaker).Attack(allPlayers);
            }
        }
    }
}
