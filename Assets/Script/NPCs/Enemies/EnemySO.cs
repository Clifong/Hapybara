using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "Enemy SO", menuName = "Scriptable objects/EnemySO", order = 1)]
public class EnemySO : ScriptableObject
{
    public int health;
    public int attack;
    public int defence;
    public int speed;

    [Header("Loot")]
    public int moneyDroppedMin;
    public int moneyDroppedMax;
    [SerializedDictionary("Weapons", "Quantity/chance")]
    public SerializedDictionary<WeaponSO, SerializedDictionary<int, float>> allWeapons;
   
    [SerializedDictionary("Food", "Quantity/chance")]
    public SerializedDictionary<FoodSO, SerializedDictionary<int, float>> allFood;
    [SerializedDictionary("Ingredient", "Quantity/chance")]
    public SerializedDictionary<IngredientSO, SerializedDictionary<int, float>> allIngredients;

    public List<object> ReturnLoot() {
        List<object> loot = new List<object>();
        loot.Add(Random.Range(moneyDroppedMin, moneyDroppedMax));

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
