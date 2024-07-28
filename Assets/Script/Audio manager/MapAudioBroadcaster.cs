using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAudioBroadcaster : MonoBehaviour
{
    public List<AudioClip> allAudioToBePlayed;
    public CrossObjectEventWithData audioClipBroadcaster;

    void Start()
    {
        PlayRandomMapMusic();
    }

    public void PlayRandomMapMusic() {
        audioClipBroadcaster.TriggerEvent(this, allAudioToBePlayed[Random.Range(0, allAudioToBePlayed.Count - 1)]);
    }

    
}
