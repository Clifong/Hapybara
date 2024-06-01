using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player unlocked collectibles", menuName = "All player SO/Player unlocked collectibles SO", order = 1)]
public class PlayerUnlokedCollectiblesSO : ScriptableObject
{
    public List<BookSO> allUnlockedBooks;   
    public List<AchievementSO> allAchievement; 
}
