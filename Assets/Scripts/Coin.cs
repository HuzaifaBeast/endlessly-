using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject shineEffectPrefab;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show shine effect
            if (shineEffectPrefab != null)
            {
                GameObject shine = Instantiate(shineEffectPrefab, transform.position, Quaternion.identity);
                Destroy(shine, 1f); // Destroy the shine effect after 1 second
            }

            // Add coin
            CoinManager.instance.AddCoin();

            // Destroy the coin itself
            Destroy(gameObject);
        }
    }
}
