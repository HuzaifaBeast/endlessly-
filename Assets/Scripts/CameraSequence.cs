using UnityEngine;
using Cinemachine;
using System.Collections;
using TMPro;

public class CameraSequence : MonoBehaviour
{
    public CinemachineVirtualCamera vcam1; // Intro (Spiderman/logo)
    public CinemachineVirtualCamera vcam2; // Villains
    public CinemachineVirtualCamera vcam3; // Gameplay

    public RunnerMovement runnerScript; // gameplay script

    [Header("Dialog")]
    public AudioSource dialogSource;   // AudioSource for dialog
    public AudioClip bringHimBackClip; // Assign audio file here
    public TextMeshProUGUI subtitleText; // UI text for subtitle

    private bool hasSequenceStarted = false;

    void Start()
    {
        // --- Force Far Clip Plane = 80 for all vcams ---
        if (vcam1 != null) vcam1.m_Lens.FarClipPlane = 80f;
        if (vcam2 != null) vcam2.m_Lens.FarClipPlane = 80f;
        if (vcam3 != null) vcam3.m_Lens.FarClipPlane = 80f;

        // Start with VCam1 active
        vcam1.Priority = 20;
        vcam2.Priority = 10;
        vcam3.Priority = 5;

        if (subtitleText != null)
            subtitleText.gameObject.SetActive(false);
    }

    // Called from Play Button
    public void StartCameraSequence()
    {
        if (!hasSequenceStarted)
        {
            hasSequenceStarted = true;
            StartCoroutine(CameraFlow());
        }
    }

    IEnumerator CameraFlow()
    {
        // --- STEP 1: Switch to Villains camera ---
        vcam2.Priority = 30;
        vcam1.Priority = 10;

        // --- STEP 2: Start zoom immediately ---
        float startFOV = vcam2.m_Lens.FieldOfView;
        float targetFOV = 70f; // wider cinematic view
        float duration = 4.5f;
        float time = 0;

        // Start dialog coroutine after 2s (while zoom is running)
        StartCoroutine(PlayDialogWithDelay(2f));

        while (time < duration)
        {
            time += Time.deltaTime;
            vcam2.m_Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, time / duration);
            yield return null;
        }

        // --- STEP 4: Switch to gameplay camera ---
        vcam3.Priority = 40;
        vcam2.Priority = 10;

        // Start the game
        runnerScript.hasStarted = true;
    }

    IEnumerator PlayDialogWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (dialogSource != null && bringHimBackClip != null)
        {
            dialogSource.clip = bringHimBackClip;
            dialogSource.Play();

            if (subtitleText != null)
            {
                subtitleText.text = "Bring him back to me";
                subtitleText.gameObject.SetActive(true);

                yield return new WaitForSeconds(bringHimBackClip.length);

                subtitleText.gameObject.SetActive(false);
            }
        }
    }
}
