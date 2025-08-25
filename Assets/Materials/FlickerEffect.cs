using UnityEngine;

public class FlickerEffect : MonoBehaviour
{
    public Renderer objRenderer;
    public float minInterval = 0.05f;
    public float maxInterval = 0.3f;

    void Start()
    {
        if (objRenderer == null)
            objRenderer = GetComponent<Renderer>();

        StartCoroutine(Flicker());
    }

    System.Collections.IEnumerator Flicker()
    {
        while (true)
        {
            objRenderer.enabled = !objRenderer.enabled;
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
        }
    }
}
