using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterViewerManager : MonoBehaviour
{
    public PlayerPartySO playerPartySO;
    public GameObject partyMemberIcon;
    public CrossObjectEventWithData updatePlayerStats;
    public Transform content;
    private List<GameObject> allPlayerMemberInstantiatedIcons = new List<GameObject>();

    [Header("Bottom section stuff/Main page")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenceText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI levelText;
    public Image characterImage;
    public Slider expSlider;
    public TextMeshProUGUI expneededText;
    public TextMeshProUGUI relationshipLevelText;
    public Slider relationshipExpSlider;
    public TextMeshProUGUI relationshipExpNeededText;
    public Image weaponEquippedIcon;
    public Sprite noEquipmentEquippedDefault;
    private PlayerSO playerSO;
    [Header("Bottom section stuff/Skills page")]
    public GameObject skillPanel;
    public Transform skillContent;
    private List<GameObject> allSpawnedSkillsPanel = new List<GameObject>();

    public void InstantiatePartyMemberIcons() {
        foreach (GameObject icon in allPlayerMemberInstantiatedIcons)
        {
            Destroy(icon);
        }
        allPlayerMemberInstantiatedIcons.Clear();
        foreach (PlayerSO playerSO in playerPartySO.allPartyMembers)
        {
            GameObject instantiatedPlayerIcon = Instantiate(partyMemberIcon, content);
            instantiatedPlayerIcon.GetComponent<PartyMemberIcon>().SetPlayerInfo(playerSO);
            allPlayerMemberInstantiatedIcons.Add(instantiatedPlayerIcon);
        }
    }

    public void PopulateBottomUI(Component component, object obj) {
        object[] temp = (object[]) obj;
        playerSO = (PlayerSO) temp[0];
        SetStats(playerSO);
    }

    private void SetStats(PlayerSO playerSO) {
        healthText.text = playerSO.health.ToString();
        attackText.text = playerSO.attack.ToString();
        defenceText.text = playerSO.defence.ToString();
        speedText.text = playerSO.speed.ToString();
        characterImage.sprite = playerSO.playerAppearance;
        
        levelText.text = playerSO.level.ToString();
        expSlider.value = (float)playerSO.currentExp/(float)(playerSO.currentExp + playerSO.expNeededForNextLevel);
        expneededText.text = "Require: " + playerSO.expNeededForNextLevel.ToString();
        
        relationshipLevelText.text = playerSO.relationshipLevel.ToString();
        relationshipExpSlider.value = (float)playerSO.currentRelationshipExp/(float)(playerSO.currentRelationshipExp + playerSO.expNeededForNextRelationshipLevel);
        relationshipExpNeededText.text = "Require: " + playerSO.expNeededForNextRelationshipLevel.ToString();
        
        if (playerSO.weaponEquipped != null) {
            weaponEquippedIcon.sprite = playerSO.weaponEquipped.weaponIcon;
        } else {
            weaponEquippedIcon.sprite = noEquipmentEquippedDefault;
        }
        foreach (GameObject spawnedSkillPanel in allSpawnedSkillsPanel)
        {
            Destroy(spawnedSkillPanel);
        }
        allSpawnedSkillsPanel.Clear();
        foreach (SkillsSO skillsSO in playerSO.allSkills)
        {
            GameObject spawnedSkillPanel = Instantiate(skillPanel, skillContent);
            allSpawnedSkillsPanel.Add(spawnedSkillPanel);
            spawnedSkillPanel.GetComponent<SkillPanel>().SetSkillSO(skillsSO);
        }
    }

    public void RefreshData() {
        SetStats(playerSO);
        updatePlayerStats.TriggerEvent(this, playerSO);
    }
}
