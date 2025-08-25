using UnityEngine;

public class BusSpawner : MonoBehaviour
{
    public GameObject busPrefab;
    public ParticleSystem spawnEffect;
    public Transform spawnPoint;
    public float busSpeed = 10f;
    public float loopDistance = 50f;

    private GameObject currentBus;
    private Vector3 startPos;

    void Start()
    {
        SpawnBus();
    }

    void SpawnBus()
    {
        // Play particle
        spawnEffect.Play();

        // Spawn bus facing the spawner's forward direction
        currentBus = Instantiate(busPrefab, spawnPoint.position, spawnPoint.rotation);
        startPos = spawnPoint.position;
    }

    void Update()
    {
        if (currentBus != null)
        {
            // Move the bus forward relative to its rotation
            currentBus.transform.Translate(Vector3.forward * busSpeed * Time.deltaTime);

            // Loop when distance reached
            if (Vector3.Distance(startPos, currentBus.transform.position) > loopDistance)
            {
                Destroy(currentBus);
                SpawnBus();
            }
        }
    }
}
