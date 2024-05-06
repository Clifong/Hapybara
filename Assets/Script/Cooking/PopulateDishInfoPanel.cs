using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopulateDishInfoPanel : MonoBehaviour
{
    public Image foodIcon;
    public TextMeshProUGUI foodName;
    public TextMeshProUGUI foodDescription;
    public TextMeshProUGUI effectDescriptiontext;
    public Transform contentToPopulateIngredients;
    public GameObject ingredientIcon;
    private List<GameObject> ingredientIconList = new List<GameObject>();
    private FoodSO foodSO;

    public void ReceivedFoodSOFromBroadcast(Component component, object obj) {
        object[] temp = (object[]) obj;
        foodSO = (FoodSO) temp[0];
        foodIcon.sprite = foodSO.foodIconWithoutFrame;
        foodName.text = foodSO.foodName;
        foodDescription.text = foodSO.foodDescription;
        effectDescriptiontext.text = foodSO.effectsDescription;
        foreach (GameObject icon in ingredientIconList)
        {
            Destroy(icon);
        }
        ingredientIconList.Clear();
        foreach (IngredientSO ingredient in foodSO.ingredientsNeeded.ReturnKeys())
        {
            GameObject instantiatedIngredientIcon = Instantiate(ingredientIcon, contentToPopulateIngredients);
            ingredientIconList.Add(instantiatedIngredientIcon);
            instantiatedIngredientIcon.GetComponent<IngredientIcon>().PopulateFoodIconInfo(ingredient, foodSO.ingredientsNeeded.GetValueAtKey(ingredient));
        }
    }
}
