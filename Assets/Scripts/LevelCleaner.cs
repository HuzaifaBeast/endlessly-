using UnityEngine;
using System.Collections;

public class DestroySpawner : MonoBehaviour
{
    public GameObject destroyPrefab;   // Your "Destroy" collider prefab
    public Transform spawnPoint;       // Where to place it
    public float spawnInterval = 120f; // 2 minutes (120s)

    private GameObject currentDestroy; // Track the last spawned destroy object

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Remove the old one before spawning new
            if (currentDestroy != null)
            {
                Destroy(currentDestroy);
            }

            // Spawn a new Destroy collider
            currentDestroy = Instantiate(destroyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
