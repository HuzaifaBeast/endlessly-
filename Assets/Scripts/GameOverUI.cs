//using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//public class GameOverUI : MonoBehaviour
//{
  //  public GameObject restartPanel;
   // public Text coinText;
    //public PlayerCoins coinManager; // assign in inspector
    //public RunnerMovement runner;   // assign in inspector

    //void Start()
    //{
      //  restartPanel.SetActive(false);
    //}

    //public void ShowGameOver()
    //{
      //  restartPanel.SetActive(true);
       // coinText.text = "Coins: " + PlayerCoins.totalCoins;

        // Enable/disable ResumeButton if not enough coins
        //Button resumeBtn = restartPanel.transform.Find("ResumeButton").GetComponent<Button>();
        //resumeBtn.interactable = PlayerCoins.totalCoins >= 200;
    //}

    //public void RestartGame()
    //{
      //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    //public void ResumeWithCoins()
    //{
      //  if (PlayerCoins.totalCoins >= 200)
       // {
         //   PlayerCoins.totalCoins -= 200;
           // PlayerPrefs.SetInt("TotalCoins", PlayerCoins.totalCoins); // save changes
            //restartPanel.SetActive(false);
            //runner.Revive(); // make sure this resets player health/position
        //}
    //}
//}
//