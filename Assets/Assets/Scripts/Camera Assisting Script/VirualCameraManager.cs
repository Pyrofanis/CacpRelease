using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class VirualCameraManager : MonoBehaviour
{

    private CinemachineVirtualCamera virtualCamera;
    private CinemachineConfiner virtualCmConfiner;
    [Header("Camera Colliders In Scene")]
    [Min(1)]
    public List<Collider> cameraColliders;

    private void Awake()
    {
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        virtualCmConfiner = virtualCamera.GetComponent<CinemachineConfiner>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (cameraColliders.Contains(collision))
        {
            virtualCmConfiner.m_BoundingVolume = collision;
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if (cameraColliders.Contains(collision))
        {
            virtualCmConfiner.m_BoundingVolume = collision;
        }
    }

}
