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

    [Header("Bottom section stuff")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenceText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI expneededText;
    public Image weaponEquippedIcon;
    public Sprite noEquipmentEquippedDefault;
    public Slider expSlider;
    private PlayerSO playerSO;

    public void InstantiatePartyMemberIcons() {
        foreach (GameObject icon in allPlayerMemberInstantiatedIcons)
        {
            Destroy(icon);
        }
        allPlayerMemberInstantiatedIcons.Clear();
        foreach (PlayerSO playerSO in playerPartySO.allPlayersInParty)
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
        levelText.text = playerSO.level.ToString();
        expSlider.value = (float)playerSO.currentExp/(float)(playerSO.currentExp + playerSO.expNeededForNextLevel);
        expneededText.text = playerSO.expNeededForNextLevel.ToString();
        if (playerSO.weaponEquipped != null) {
            weaponEquippedIcon.sprite = playerSO.weaponEquipped.weaponIconWithoutFrame;
        } else {
            weaponEquippedIcon.sprite = noEquipmentEquippedDefault;
        }
    }

    public void RefreshData() {
        Debug.Log("?");
        SetStats(playerSO);
        updatePlayerStats.TriggerEvent(this, playerSO);
    }
}
