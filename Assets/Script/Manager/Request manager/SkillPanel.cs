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
    private SkillsSO skillsSO;
    public GameObject enlargedPopup;
    public TextMeshProUGUI enlargedPopupText;
    private bool mouse_over = false;

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
}
