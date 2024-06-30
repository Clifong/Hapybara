using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameObject mainPanel;
    public TextMeshProUGUI moneyIHave;
    public GameObject foodPanelDisplay;
    public GameObject weaponPanelDisplay;
    public GameObject specialItemDisplay;
    public Transform content;
    public Button buyButton;
    private ShopkeeperSO shopkeeperSO;
    private List<GameObject> allInstantiatedWeaponPanel = new List<GameObject>();
    private List<GameObject> allInstantiatedFoodPanel = new List<GameObject>();
    private List<GameObject> allInstantiatedSpecialItemPanel = new List<GameObject>();
    public CrossObjectEventWithData addWeaponToInventory;
    public CrossObjectEventWithData addFoodToInventory;
    public CrossObjectEventWithData addSpecialItemToInventory;
    private object currentSO;
    public CrossObjectEvent askPlayerFoMoney;
    private int playerMoney;

    public void DisplayAllWeaponOnSale(ShopkeeperSO shopkeeperSO) {
        WipeoutAllIcon();     
        mainPanel.SetActive(true);
        this.shopkeeperSO = shopkeeperSO;
        foreach (WeaponSO weaponSO in shopkeeperSO.allWeaponsSold.ReturnKeys())
        {
            GameObject instantiatedWeaponPanel = Instantiate(weaponPanelDisplay, content);
            int quantityOfWeapon = shopkeeperSO.allWeaponsSold[weaponSO].ReturnKeys()[0];
            int costOfWeapon = shopkeeperSO.allWeaponsSold[weaponSO][quantityOfWeapon];
            instantiatedWeaponPanel.GetComponent<WeaponOnSalePanel>().SetWeaponSO(weaponSO, quantityOfWeapon, costOfWeapon);
            allInstantiatedWeaponPanel.Add(instantiatedWeaponPanel);
        }
    }

    public void SetAmountOfMoneyIHave(Component component, object obj) {
        object[] temp = (object[])obj;
        moneyIHave.text = ((int) temp[0]).ToString();
        playerMoney = (int)temp[0];
    }

    public void DisplayAllFoodOnSale() {
        WipeoutAllIcon();
        foreach (FoodSO foodSO in shopkeeperSO.allFoodSold.ReturnKeys())
        {
            GameObject instantiatedFoodPanel = Instantiate(foodPanelDisplay, content);
            int quantityOfFood = shopkeeperSO.allFoodSold[foodSO].ReturnKeys()[0];
            int costOfFood = shopkeeperSO.allFoodSold[foodSO][quantityOfFood];
            instantiatedFoodPanel.GetComponent<FoodOnSalePanel>().SetFoodSO(foodSO, quantityOfFood, costOfFood);
            allInstantiatedFoodPanel.Add(instantiatedFoodPanel);
        }
    }

    public void CanBuy(Component component, object obj) {
        object[] temp = (object[]) obj;
        int cost = (int)temp[2];
        if (cost > playerMoney) {
            buyButton.gameObject.SetActive(false);
        } else {
            buyButton.gameObject.SetActive(true);
        }
    }

    public void GoToWeaponOnSale() {
        WipeoutAllIcon();     
        mainPanel.SetActive(true);
        foreach (WeaponSO weaponSO in shopkeeperSO.allWeaponsSold.ReturnKeys())
        {
            GameObject instantiatedWeaponPanel = Instantiate(weaponPanelDisplay, content);
int quantityOfWeapon = shopkeeperSO.allWeaponsSold[weaponSO].ReturnKeys()[0];
            int costOfWeapon = shopkeeperSO.allWeaponsSold[weaponSO][quantityOfWeapon];
            instantiatedWeaponPanel.GetComponent<WeaponOnSalePanel>().SetWeaponSO(weaponSO, quantityOfWeapon, costOfWeapon);
            allInstantiatedWeaponPanel.Add(instantiatedWeaponPanel);
        }
    }

    public void DisplayAllSpecialItemOnSale() {
        WipeoutAllIcon();
        foreach (RecipeSO recipeSO in shopkeeperSO.allSpecialItem.ReturnKeys())
        {
            GameObject instantiatedSpecialPanel = Instantiate(specialItemDisplay, content);
            int quantityOfItem = shopkeeperSO.allSpecialItem[recipeSO].ReturnKeys()[0];
            int costOfItem = shopkeeperSO.allSpecialItem[recipeSO][quantityOfItem];
            instantiatedSpecialPanel.GetComponent<SpecialItemOnSalePanel>().SetRecipeSO(recipeSO, quantityOfItem, costOfItem);
            allInstantiatedSpecialItemPanel.Add(instantiatedSpecialPanel);
        }
    }

    public void WipeoutAllIcon() {
        askPlayerFoMoney.TriggerEvent();
        buyButton.gameObject.SetActive(false);
        foreach (GameObject instantiatedWeaponPanel in allInstantiatedWeaponPanel)
        {
            Destroy(instantiatedWeaponPanel);
        }
        foreach (GameObject instantiatedFoodPanel in allInstantiatedFoodPanel)
        {
            Destroy(instantiatedFoodPanel);
        }
        foreach (GameObject instantiatedSpecialItemPanel in allInstantiatedSpecialItemPanel)
        {
            Destroy(instantiatedSpecialItemPanel);
        }
        allInstantiatedWeaponPanel.Clear();
        allInstantiatedFoodPanel.Clear();
        allInstantiatedSpecialItemPanel.Clear();
    }

    public void SetSOCurrentlyLookingAt(Component component, object obj) {
        object[] temp = (object[])obj;
        currentSO = temp[0];
    }

    public void Buy(int amount) {
        if (currentSO is WeaponSO) {
            shopkeeperSO.BuyWeapon((WeaponSO) currentSO, amount);
            List<WeaponSO> weaponToAdd = new List<WeaponSO>();
            for (int i = 0; i < amount; i++)
            {
                weaponToAdd.Add((WeaponSO) currentSO);
            }
            addWeaponToInventory.TriggerEvent(this, weaponToAdd);
            GoToWeaponOnSale();
        } else if (currentSO is FoodSO) {
            shopkeeperSO.BuyFood((FoodSO) currentSO, amount);
            List<FoodSO> foodToAdd = new List<FoodSO>();
            for (int i = 0; i < amount; i++)
            {
                foodToAdd.Add((FoodSO) currentSO);
            }
            addFoodToInventory.TriggerEvent(this, foodToAdd);
            DisplayAllFoodOnSale();
        } else if (currentSO is RecipeSO) {
            shopkeeperSO.BuySpecialItem((RecipeSO) currentSO, amount);
            List<RecipeSO> recipeToAdd = new List<RecipeSO>();
            for (int i = 0; i < amount; i++)
            {
                recipeToAdd.Add((RecipeSO) currentSO);
            }
            addSpecialItemToInventory.TriggerEvent(this, recipeToAdd);
            DisplayAllSpecialItemOnSale();
        }
        askPlayerFoMoney.TriggerEvent();
    }
}
