using UnityEngine;

public class CameraBobbing : MonoBehaviour
{
    public float bobFrequency = 6f;     // How fast the bobbing happens
    public float bobAmplitude = 0.05f;  // How much it bobs
    public RunnerMovement playerScript;

    private Vector3 startLocalPos;
    private float bobTimer;

    void Start()
    {
        startLocalPos = transform.localPosition;

        if (playerScript == null)
        {
            playerScript = GetComponentInParent<RunnerMovement>();
        }
    }

    void Update()
    {
        if (playerScript == null || playerScript.forwardSpeed <= 0.1f)
        {
            // Reset bobbing when not running
            bobTimer = 0f;
            transform.localPosition = Vector3.Lerp(transform.localPosition, startLocalPos, Time.deltaTime * 5f);
            return;
        }

        // Bobbing when moving
        bobTimer += Time.deltaTime * bobFrequency;
        float bobY = Mathf.Sin(bobTimer) * bobAmplitude;

        Vector3 bobPosition = startLocalPos + new Vector3(0f, bobY, 0f);
        transform.localPosition = bobPosition;
    }
}
