using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player unlocked furniture", menuName = "All player SO/Player unlocked furniture SO", order = 1)]
public class PlayerUnlockedFurnitureSO : ScriptableObject
{
    public List<BuildableSO> unlockedFurniture;
}
