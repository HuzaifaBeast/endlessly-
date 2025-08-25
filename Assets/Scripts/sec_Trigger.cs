using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    [Header("Level Prefab / GameObject")]
    public GameObject levelPrefab; // drag your "level" prefab here

    [Header("Spawn Settings")]
    public Transform spawnPoint; // where to place the level when triggered
    private bool hasSpawned = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasSpawned) return; // prevent multiple spawns

        if (other.CompareTag("Player")) // make sure your player has tag "Player"
        {
            if (levelPrefab != null)
            {
                GameObject newLevel;

                if (spawnPoint != null)
                {
                    // Instantiate and snap to spawnPoint position/rotation
                    newLevel = Instantiate(levelPrefab, spawnPoint.position, spawnPoint.rotation);

                    // Fix pivot offset by parenting temporarily
                    newLevel.transform.SetParent(spawnPoint);
                    newLevel.transform.localPosition = Vector3.zero;
                    newLevel.transform.localRotation = Quaternion.identity;
                    newLevel.transform.SetParent(null); // detach again
                }
                else
                {
                    // Fallback spawn position if no spawnPoint assigned
                    newLevel = Instantiate(levelPrefab, new Vector3(-21, 4, 565), Quaternion.identity);
                }

                hasSpawned = true;
            }
        }
    }
}
