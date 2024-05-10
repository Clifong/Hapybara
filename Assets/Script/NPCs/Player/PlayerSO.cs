using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using AYellowpaper.SerializedCollections;
=======
>>>>>>> V3-Added-more-assets-to-cooking-menu

[CreateAssetMenu(fileName = "Player SO", menuName = "All player SO/PlayerSO", order = 1)]
public class PlayerSO : ScriptableObject
{
    public int health;
    public int attack;
    public int defence;
    public int speed;
<<<<<<< HEAD

    [Header("Inventory stuff")]
    [SerializedDictionary("All weapons", "quantity")]
    public SerializedDictionary<WeaponSO, int> allWeapons;
   
    [SerializedDictionary("All food", "quantity")]
    public SerializedDictionary<FoodSO, int> allFood;
=======
>>>>>>> V3-Added-more-assets-to-cooking-menu
}
