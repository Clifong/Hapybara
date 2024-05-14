using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Weapon SO", order = 1)]
public class WeaponSO : ScriptableObject
{
    [Header("Information")]
    public Sprite weaponIconWithFrame;
    public Sprite weaponIconWithoutFrame;
    public string weaponName;
    [TextAreaAttribute]
    public string weaponDescription;
    [Header("Stats boost")]
    public int maxHealthChange;
    public int attackChange;
    public int defenceChange;
    
    public int speedChange;
    public bool equipped;
    [Header("Effects")]
    [TextAreaAttribute]
    public string effectsDescription;

    public void SetUIInfoWithFrame(Image icon, TextMeshProUGUI text) {
        icon.sprite = weaponIconWithFrame;
        text.text = weaponName;
    }

    public void SetUIInfoWithoutFrame(Image icon, TextMeshProUGUI text) {
        icon.sprite = weaponIconWithoutFrame;
        text.text = weaponName;
    }

    public void FillUpDefaultInfo(TextMeshProUGUI maxHealthChangeText, TextMeshProUGUI attackChangeText, TextMeshProUGUI defenceChangeText, TextMeshProUGUI speedChangeText, TextMeshProUGUI effectsDescriptionText) {
        maxHealthChangeText.text = maxHealthChange.ToString();
        attackChangeText.text = attackChange.ToString();
        defenceChangeText.text = defenceChange.ToString();
        speedChangeText.text = speedChange.ToString();
        effectsDescriptionText.text = effectsDescription;
    }
}
