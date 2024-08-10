using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardIcon : MonoBehaviour
{
    public Image grid;
    public Image sprite;
    public TextMeshProUGUI qtyText;
    [Header("Grid")]
    public Sprite foodGrid;
    public Sprite WeaponGrid;
    public Sprite ingredientGrid;
    public Sprite materialGrid;
    public Sprite furnitureGrid;
    public Sprite recipeGrid;

    public void SetInfo(object someSO, int quantity) {
        qtyText.text = quantity.ToString();
        if (someSO is FoodSO) {
            FoodSO foodSO = (FoodSO) someSO;
            grid.sprite = foodGrid;
            foodSO.SetInfo(sprite);
        } else if (someSO is WeaponSO) {
            WeaponSO weaponSO = (WeaponSO) someSO;
            grid.sprite = WeaponGrid;
            weaponSO.SetInfo(sprite);
        } else if (someSO is IngredientSO) {
            IngredientSO ingredientSO = (IngredientSO) someSO;
            grid.sprite = ingredientGrid;
            ingredientSO.SetInfo(sprite);
        } else if (someSO is MaterialSO) {
            MaterialSO materialSO = (MaterialSO) someSO;
            grid.sprite = materialGrid;
            materialSO.SetInfo(sprite);
        } else if (someSO is BuildableSO) {
            BuildableSO buildableSO = (BuildableSO) someSO;
            grid.sprite = materialGrid;
            buildableSO.SetInfo(sprite);
        } else if (someSO is FurnitureRecipeSO) {
            FurnitureRecipeSO furnitureRecipeSO = (FurnitureRecipeSO) someSO;
            grid.sprite = recipeGrid;
            furnitureRecipeSO.SetInfo(sprite);
        }
    }
}
