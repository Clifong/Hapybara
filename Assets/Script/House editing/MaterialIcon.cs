using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MaterialIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image materialIcon;
    public TextMeshProUGUI quantityNeeded;
    public GameObject enlargedPopup;
    public Image enlargedMaterialIcon;
    public TextMeshProUGUI materialName;
    private bool mouse_over = false;
    private MaterialSO materialSO;

    public void PopulateMaterialIconInfo(MaterialSO materialSO, int quantityNeeded) {
        this.materialSO = materialSO;
        materialIcon.sprite = materialSO.materialIcon;
        this.quantityNeeded.text = "X " + quantityNeeded.ToString();
        enlargedMaterialIcon.sprite = materialSO.materialIcon;
        materialName.text = materialSO.materialName;
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
