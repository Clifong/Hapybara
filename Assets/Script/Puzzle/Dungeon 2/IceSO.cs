using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "IceSO", menuName = "Ice SO", order = 1)]
public class IceSO : OneTimeObjectSO 
{
    public int matchstickNeeded;

    public void SetMatchstickNeeded(TextMeshProUGUI text) {
        text.text = matchstickNeeded.ToString();
    }

    public bool CheckIfEnough(int amt) {
        return amt >= matchstickNeeded;
    }
}

