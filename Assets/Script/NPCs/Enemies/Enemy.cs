using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Npc
{
    public CrossObjectEvent exitBattle;
    public CrossObjectEventWithData enterBattle;
    public EnemySO enemySO;
    private UpdateHealthBar updateHealthBar;
    public CrossObjectEventWithData dropLoot;
    public GameObject battleZone;

    void Awake() {
        updateHealthBar = GetComponentInChildren<UpdateHealthBar>();
        SetStats(enemySO.health, enemySO.attack, enemySO.defence, enemySO.speed);    
        AlertHealthChange();         
    }

    public override void Die() {
        List<object> loot = enemySO.ReturnLoot();
        dropLoot.TriggerEvent(this, (int) loot[0], (List<WeaponSO>) loot[1], (List<FoodSO>) loot[2], (List<IngredientSO>) loot[3]);
        Destroy(this.gameObject);
    }


    public void AlertHealthChange() {
        updateHealthBar.UpdateHealthBarInfo(GetHealthInfo()[0], GetHealthInfo()[1]);
    }

    public override void GetAttacked(int damage) {
        base.GetAttacked(damage);
        AlertHealthChange();
    }

    public override void UpdateStats(Component component, object obj) {
        base.UpdateStats(component, obj);
        AlertHealthChange();
    }

    public override void Attack(List<Npc> opponentList) {
        broadCastActionEvent.TriggerEvent(this, "The enemy attacked player");
        base.Attack(opponentList);
    }

    void OnTriggerEnter2D(Collider2D collider2D) {
        Player player = collider2D.GetComponent<Player>();
        if (player != null) {
            PlayerQueue playerQueue = player.GetComponentInParent<PlayerQueue>();
            battleZone.SetActive(true);
            List<Npc> list = new List<Npc>();
            foreach (Player activePlayer in playerQueue.ReturnAllActivePlayer())
            {
                list.Add(activePlayer);
            }
            list.Add(this);
            enterBattle.TriggerEvent(this, list);
        }
    }

    void OnTriggerExit2D(Collider2D collider2D) {
        Player player = collider2D.GetComponent<Player>();
        if (player != null) {   
            battleZone.SetActive(false);
            exitBattle.TriggerEvent();
        }
    }
}
