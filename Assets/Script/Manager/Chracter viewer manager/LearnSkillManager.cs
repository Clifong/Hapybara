using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnSkillManager : MonoBehaviour
{
    public PlayerUnlockedSkillsSO playerUnlockedSkillsSO;
    public Transform learntSkillsContent;
    public Transform allSkillsContent;
    public GameObject normalSkillPanel;
    public GameObject learnSkillPanel;
    private PlayerSO playerSO;
    private List<GameObject> spawnedLearnSkillPanel = new List<GameObject>();
    private SkillsSO skill;

    public void InstantiateAllSkillPanel() {
        
        foreach (GameObject panel in spawnedLearnSkillPanel)
        {
            Destroy(panel);
        }
        spawnedLearnSkillPanel.Clear();

        foreach (SkillsSO skillSO in playerSO.allSkills)
        {
            GameObject spawnedPanel = Instantiate(normalSkillPanel, learntSkillsContent);
            spawnedPanel.GetComponent<SkillPanel>().SetSkillSO(skillSO);
            spawnedLearnSkillPanel.Add(spawnedPanel);
        }
        foreach (SkillsSO skillSO in playerUnlockedSkillsSO.allUnlockedSkills)
        {
            if (!playerSO.allSkills.Contains(skillSO)) {
                GameObject spawnedPanel = Instantiate(learnSkillPanel, allSkillsContent);
                spawnedPanel.GetComponent<LearnSkillPanel>().SetSkillSO(skillSO);
                spawnedLearnSkillPanel.Add(spawnedPanel);
            }
        }
    }

    public void GetPlayerLearningInfo(Component component, object obj) {
        object[] temp = (object[]) obj;
        playerSO = (PlayerSO) temp[0]; 
        InstantiateAllSkillPanel();
    }

    public void LearnSkill(Component component, object obj) {
        object[] temp = (object[]) obj;
        skill = (SkillsSO) temp[0];   
    }

    public void LearnSkill() {
        playerSO.LearnSkill(skill);
        playerSO.SetDirty();
        InstantiateAllSkillPanel();
    }
}
