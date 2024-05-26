using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlinmentIcon : MonoBehaviour
{
    public Image icon;

    public void SetInfo(Sprite sprite) {
        icon.sprite = sprite; 
    }
}
