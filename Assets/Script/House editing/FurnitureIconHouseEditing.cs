using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FurnitureIconHouseEditing : MonoBehaviour
{
    public Image spriteIcon;
    private BuildableSO furnitureSO;
    private int quantity;
    public CrossObjectEventWithData setToThisBuildable;
    public TextMeshProUGUI qtyText;

    public void SetInfo(BuildableSO furnitureSO, int quantity) {
        this.furnitureSO = furnitureSO;
        spriteIcon.sprite = furnitureSO.previewSprite;
        this.quantity = quantity;
        qtyText.text = quantity.ToString();
    }

    public void SetToThisBuildable() {
        setToThisBuildable.TriggerEvent(this, furnitureSO, quantity);
    }
}
