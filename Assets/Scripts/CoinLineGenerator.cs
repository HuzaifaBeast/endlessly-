using UnityEngine;

public class CoinLineGenerator : MonoBehaviour
{
    public GameObject coinPrefab;
    public int coinCount = 10;
    public float spacing = 1f;

    void Start()
    {
        for (int i = 0; i < coinCount; i++)
        {
            Vector3 pos = transform.position + Vector3.forward * i * spacing;
            Instantiate(coinPrefab, pos, Quaternion.identity, transform);
        }
    }
}
