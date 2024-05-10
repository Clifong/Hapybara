using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredients : MonoBehaviour
{
    private FoodSO foodSO;
    private List<IngredientSO> allIngredients;
    private List<GameObject> spawnedIngredient = new List<GameObject>();
    public CrossObjectEventWithData cookingDone;
    public Transform spawnPoint;
    private bool isDone = false;

    public void GetFoodSO(Component component, object obj) {
        object[] temp = (object[]) obj;
        this.foodSO = (FoodSO) temp[0];
        allIngredients = foodSO.ingredientsNeeded.ReturnKeys();
        spawnedIngredient.Clear();
        StartCoroutine(SpawnDelay());
    }

    private IEnumerator SpawnDelay() {
        foreach (IngredientSO ingredientSO in allIngredients)
        {
            for (int i = 0; i < foodSO.ingredientsNeeded.GetValueAtKey(ingredientSO); i++) {
                GameObject ingredient = Instantiate(ingredientSO.ingredientObject, spawnPoint);
                spawnedIngredient.Add(ingredient);
                yield return new WaitForSeconds(0.1f);  
            } 
        }
        
    }

    void Update() {
        foreach (GameObject spawned in spawnedIngredient) {
            if (spawned == null) {
                isDone = true;
            } else {
                isDone = false;
            }
        }
        if (isDone) {
            Debug.Log( "?");
            cookingDone.TriggerEvent(this, foodSO);
        }
    }

}
