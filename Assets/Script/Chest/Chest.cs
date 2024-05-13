using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public class Chest : MonoBehaviour, Interactables 
{
    [SerializedDictionary("All Weapons", "quantity")]
    public SerializedDictionary<WeaponSO, int> allWeapons;
    [SerializedDictionary("All Food", "quantity")]
    public SerializedDictionary<FoodSO, int> allFood;

    public GameObject interactPrompt;
    private bool canInteract = false;
    public CrossObjectEventWithData addChestItemToInventory;
    private Animator anime;

    public void Interact() {
        anime = GetComponentInChildren<Animator>();
        anime.SetTrigger("Open");
        List<WeaponSO> tempWeaponList = new List<WeaponSO>();
        List<FoodSO> tempFoodList = new List<FoodSO>();
        foreach (WeaponSO weaponSO in allWeapons.ReturnKeys())
        {
            for (int i = allWeapons[weaponSO]; i > 0 ; i--)
            {
                tempWeaponList.Add(weaponSO);
            }
        }
        foreach (FoodSO foodSO in allFood.ReturnKeys())
        {
            for (int i = allFood[foodSO]; i > 0 ; i--)
            {
                tempFoodList.Add(foodSO);
            }
        }
        addChestItemToInventory.TriggerEvent(this, tempWeaponList, tempFoodList);
    }

    void OnTriggerEnter2D(Collider2D other) {
        interactPrompt.SetActive(true);
    } 

    void OnTriggerExit2D(Collider2D other) {
        interactPrompt.SetActive(false);
    } 

    public void DestroyChest() {
        Destroy(this.gameObject);
    }

}
