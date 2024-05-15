using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiPurchaseManager : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI quantityToBuy;
    public Button minusButton;
    public Button addButton;
    private int maxValue;
    private ShopManager shopManager;
    private int moneyIHave;
    private int costOfOneItem;
    public CrossObjectEventWithData minusMoney;
    public Button buyButton;

    void Start() {
        shopManager = GetComponent<ShopManager>();
    }

    public void SetAmountOfMoneyIHave(Component component, object obj) {
        object[] temp = (object[])obj;
        moneyIHave = (int) temp[0];
    }

    public void SetSliderInfo(Component component, object obj) {
        object[] temp = (object[])obj;
        costOfOneItem = (int) temp[2]; //Broadcast info is SO, qty, cost
        maxValue = (int) Mathf.Floor((float)moneyIHave/(float)costOfOneItem);
        slider.value = 1;
        slider.minValue = 1;
        slider.maxValue = maxValue;
        quantityToBuy.text = "1";
    }
    
    public void MinusValue() {
        slider.value = Mathf.Max(1, slider.value - 1);
        quantityToBuy.text = slider.value.ToString();
    }

    public void MaxValue() {
        slider.value = Mathf.Min(maxValue, slider.value + 1);
        quantityToBuy.text = slider.value.ToString();
    }

    public void AdjustValueAsSliderChange() {
        quantityToBuy.text = slider.value.ToString();
    }

    public void Buy() {
        minusMoney.TriggerEvent(this, (int)(slider.value * costOfOneItem));
        shopManager.Buy((int) slider.value);
    }
}
