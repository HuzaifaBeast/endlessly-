using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    [Header("UI References")]
    public TMP_Text runCoinText;     // Coins collected this run
    public TMP_Text totalCoinText;   // Lifetime total coins

    [Header("Coin Data")]
    public int runCoins = 0;         // Reset each run
    public int totalCoins = 0;       // Persistent

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // keep alive across scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        // Load total coins from PlayerPrefs
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        UpdateUI();
    }

    // Called when player collects a coin
    public void AddCoin()
    {
        runCoins++;
        UpdateUI();
    }

    // Call this when the player dies
    public void OnPlayerDeath()
    {
        // Add run coins to lifetime total
        totalCoins += runCoins;

        // Save lifetime total
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();

        // Reset run coins
        runCoins = 0;

        UpdateUI();
    }

    void UpdateUI()
    {
        if (runCoinText != null)
            runCoinText.text = " " + runCoins;

        if (totalCoinText != null)
            totalCoinText.text = " " + totalCoins;
    }
}
