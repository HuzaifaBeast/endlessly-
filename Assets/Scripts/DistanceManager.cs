using UnityEngine;
using TMPro;

public class DistanceManager : MonoBehaviour
{
    public static DistanceManager instance;

    public TMP_Text distanceText;
    public Transform player; // Your player object
    public float distanceTraveled = 0f;
    public float scale = 1f; // Optional: tuning multiplier (e.g., 0.5 for slower count)

    private float startZ;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (player != null)
        {
            startZ = player.position.z;
        }
    }

    void Update()
    {
        if (player != null)
        {
            distanceTraveled = (player.position.z - startZ) * scale;
            distanceTraveled = Mathf.Max(0, distanceTraveled);

            // Format the number to show 5 digits with leading zeros
            distanceText.text = Mathf.FloorToInt(distanceTraveled).ToString("00000");
        }
    }
}
