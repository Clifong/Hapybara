using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "Enemy SO", menuName = "Scriptable objects/EnemySO", order = 1)]
public class EnemySO : ScriptableObject
{
    public int level;
    public string name;
    public int health;
    public int attack;
    public int defence;
    public int speed;

    [Header("Loot")]
    public int moneyDroppedMin;
    public int moneyDroppedMax;
    public int memoryDroppedMin;
    public int memoryDroppedMax;
    [SerializedDictionary("Weapons", "Quantity/chance")]
    public SerializedDictionary<WeaponSO, SerializedDictionary<int, float>> allWeapons;
   
    [SerializedDictionary("Food", "Quantity/chance")]
    public SerializedDictionary<FoodSO, SerializedDictionary<int, float>> allFood;
    [SerializedDictionary("Ingredient", "Quantity/chance")]
    public SerializedDictionary<IngredientSO, SerializedDictionary<int, float>> allIngredients;
    [Header("Skills")]
    [SerializedDictionary("Skill", "Chance")]
    public SerializedDictionary<SkillsSO, float> allSkills;

    public SkillsSO ReturnASkill(float chance) {
        List<SkillsSO> skillList = allSkills.ReturnKeys();
        Dictionary<float, List<SkillsSO>> temp = new Dictionary<float, List<SkillsSO>>();
        List<float> chances = new List<float>();
        foreach (SkillsSO skill in skillList)
        {
            float prob = 100f- allSkills[skill]; 
            chances.Add(prob);
            if (temp.ContainsKey(prob)) {
                temp[prob].Add(skill);
            } else {
                temp[prob] = new List<SkillsSO>();
                temp[prob].Add(skill);
            }
        }
        chances.Sort();
        float key = 0;
        for (int i = chances.Count - 1; i >= 0; i--)
        {
            if (chance >= chances[i]) {
                key = chances[i];
                break;
            }
        } 
        int randomNumber = Random.Range(0, temp[key].Count);
        return temp[key][randomNumber];
    }

    public List<object> ReturnLoot() {
        List<object> loot = new List<object>();
        loot.Add(Random.Range(moneyDroppedMin, moneyDroppedMax));
        loot.Add(Random.Range(memoryDroppedMin, memoryDroppedMax));
        loot.Add(level*100);

        float randomNumber = 100f - Random.Range(0.01f, 100f);
        List<WeaponSO> weapons = new List<WeaponSO>();
        foreach (WeaponSO weaponSO in allWeapons.ReturnKeys()) 
        {
            List<int> quantityList = allWeapons[weaponSO].ReturnKeys();
            quantityList.Sort();
            int count = quantityList.Count - 1;
            while (true && count >= 0) {
                int quantity = quantityList[count];
                float chance = allWeapons[weaponSO][quantity];
                if (randomNumber <= chance) {
                    for (int i = 0; i < quantity; i++)
                    {
                        weapons.Add(weaponSO);
                    }
                    break;
                } else {
                    count -= 1;
                }
            }
        }

        randomNumber = 100f - Random.Range(0.01f, 100f);
        List<FoodSO> food = new List<FoodSO>();
        foreach (FoodSO foodSO in allFood.ReturnKeys()) 
        {
            List<int> quantityList = allFood[foodSO].ReturnKeys();
            quantityList.Sort();
            int count = quantityList.Count - 1;
            while (true && count >= 0) {
                int quantity = quantityList[count];
                float chance = allFood[foodSO][quantity];
                if (randomNumber <= chance) {
                    for (int i = 0; i < quantity; i++)
                    {
                        food.Add(foodSO);
                    }
                    break;
                } else {
                    count -= 1;
                }
            }
        }

        randomNumber = 100f - Random.Range(0.01f, 100f);
        List<IngredientSO> ingredients = new List<IngredientSO>();
        foreach (IngredientSO ingredientSO in allIngredients.ReturnKeys()) 
        {
            List<int> quantityList = allIngredients[ingredientSO].ReturnKeys();
            quantityList.Sort();
            int count = quantityList.Count - 1;
            while (true && count >= 0) {
                int quantity = quantityList[count];
                float chance = allIngredients[ingredientSO][quantity];
                if (randomNumber <= chance) {
                    for (int i = 0; i < quantity; i++)
                    {
                        ingredients.Add(ingredientSO);
                    }
                    break;
                } else {
                    count -= 1;
                }
            }
        }

        loot.Add(weapons);
        loot.Add(food);
        loot.Add(ingredients);
        return loot;
    }
}
