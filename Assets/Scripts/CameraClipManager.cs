using UnityEngine;
using Cinemachine;

public class CameraClipManager : MonoBehaviour
{
    public float nearClip = 0.3f;
    public float farClip = 200f; // Set whatever distance you want

    void Start()
    {
        // Find all Virtual Cameras in the scene
        CinemachineVirtualCamera[] vcams = FindObjectsOfType<CinemachineVirtualCamera>();

        foreach (var vcam in vcams)
        {
            vcam.m_Lens.NearClipPlane = nearClip;
            vcam.m_Lens.FarClipPlane = farClip;
        }

        // Also apply to the Main Camera if needed
        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            mainCam.nearClipPlane = nearClip;
            mainCam.farClipPlane = farClip;
        }
    }
}
