using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    private int numberOfSkillPoint;
    public List<Animator> ballPoint;
    [Header("Player's skill bar")]
    public Transform content;
    public GameObject skillIcon;
    private List<GameObject> spawnedSkillIcons = new List<GameObject>();
    private Player currPlayer = null;

    public void Reset() {
        RemoveAllIcons();
        numberOfSkillPoint = 5;
        for (int i = 0; i <= numberOfSkillPoint - 1; i++) {
            ballPoint[i].SetBool("Active", true);
        }
    }

    private void RemoveAllIcons() {
        foreach (GameObject spawnedIcon in spawnedSkillIcons)
        {
            Destroy(spawnedIcon);
        }
    }

    public void UseBallPoint(Component component, object obj) {
        object[] temp = (object[]) obj;
        int point = (int) temp[0];
        for (int i = numberOfSkillPoint - 1; i >= numberOfSkillPoint - point; i --) {
            ballPoint[i].SetBool("Active", false);
        }
        numberOfSkillPoint -= point;
    }

    public void GainBallPoint() {
        if (numberOfSkillPoint <= 4) {
            ballPoint[numberOfSkillPoint].SetBool("Active", true);
        }
        numberOfSkillPoint = Mathf.Min(numberOfSkillPoint + 1, 5);
    }

    public void DisplaySkills(Component component, object obj) {
        RemoveAllIcons();
        object[] temp = (object[]) obj;
        currPlayer = ((Player) temp[0]);
        spawnedSkillIcons.Clear();
        currPlayer.playerSO.DisplayAllSKill(content, skillIcon, spawnedSkillIcons, numberOfSkillPoint);
        if (spawnedSkillIcons.Count >= 1) {
            spawnedSkillIcons[0].GetComponent<SkillIconBattle>().ActivateGlow();
        }
    }

    public void SetSkill(Component component, object obj) {
        object[] temp = (object[]) obj;
        int skillValue = ((int) temp[0]);
        foreach (GameObject skillIcon in spawnedSkillIcons)
        {
            skillIcon.GetComponent<SkillIconBattle>().DeactivateGlow();
        }
        if (skillValue >= spawnedSkillIcons.Count) {
            if (spawnedSkillIcons.Count - 1 < 0) {
                return;
            }
            spawnedSkillIcons[spawnedSkillIcons.Count - 1].GetComponent<SkillIconBattle>().ActivateGlow();
        } else {
            spawnedSkillIcons[skillValue].GetComponent<SkillIconBattle>().ActivateGlow();
        }
    }

    void Update() {
        if (content.childCount == 0) {
            if (currPlayer != null) {
                currPlayer.CannotUseSkill();
            }
        } else {
            if (currPlayer != null) {
                currPlayer.CanUseSkill();
            }
        }
    }
    
}
