using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnSkillPanel : SkillPanel
{
    public CrossObjectEventWithData learnThiSkill;

    public void LearnSkill() {
        learnThiSkill.TriggerEvent(this, skillsSO);
    }
}
