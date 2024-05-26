using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernRecruitmentManager : MonoBehaviour
{
    public List<GameObject> instantiatedCharacterIcons = new List<GameObject>();
    private RecruitmentManager recruitmentManager;
    public Transform content;
    public GameObject spotlight;
    public GameObject mainPanel;
    public CrossObjectEventWithData joinParty;
    private PlayerSO currentPlayer;
    private Dictionary<PlayerSO, GameObject> instantiatedCharacterIconsMapping = new Dictionary<PlayerSO, GameObject>();

    void Start() {
        recruitmentManager = GetComponent<RecruitmentManager>();
    }

    public void PopulateUI(BartenderSO bartenderSO) {
        mainPanel.SetActive(true);
        foreach (GameObject instantiatedCharacterIcon in instantiatedCharacterIcons)
        {
            Destroy(instantiatedCharacterIcon);
        }instantiatedCharacterIconsMapping.Clear();
        instantiatedCharacterIcons.Clear();
        foreach (PlayerSO playerSO in bartenderSO.allRecruitablePlayer)
        {
            GameObject instantiatedSpotlight = Instantiate(spotlight, content);
            instantiatedCharacterIcons.Add(instantiatedSpotlight);
            instantiatedSpotlight.GetComponent<TavernSpotlight>().SetIcon(playerSO);
            instantiatedCharacterIconsMapping[playerSO] = instantiatedSpotlight;
        }
    }

    public void BroadcastPlayerData(Component component, object obj) {
        object[] temp = (object[])obj;
        currentPlayer = (PlayerSO) temp[0];
        recruitmentManager.PopulateUI(currentPlayer);
    }

    public void PlayerJoin() {
        Destroy(instantiatedCharacterIconsMapping[currentPlayer]);
        instantiatedCharacterIconsMapping.Remove(currentPlayer);
        joinParty.TriggerEvent(this, currentPlayer);
    }

}
