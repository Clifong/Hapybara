using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "Player SO", menuName = "All player SO/PlayerSO", order = 1)]
public class PlayerSO : ScriptableObject
{
    public string name;
    [Header("Battle level")]
    public int level = 1;
    public int currentExp = 0;
    public int expNeededForNextLevel = 0;
    [Header("Relationship level")]
    public int relationshipLevel = 1;
    public int currentRelationshipExp = 0;
    public int expNeededForNextRelationshipLevel = 0;
    [Header("Battle stats")]
    public int health;
    public int attack;
    public int defence;
    public int speed;
    public WeaponSO weaponEquipped;
    public GameObject playerObject;
    public GameObject homePlayerObject;
    public bool invited;

    void Awake() {
        CalculateExpNeededForNextLevel(currentExp);
        CalculateExpNeededForNextRelationshipLevel(currentExp);
    }

    private void CalculateExpNeededForNextLevel(int expGained) {
        expNeededForNextLevel = (int)(level * 100 * 1.25 - expGained);
    }

    private void CalculateExpNeededForNextRelationshipLevel(int expGained) {
        expNeededForNextRelationshipLevel = (int)(relationshipLevel * 100 - expGained);
    }

    public void GainExp(int exp) {
        currentExp += exp;
        CalculateExpNeededForNextLevel(currentExp);
        LevelUp();
    }

    public void GainRelationshipExp(int exp) {
        currentRelationshipExp += exp;
        CalculateExpNeededForNextRelationshipLevel(currentRelationshipExp);
        LevelUpRelationship();
    }

    public void LevelUp() {
        while (currentExp > expNeededForNextLevel) {
            currentExp = Mathf.Max(0, currentExp - expNeededForNextLevel);
            level += 1;
            CalculateExpNeededForNextLevel(currentExp);
        }
    }

    public void LevelUpRelationship() {
        while (currentRelationshipExp > expNeededForNextRelationshipLevel) {
            currentRelationshipExp = Mathf.Max(0, currentRelationshipExp - expNeededForNextRelationshipLevel);
            relationshipLevel += 1;
            CalculateExpNeededForNextRelationshipLevel(currentRelationshipExp);
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

    public void SetInfo(Image icon, TextMeshProUGUI nameText) {
        icon.sprite = playerIcon;
        nameText.text = name;
    }
    
    [Header("UI stuff")]
    public Sprite playerIcon;
    public Sprite playerAppearance;
    [Header("Skills")]
    public List<SkillsSO> allSkills;
}
