using UnityEngine;
using System.Collections;

public class CoinLineSpawner : MonoBehaviour
{
    public GameObject coinLinePrefab;
    public int numberOfLines = 20;
    public float zMin = -43.3f;
    public float zMax = 544.6f;
    public float ySpawnHeight = 1f; // ⬅️ Y-axis height for coins
    public float spawnInterval = 0.05f;

    // Customize lanes (X-axis positions)
    private float[] lanePositionsX = new float[] { -4.2f, 0f, 4.2f };

    void Start()
    {
        StartCoroutine(SpawnCoinLines());
    }

    IEnumerator SpawnCoinLines()
    {
        for (int i = 0; i < numberOfLines; i++)
        {
            float randomX = lanePositionsX[Random.Range(0, lanePositionsX.Length)];
            float randomZ = Random.Range(zMin, zMax);
            Vector3 spawnPos = new Vector3(randomX, ySpawnHeight, randomZ);

            Instantiate(coinLinePrefab, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
