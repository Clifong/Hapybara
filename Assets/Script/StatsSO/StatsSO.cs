using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "StatsSO", menuName = "StatsSO", order = 1)]
public class StatsSO : ScriptableObject
{
    public int enemyKilled;
    public int chestOpened;
    public int amtOfWeaponObtained;
    public int amtOfFoodCreated;
    public int amtOfFurnitureCrafted;
    [Header("Achievements")]
    public List<AchievementWithQuantitySO> enemyAchievement;
    public List<AchievementWithQuantitySO>chestAchievement;
    public List<AchievementWithQuantitySO> weaponAchievement;
    public List<AchievementWithQuantitySO> foodAchievement;
    public List<AchievementWithQuantitySO> furnitureAchievement;
    
    public void SetTextInfo(List<TextMeshProUGUI> texts) {
        List<int> numbers = new List<int>(){enemyKilled, chestOpened, amtOfWeaponObtained, amtOfFoodCreated, amtOfFurnitureCrafted};
        for (int i = 0; i < texts.Count; i++) {
            texts[i].text = numbers[i].ToString();
        }
    }

    public void IncreaseEnemyKilled() {
        enemyKilled += 1;
        this.SetDirty();
        foreach (AchievementWithQuantitySO achievement in enemyAchievement)
        {
            achievement.UnlockAchievement(enemyKilled);
        }
    }

    public void IncreaseChestOpened() {
        chestOpened += 1;
        this.SetDirty();
        foreach (AchievementWithQuantitySO achievement in chestAchievement)
        {
            achievement.UnlockAchievement(chestOpened);
        }
    }

    public void IncreaseAmtOfFoodCooked(int qty) {
        amtOfFoodCreated += qty;
        this.SetDirty();
        foreach (AchievementWithQuantitySO achievement in foodAchievement)
        {
            achievement.UnlockAchievement(amtOfFoodCreated);
        }
    }

    public void IncreaseAmtOfWeaponCollected(int qty) {
        amtOfWeaponObtained += qty;
        this.SetDirty();
        foreach (AchievementWithQuantitySO achievement in weaponAchievement)
        {
            achievement.UnlockAchievement(amtOfWeaponObtained);
        }
    }

    public void IncreaseAmtOfFurnitureCollected(int qty) {
        amtOfWeaponObtained += qty;
        this.SetDirty();
        foreach (AchievementWithQuantitySO achievement in furnitureAchievement)
        {
            achievement.UnlockAchievement(amtOfFurnitureCrafted);
        }
    }
}
