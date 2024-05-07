using UnityEngine;
using UnityEngine.UI;
// Brett Reynolds, NSU

public class Pause : MonoBehaviour
{
    public Text gamePausedText;
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // P key pauses AND resumes
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        gamePausedText.text = "GAME PAUSED";
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        gamePausedText.text = "";
    }
}