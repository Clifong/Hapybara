using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchstickManager : MonoBehaviour
{
    public TextMeshProUGUI quantity;
    private int matchstick;
    
    public void PopulateUI(Component component, object obj) {
        object[] temp = (object[])obj;
        matchstick = (int) temp[0];
        quantity.text = matchstick.ToString();
    }
    
    
}
