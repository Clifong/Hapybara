using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player unlocked dishes", menuName = "All player SO/Player unlocked dishes SO", order = 1)]
public class PlayerUnlockedDishesSO : ScriptableObject
{
    public List<FoodSO> unlockedDishes;
}
