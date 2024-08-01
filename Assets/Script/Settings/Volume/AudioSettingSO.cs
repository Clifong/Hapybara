using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "AudioSettingSO", menuName = "Setting/AudioSettingSO", order = 1)]
public class AudioSettingSO : OneTimeObjectSO
{
    public float currVolume;

    public void ChangeVolume(int value) {
        currVolume = value;
    }

    public void SetVolumeLevel(Slider slider) {
        slider.value = currVolume;
    }

    public void SetVolumeLevelText(TextMeshProUGUI volumeLevel) {
        volumeLevel.text = "Master volume level: " + currVolume;
    }
}
