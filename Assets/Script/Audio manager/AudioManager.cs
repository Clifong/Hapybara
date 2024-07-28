using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource mapAudioPlauer;
    public CrossObjectEvent audioEnded;
    // Start is called before the first frame update
    void Awake()
    {
        mapAudioPlauer = GetComponent<AudioSource>();
        mapAudioPlauer.loop = false;
    }

    public void PlayAudio(Component component, object obj) {
        object[] temp = (object[]) obj;
        AudioClip audioClip = (AudioClip) temp[0];
        mapAudioPlauer.clip = audioClip;
        mapAudioPlauer.Play();
    }

    void Update() {
        if (!mapAudioPlauer.isPlaying) {
            audioEnded.TriggerEvent();
        }
    }
}
