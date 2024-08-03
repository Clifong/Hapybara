using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SkillsSO : ScriptableObject
{
    public Sprite skillIcon;
    public string skillName;
    public int skillCost;
    
    [TextAreaAttribute]
    public string skillDescription;
    public int damage;

    public void DisplayIcon(Image image) {
        image.sprite = skillIcon;
    }

    
}
