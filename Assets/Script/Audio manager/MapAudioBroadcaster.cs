using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAudioBroadcaster : MonoBehaviour
{
    public AudioClip audioClip;
    public CrossObjectEventWithData audioClipBroadcaster;

    void Start()
    {
        audioClipBroadcaster.TriggerEvent(this, audioClip);
    }

    
}
