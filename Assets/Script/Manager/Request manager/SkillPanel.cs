using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SkillPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image skillIcon;
    public TextMeshProUGUI skillName;
    protected SkillsSO skillsSO;
    public GameObject enlargedPopup;
    public TextMeshProUGUI enlargedPopupText;
    public Toggle toggle;
    private bool mouse_over = false;
    private PlayerSO playerSO;

    public void SetSkillSO(SkillsSO skillsSO, PlayerSO playerSO) {
        this.skillsSO = skillsSO;
        skillName.text = skillsSO.skillName;
        skillIcon.sprite = skillsSO.skillIcon;
        enlargedPopupText.text = skillsSO.skillDescription;
        toggle.isOn = playerSO.activeSkills.Contains(skillsSO);
        this.playerSO = playerSO;
    }

    public void SetSkillSO(SkillsSO skillsSO) {
        this.skillsSO = skillsSO;
        skillName.text = skillsSO.skillName;
        skillIcon.sprite = skillsSO.skillIcon;
        enlargedPopupText.text = skillsSO.skillDescription;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
    }

    void Update() {
        if (mouse_over) {
            enlargedPopup.SetActive(true);
        } else {
            enlargedPopup.SetActive(false);
        }
    }

    public void ChangeSkill() {
        if (playerSO != null) {
            if (toggle.isOn) {
                if (playerSO.activeSkills.Count == 3) {
                    toggle.isOn = false;
                } else {
                    playerSO.activeSkills.Add(skillsSO);
                }
            } else {
                playerSO.activeSkills.Remove(skillsSO);
            }
        }
    }
}
