using UnityEngine;
using UnityEngine.SceneManagement; // needed for reloading scenes
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject hudPanel;
    public GameObject menuPanel;
    public GameObject shopPanel;
    public GameObject restartPanel;

    public Text coinText;
    public Text scoreText;
    public Text highScoreText;

    private int webCoins = 0;
    private int score = 0;
    private int highScore = 0;

    void Start()
    {
        hudPanel.SetActive(false);
        shopPanel.SetActive(false);
        menuPanel.SetActive(true);
        restartPanel.SetActive(false);

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUI();
    }

    public void OnPlayClicked()
    {
        hudPanel.SetActive(true);
        menuPanel.SetActive(false);
        shopPanel.SetActive(false);
        restartPanel.SetActive(false);
    }

    public void OnShopClicked()
    {
        shopPanel.SetActive(true);
    }

    public void OnCloseShop()
    {
        shopPanel.SetActive(false);
    }

    // 🚨 Call this when player dies
    public void OnPlayerDied()
    {
        hudPanel.SetActive(false);      // Hide HUD
        restartPanel.SetActive(true);   // Show Restart Panel
    }

    // Restart game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Back to menu
    public void GoToMenu()
    {
        restartPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    void UpdateUI()
    {
        coinText.text = webCoins.ToString();
        scoreText.text = score.ToString("00000");
        highScoreText.text = "High Score: " + highScore;
    }
}
