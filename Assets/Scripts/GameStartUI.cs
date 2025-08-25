using UnityEngine;

public class GameStartUI : MonoBehaviour
{
    public RunnerMovement runnerScript;
    public GameObject playButton;

    public void StartGame()
    {
        runnerScript.hasStarted = true;
        playButton.SetActive(false); // Hide button
    }
}
