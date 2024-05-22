using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class IngredientIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image ingredientIcon;
    public TextMeshProUGUI quantityNeeded;
    public GameObject enlargedPopup;
    public Image enlargedIngredientIcon;
    public TextMeshProUGUI ingredientName;
    private bool mouse_over = false;
    private IngredientSO ingredientSO;

    public void PopulateFoodIconInfo(IngredientSO ingredientSO, int quantityNeeded) {
        this.ingredientSO = ingredientSO;
        ingredientIcon.sprite = ingredientSO.ingredientIconWithFrame;
        this.quantityNeeded.text = "X " + quantityNeeded.ToString();
        enlargedIngredientIcon.sprite = ingredientSO.ingredientIconWithoutFrame;
        ingredientName.text = ingredientSO.ingredientName;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
    }

    void Update() {
        if (mouse_over) {
            enlargedPopup.SetActive(true);
        } else {
            enlargedPopup.SetActive(false);
        }
    }
}
