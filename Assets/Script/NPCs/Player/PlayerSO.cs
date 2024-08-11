using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "Player SO", menuName = "All player SO/PlayerSO", order = 1)]
public class PlayerSO : ScriptableObject
{
    public string name;
    public bool isMainPlayer;
    [Header("Battle level")]
    public int level = 1;
    private int maxLevel = 100;
    public int currentExp = 0;
    public int expNeededForNextLevel = 0;
    [SerializedDictionary("Level", "Level up reward/obtained")]
    public SerializedDictionary<int, SkillsSO> levelUpReward = new SerializedDictionary<int, SkillsSO>();
   
    [Header("Relationship level")]
    public int relationshipLevel = 1;
    public int currentRelationshipExp = 0;
    public int expNeededForNextRelationshipLevel = 0;
    private int maxRelationshipLevel = 10;
    [Header("Battle stats")]
    public int currentHealth;
    public int health;
    public int attack;
    public int defence;
    public int speed;
    public WeaponSO weaponEquipped;
    [Header("Home")]
    public GameObject playerObject;
    public GameObject homePlayerObject;
    public bool invited;
    [Header("UI stuff")]
    public Sprite playerIcon;
    public Sprite playerAppearance;
    [Header("Skills")]
    public List<SkillsSO> allSkills;
    public List<SkillsSO> activeSkills = new List<SkillsSO>();
    [Header("Friendship panel")]
    public Sprite friendshipFrame;
    [TextAreaAttribute]
    public string lore;
    public Sprite objectOfFaith;
    public string objectOfFaithName;
    [TextAreaAttribute]
    public string objectOfFaithDescription;
    [Header("Food")]
    public int eatCounter;
    public int currAttackBuff;
    public int currAttackBuffDuration;
    public int currDefenceBuff;
    public int currDefenceBuffDuration;
    public int maxSpeedBuff;
    public int maxSpeedBuffDuration;

    
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
        while (currentExp >= expNeededForNextLevel && level < maxLevel) {
            currentExp = Mathf.Max(0, currentExp - expNeededForNextLevel);
            level = Mathf.Min(level + 1, maxLevel);
            health = (int) (health * 1.1);
            attack = Mathf.Max((int) (attack * 1.1), attack + 1);
            defence = Mathf.Max((int) (defence * 1.1), defence + 1);
            speed = Mathf.Max((int) (speed * 1.1), speed + 1);
            CalculateExpNeededForNextLevel(currentExp);
        }
        this.SetDirty();
    }

    public void LevelUpRelationship() {
        while (currentRelationshipExp >= expNeededForNextRelationshipLevel && relationshipLevel < maxRelationshipLevel) {
            currentRelationshipExp = Mathf.Max(0, currentRelationshipExp - expNeededForNextRelationshipLevel);
            relationshipLevel = Mathf.Min(relationshipLevel + 1, maxRelationshipLevel);
            CalculateExpNeededForNextRelationshipLevel(currentRelationshipExp);
        }
        this.SetDirty();
    }

    public void EquipWeapon(WeaponSO weaponSO) {
        weaponEquipped = weaponSO;
        health += weaponEquipped.maxHealthChange;
        attack += weaponEquipped.attackChange;
        defence += weaponEquipped.defenceChange;
        speed += weaponEquipped.speedChange;
        weaponSO.owner.Add(this);
        this.SetDirty();
        weaponEquipped.SetDirty();
    }

    public void UnequipWeapon() {
        health -= weaponEquipped.maxHealthChange;
        attack -= weaponEquipped.attackChange;
        defence -= weaponEquipped.defenceChange;
        speed -= weaponEquipped.speedChange;
        weaponEquipped.owner.Remove(this);
        weaponEquipped.SetDirty();
        weaponEquipped = null;
        this.SetDirty();
        
    }

    public void PopulateStatText(TextMeshProUGUI healthText, TextMeshProUGUI attackText, TextMeshProUGUI defenceText, TextMeshProUGUI speedText) {
        healthText.text = health.ToString();
        attackText.text = attack.ToString();
        defenceText.text = defence.ToString();
        speedText.text = speed.ToString();
    }

    public void SetInfo(Image icon, TextMeshProUGUI nameText) {
        icon.sprite = playerIcon;
        nameText.text = name;
    }

    public void SetInfo(Image icon) {
        icon.sprite = playerIcon;
    }

    public void SetFrameInfo(Image frame, Image objectOfFaithImage, Image playerIconImage, TextMeshProUGUI loreText, Button oofButton) {
        frame.sprite = friendshipFrame;
        objectOfFaithImage.sprite = objectOfFaith; 
        playerIconImage.sprite = playerIcon;
        loreText.text = lore;
        if (relationshipLevel < 5) {
            oofButton.enabled = false;
            objectOfFaithImage.color = new Color(0f,0f,0f,.2f);
        } else {
            oofButton.enabled = true;
            objectOfFaithImage.color = new Color(255f,256f,256f,1f);
        }
    }

    public void SetOOFInfo(Image enlargedImage, TextMeshProUGUI OOFName, TextMeshProUGUI OOFDescription) {
        enlargedImage.sprite = objectOfFaith;
        OOFName.text = objectOfFaithName;
        OOFDescription.text = objectOfFaithDescription;
    }

    public void SetHungerValue(TextMeshProUGUI hungerValueText, Button okButton) {
        hungerValueText.text = "Hunger value:" + eatCounter + "/3";
        if (eatCounter == 3) {
            okButton.gameObject.SetActive(false);
        } else {
            okButton.gameObject.SetActive(true);
        }
    }

    public void Feed(FoodSO foodSO) {
        eatCounter += 1;
        foodSO.GainBuffFromEating(this);
    }
    
    public void CountDownBuffTimer() {
        currAttackBuffDuration = Mathf.Max(0, currAttackBuffDuration - 1);
        currDefenceBuffDuration = Mathf.Max(0, currDefenceBuffDuration - 1);
        maxSpeedBuff = Mathf.Max(0, maxSpeedBuffDuration - 1);
        if (currAttackBuffDuration == 0) {
            attack -= currAttackBuff;
            currAttackBuff = 0;
        }
        if (currDefenceBuffDuration == 0) {
            defence -= currDefenceBuff;
            currDefenceBuff = 0;
        }
        if (maxSpeedBuff == 0) {
            speed -= maxSpeedBuff;
            maxSpeedBuff = 0;
        }
    }

    public void EmptyTummy() {
        eatCounter = Mathf.Max(0, eatCounter - 1);
    }

    public void DisplayAllSKill(Transform content, GameObject skillIcon, List<GameObject> spawnedIcons, int numberOfSkillPoint) {
        foreach (SkillsSO skillSO in activeSkills)
        {
            if (skillSO.skillCost > numberOfSkillPoint) {
                continue;
            }
            GameObject spawnedSkillIcon = Instantiate(skillIcon, content);
            SkillIconBattle skillIconBattle = spawnedSkillIcon.GetComponent<SkillIconBattle>();
            skillIconBattle.DisplayIcon(skillSO);
            spawnedIcons.Add(spawnedSkillIcon);
        }
    }

    public void LearnSkill(SkillsSO skill) {
        if (!allSkills.Contains(skill)) {
            allSkills.Add(skill);
        }
    }

    public void AdjustLevelUpReward(Slider rewardSlider, TextMeshProUGUI levelText, Transform content, GameObject rewardPanel, List<GameObject> spawnedPanels) {
        rewardSlider.value = level;
        levelText.text = level.ToString();
        List<int> allLevels = (List<int>) levelUpReward.ReturnKeys();
        foreach (int number in allLevels)
        {
            GameObject spawnedPanel = Instantiate(rewardPanel, content);
            spawnedPanel.GetComponent<LevelUpRewardSkillPanel>().SetSkillSO(levelUpReward[number], level >= number, number);
            spawnedPanels.Add(spawnedPanel);
        }
    }

    public void RecoverMaxHealth() {
        currentHealth = health;
    }
    
}
