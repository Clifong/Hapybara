using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterViewerManager : MonoBehaviour
{
    public PlayerPartySO playerPartySO;
    public GameObject partyMemberIcon;
    public Transform content;
    private List<GameObject> allPlayerMemberInstantiatedIcons = new List<GameObject>();

    [Header("Bottom section stuff")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenceText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI levelText;
    public Slider expSlider;

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
        PlayerSO playerSO = (PlayerSO) temp[0];
        healthText.text = playerSO.health.ToString();
        attackText.text = playerSO.attack.ToString();
        defenceText.text = playerSO.defence.ToString();
        speedText.text = playerSO.speed.ToString();
        levelText.text = playerSO.level.ToString();
        expSlider.value = (float)playerSO.currentExp/(float)(playerSO.currentExp + playerSO.expNeededForNextLevel);
    }
}
