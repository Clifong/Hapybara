using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerZoom : MonoBehaviour
{
    private CinemachineVirtualCamera vcam; 
    private float zoom;
    public CameraSetting cameraSettingSO;

    void Start()
    {
        GameObject cam = GameObject.Find("CM vcam1");
        vcam = cam.GetComponent<CinemachineVirtualCamera>();
        vcam.m_Lens.FieldOfView = cameraSettingSO.currZoom;
        zoom = cameraSettingSO.currZoom;
    }

    void OnZoom(InputValue value) {
        Vector2 offset = value.Get<Vector2>();
        if (offset.y < 0) {
            zoom += 1.0f;
        } else if (offset.y > 0) {
            zoom -= 1.0f;
        }
        if (zoom < cameraSettingSO.minZoom) {
            zoom = cameraSettingSO.minZoom;
        } else if (zoom > cameraSettingSO.maxZoom) {
            zoom = cameraSettingSO.maxZoom;
        } 
        vcam.m_Lens.FieldOfView = zoom;
        cameraSettingSO.currZoom = zoom;
    }
}
