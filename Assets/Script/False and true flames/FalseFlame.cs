using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseFlame : TrueFlame
{
    public CrossObjectEvent rightAnswer;

    public override void Interact() {
        rightAnswer.TriggerEvent();
        DestroyFlame();
    }
}
