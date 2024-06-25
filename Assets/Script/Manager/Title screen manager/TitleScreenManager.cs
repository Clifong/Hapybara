using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    

public class TitleScreenManager : MonoBehaviour
{
    [Header("Settnigs")]
    public Slider volumeSlider;
    public TextMeshProUGUI volumeLevelvalue;

    public void QuitGame() {
        Application.Quit();
        // UnityEditor.EditorApplication.isPlaying = false;
    }

    public void UpdateVolumeLevel() {
        volumeLevelvalue.text = volumeSlider.value.ToString();
    }
}
