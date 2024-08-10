using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippedByWhoIcon : MonoBehaviour
{
    public Image icon;

    public void SetInfo(PlayerSO playerSO) {
        playerSO.SetInfo(icon);
    }
}
