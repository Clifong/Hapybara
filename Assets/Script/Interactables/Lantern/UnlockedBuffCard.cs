using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnlockedBuffCard : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI description;
    private DungeonBuffSO buff;

    public void SetBuffSO(DungeonBuffSO buff) {
        this.buff = buff;
        buff.PopulateUI(icon, name, description);
    }

}
