using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPopulateGrid : MonoBehaviour
{
    public PlayerInventorySO playerInventorySO;
    public Transform content;
    public GameObject weaponIcon;
    public GameObject foodIcon;
    public GameObject furnitureIcon;
    private List<GameObject> allSpawnedIcons = new List<GameObject>();
    [Header("Menu when feeding")]
    public PlayerPartySO playerPartySO;
    public GameObject partyMemberIconWhenFeeding;
    public Transform partyMemberContent;
    private List<GameObject> allSpawnedPartyMemberIcons = new List<GameObject>(); 

    private void ClearGridIcons() {
        foreach (GameObject instantiatedIcon in allSpawnedIcons)
        {
            Destroy(instantiatedIcon);
        }
        allSpawnedIcons.Clear();
    }

    public void PopulateWeaponUI() {
        ClearGridIcons();
        List<WeaponSO> allWeapons = playerInventorySO.allWeapons.ReturnKeys();
        foreach (WeaponSO weaponSO in allWeapons)
        {
            GameObject instantiatedWeaponIcon = Instantiate(weaponIcon, content);
            instantiatedWeaponIcon.GetComponent<WeaponIcon>().SetInfo(weaponSO, playerInventorySO.allWeapons[weaponSO]);
            allSpawnedIcons.Add(instantiatedWeaponIcon);
        }
    }

    public void PopulateFoodUI() {
        ClearGridIcons();
        List<FoodSO> allFood = playerInventorySO.allFood.ReturnKeys();
        foreach (FoodSO foodSO in allFood)
        {
            GameObject instantiatedFoodIcon = Instantiate(foodIcon, content);
            instantiatedFoodIcon.GetComponent<FoodIconInventory>().SetInfo(foodSO, playerInventorySO.allFood[foodSO]);
            allSpawnedIcons.Add(instantiatedFoodIcon);
        }
    }

    public void PopulateFurnitureUI() {
        ClearGridIcons();
        List<BuildableSO> allFurniture = playerInventorySO.allFurniture.ReturnKeys();
        foreach (BuildableSO furnitureSO in allFurniture)
        {
            GameObject instantiatedFurnitureIcon = Instantiate(furnitureIcon, content);
            instantiatedFurnitureIcon.GetComponent<FurnitureIconInventory>().SetInfo(furnitureSO, playerInventorySO.allFurniture[furnitureSO]);
            allSpawnedIcons.Add(instantiatedFurnitureIcon);
        }
    }

    public void PopulateAllCharacterIcon() {
        foreach (GameObject instantiatedPartyMemberIcon in allSpawnedPartyMemberIcons)
        {
            Destroy(instantiatedPartyMemberIcon);
        }
        allSpawnedPartyMemberIcons.Clear();
        foreach (PlayerSO playerSO in playerPartySO.allPartyMembers) {
            GameObject instantiatedPartyMemberIcon = Instantiate(partyMemberIconWhenFeeding, partyMemberContent);
            instantiatedPartyMemberIcon.GetComponent<PartyIconWhenFeeding>().SetPlayerInfo(playerSO);
            allSpawnedPartyMemberIcons.Add(instantiatedPartyMemberIcon);
        }
    } 
}
