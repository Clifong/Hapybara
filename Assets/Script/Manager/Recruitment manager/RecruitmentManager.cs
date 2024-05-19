using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecruitmentManager : MonoBehaviour
{
    public List<GameObject> instantiatedSkillPanels = new List<GameObject>();
    public GameObject skillPanel;
    private PlayerSO playerSO;
    [Header("UI")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenceText;
    public TextMeshProUGUI speedText;
    public Transform content;

    public void PopulateUI(PlayerSO playerSO) {
        foreach (GameObject instantiatedSkillPanel in instantiatedSkillPanels)
        {
            Destroy(instantiatedSkillPanel);
        }
        instantiatedSkillPanels.Clear();
        this.playerSO = playerSO;
        this.playerSO.PopulateStatText(healthText, attackText, defenceText, speedText);
        foreach (SkillsSO skillSO in playerSO.allSkills)
        {
            GameObject instantiatedSkillPanel = Instantiate(skillPanel, content);
            instantiatedSkillPanels.Add(instantiatedSkillPanel);
            instantiatedSkillPanel.GetComponent<SkillPanel>().SetSkillSO(skillSO);
        }
    }
}
