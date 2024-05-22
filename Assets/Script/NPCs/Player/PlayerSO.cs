using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Player SO", menuName = "All player SO/PlayerSO", order = 1)]
public class PlayerSO : ScriptableObject
{
    public string name;
    public int level = 1;
    public int currentExp = 0;
    public int expNeededForNextLevel = 0;
    public int health;
    public int attack;
    public int defence;
    public int speed;
    public WeaponSO weaponEquipped;
    public GameObject playerObject;

    void Awake() {
        CalculateExpNeededForNextLevel();
    }

    private void CalculateExpNeededForNextLevel() {
        expNeededForNextLevel = (int)(level * 100 * 1.25);
    }

    public void LevelUp() {
        while (currentExp > expNeededForNextLevel) {
            currentExp = Mathf.Max(0, currentExp - expNeededForNextLevel);
            level += 1;
            CalculateExpNeededForNextLevel();
        }
    }

    public void EquipWeapon(WeaponSO weaponSO) {
        weaponEquipped = weaponSO;
        health += weaponEquipped.maxHealthChange;
        attack += weaponEquipped.attackChange;
        defence += weaponEquipped.defenceChange;
        speed += weaponEquipped.speedChange;
        weaponSO.owner = this;
    }

    public void UnequipWeapon() {
        health -= weaponEquipped.maxHealthChange;
        attack -= weaponEquipped.attackChange;
        defence -= weaponEquipped.defenceChange;
        speed -= weaponEquipped.speedChange;
        weaponEquipped.owner = null;
        weaponEquipped = null;
    }

    public void PopulateStatText(TextMeshProUGUI healthText, TextMeshProUGUI attackText, TextMeshProUGUI defenceText, TextMeshProUGUI speedText) {
        healthText.text = health.ToString();
        attackText.text = attack.ToString();
        defenceText.text = defence.ToString();
        speedText.text = speed.ToString();
    }

    public void Feed(FoodSO foodSO) {
        
    }
    
    [Header("UI stuff")]
    public Sprite playerIcon;
    public Sprite playerAppearance;
    [Header("Skills")]
    public List<SkillsSO> allSkills;
}
