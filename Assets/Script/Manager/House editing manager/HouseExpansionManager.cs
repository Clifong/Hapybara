using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseExpansionManager : MonoBehaviour
{
    public List<GameObject> tileMaps;
    public List<AchievementSO> requiredAchievement;

    void Start()
    {
        for (int i = 0; i < requiredAchievement.Count; i++)
        {
            if (requiredAchievement[i].obtained) {
                tileMaps[i].SetActive(true);
            } else {
                return;
            }
        }
    }

    
}
