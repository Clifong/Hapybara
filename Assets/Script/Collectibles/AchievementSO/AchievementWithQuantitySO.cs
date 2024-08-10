using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AchievementQtySO", menuName = "Collectibles/Achievements with qty", order = 1)]
public class AchievementWithQuantitySO : AchievementSO
{
    public int quantity;

    public void UnlockAchievement(int currQty) {
        if (currQty >= quantity) {
            obtained = true;
        }
    }
}
