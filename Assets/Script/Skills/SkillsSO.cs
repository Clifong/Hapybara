using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillsSO : ScriptableObject
{
    public Sprite skillIcon;
    public string skillName;
    [TextAreaAttribute]
    public string skillDescription;
    public int damage;
}
