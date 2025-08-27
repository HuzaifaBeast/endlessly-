using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance;
    public GameObject prefab;
    public int numberOfPlatforms = 5;
    public List<GameObject> platforms;
    public Transform startTransform;
    public float lastZ;
    private void Awake()
    {
        Instance = this; 
    }
    void Start()
    {
        lastZ = startTransform.position.z;
        platforms = new List<GameObject>();
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            GenerateAgain();
        }
    }
    public void GenerateAgain()
    {
        Vector3 position = new Vector3(startTransform.position.x, startTransform.position.y, lastZ); // Adjust spacing as needed
        lastZ += startTransform.position.z;
        if (platforms.Count < numberOfPlatforms)
        {
            GameObject platform = Instantiate(prefab, position, Quaternion.identity);
            platform.SetActive(true);
            platforms.Add(platform);
        }
        else
        {
            GameObject platform = platforms[0];
            platforms.RemoveAt(0);
            platform.transform.position = position;
            platform.SetActive(true);
            platforms.Add(platform);
        }
    }
}
