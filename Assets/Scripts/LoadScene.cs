using UnityEngine;
using UnityEngine.SceneManagement;
// Brett Reynolds, NSU

public class LoadScene : MonoBehaviour
{
    private readonly string introScene = "Intro";
    private readonly string gameScene = "Game";
    private readonly string exitScene = "Exit";

    public void LoadIntroScene()
    {
        SceneManager.LoadScene(introScene);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void LoadExitScene()
    {
        SceneManager.LoadScene(exitScene);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}