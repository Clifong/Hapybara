using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class InventoryDescriptionPanels : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI description;

    [Header("Stats change poriton of the UI")]
    public TextMeshProUGUI maxHealthChange;
    public TextMeshProUGUI attackChange;
    public TextMeshProUGUI defenceChange;
    public TextMeshProUGUI speedChange;
    public TextMeshProUGUI effectsDescription;

    public virtual void PopulateUI(Component component, object obj) {}
}
