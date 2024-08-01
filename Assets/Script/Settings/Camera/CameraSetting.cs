using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraSettingSO", menuName = "Setting/CameraSettingSO", order = 1)]
public class CameraSetting : OneTimeObjectSO
{
    public float minZoom;
    public float maxZoom;
    public float currZoom;
}
