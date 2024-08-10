using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    [SerializedDictionary("Material", "Quantity/chance")]
    public SerializedDictionary<MaterialSO, SerializedDictionary<int, float>> allMaterials;
    [Header("Skills")]
    [SerializedDictionary("Skill", "Chance")]
    public SerializedDictionary<SkillsSO, float> allSkills;
    [Header("UI")]
    public Sprite enemySprite;
    [TextAreaAttribute]
    public string lore;
    public bool encountered = false;

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

    public SkillsSO ReturnASkillDefinite(int choice) {
        return allSkills.ReturnKeys()[choice];
    }

    public void FillBestiaryInfo(Image image, Button button) {
        image.sprite = enemySprite;
        if (!encountered) {
            image.color = new Color(0, 0, 0, 100f);
            button.enabled = false;
        } else {
            button.enabled = true;
        }
    }

    public void FillBestiaryInfo(Image image, TextMeshProUGUI nameText, TextMeshProUGUI description) {
        image.sprite = enemySprite;
        nameText.text = name;
        description.text = lore;
    }

    public void AddLoot(PlayerInventorySO playerInventorySO) {
        playerInventorySO.AddMoney(Random.Range(moneyDroppedMin, moneyDroppedMax));
        playerInventorySO.AddMemory(Random.Range(memoryDroppedMin, memoryDroppedMax));

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
                        playerInventorySO.AddWeapon(weaponSO);
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
                        playerInventorySO.AddFood(foodSO);
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
                        playerInventorySO.AddIngredient(ingredientSO);
                    }
                    break;
                } else {
                    count -= 1;
                }
            }
        }

        randomNumber = 100f - Random.Range(0.01f, 100f);
        List<MaterialSO> materials = new List<MaterialSO>();
        foreach (MaterialSO materialSO in allMaterials.ReturnKeys()) 
        {
            List<int> quantityList = allMaterials[materialSO].ReturnKeys();
            quantityList.Sort();
            int count = quantityList.Count - 1;
            while (true && count >= 0) {
                int quantity = quantityList[count];
                float chance = allMaterials[materialSO][quantity];
                if (randomNumber <= chance) {
                    for (int i = 0; i < quantity; i++)
                    {
                        playerInventorySO.AddMaterial(materialSO, quantity);
                    }
                    break;
                } else {
                    count -= 1;
                }
            }
        }
    }
}
