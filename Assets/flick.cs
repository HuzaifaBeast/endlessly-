using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flick : MonoBehaviour
{
    private Light flickerLight;

    public float minIntensity = 0.5f;
    public float maxIntensity = 2f;
    public float flickerSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        flickerLight = GetComponent<Light>();
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time * flickerSpeed, 0f);
        flickerLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
    }
}
