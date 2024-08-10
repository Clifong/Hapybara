using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public StatsSO statsSO;

    public void AddEnemyKilled() {
        statsSO.IncreaseEnemyKilled();
    }

    public void AddChestOpened() {
        statsSO.IncreaseChestOpened();
    }

    public void AddFood(Component component, object obj) {
        object[] temp = (object[])obj;
        int qty = (int) temp[0];
        statsSO.IncreaseAmtOfFoodCooked(qty);
    }

    public void AddWeapon(Component component, object obj) {
        object[] temp = (object[])obj;
        int qty = (int) temp[0];
        statsSO.IncreaseAmtOfWeaponCollected(qty);
    }

    public void AddFurniture(Component component, object obj) {
        object[] temp = (object[])obj;
        int qty = (int) temp[0];
        statsSO.IncreaseAmtOfFurnitureCollected(qty);
    }
}
