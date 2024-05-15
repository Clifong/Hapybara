using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPopulateGrid : MonoBehaviour
{
    public PlayerInventorySO playerInventorySO;
    public Transform content;
    public GameObject weaponIcon;
    public GameObject foodIcon;
    private List<GameObject> allSpawnedWeaponIcons = new List<GameObject>();
    private List<GameObject> allSpawnedFoodIcons = new List<GameObject>();

    public void PopulateWeaponUI() {
        foreach (GameObject instantiatedWeaponIcon in allSpawnedWeaponIcons)
        {
            Destroy(instantiatedWeaponIcon);
        }
        foreach (GameObject instantiatedFoodIcon in allSpawnedFoodIcons)
        {
            Destroy(instantiatedFoodIcon);
        }
        allSpawnedFoodIcons.Clear();
        allSpawnedWeaponIcons.Clear();
        List<WeaponSO> allWeapons = playerInventorySO.allWeapons.ReturnKeys();
        foreach (WeaponSO weaponSO in allWeapons)
        {
            GameObject instantiatedWeaponIcon = Instantiate(weaponIcon, content);
            instantiatedWeaponIcon.GetComponent<WeaponIcon>().SetInfo(weaponSO, playerInventorySO.allWeapons[weaponSO]);
            allSpawnedWeaponIcons.Add(instantiatedWeaponIcon);
        }
    }

    public void PopulateFoodUI() {
        foreach (GameObject instantiatedWeaponIcon in allSpawnedWeaponIcons)
        {
            Destroy(instantiatedWeaponIcon);
        }
        foreach (GameObject instantiatedFoodIcon in allSpawnedFoodIcons)
        {
            Destroy(instantiatedFoodIcon);
        }
        allSpawnedFoodIcons.Clear();
        allSpawnedWeaponIcons.Clear();
        List<FoodSO> allFood = playerInventorySO.allFood.ReturnKeys();
        foreach (FoodSO foodSO in allFood)
        {
            GameObject instantiatedFoodIcon = Instantiate(foodIcon, content);
            instantiatedFoodIcon.GetComponent<FoodIconInventory>().SetInfo(foodSO, playerInventorySO.allFood[foodSO]);
            allSpawnedFoodIcons.Add(instantiatedFoodIcon);
        }
    }
}
