using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
// Brett Reynolds, NSU

public class TestScript
{
    [UnityTest]
    public IEnumerator T1_PlayButtonStartsPlay()
    {
        // Wait for the scene to load
        SceneManager.LoadScene("Intro");
        yield return new WaitForSeconds(1f);

        // Find NameInputField and add a name for Test 3
        GameObject nameInputField = GameObject.Find("NameInputField");
        Assert.IsNotNull(nameInputField, "NameInputField not found in Intro scene");
        nameInputField.GetComponent<UnityEngine.UI.InputField>().text = "TestPlayerName";
        yield return new WaitForSeconds(1f);
         
        // Find the PlayButton
        GameObject playButton = GameObject.Find("PlayButton");
        Assert.IsNotNull(playButton, "PlayButton not found in Intro scene");

        // Simulate a button click
        playButton.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Game scene
        Assert.AreEqual("Game", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking PlayButton");
        Debug.Log("Game scene loaded after clicking PlayButton in Intro scene");
        yield return new WaitForSeconds(0.1f);
    }

    [UnityTest]
    public IEnumerator T2_PlayerNameShownInGame()
    {
        // Load Game scene if not already loaded
        if (SceneManager.GetActiveScene().name != "Game")
        {
            SceneManager.LoadScene("Game");
            yield return new WaitForSeconds(1f);
        }

        // Find NameText
        GameObject nameText = GameObject.Find("NameText");
        Assert.IsNotNull(nameText, "NameText not found in Game scene");
        Debug.Log("Player Name properly shows");
        yield return new WaitForSeconds(0.1f);
    }

    [UnityTest]
    public IEnumerator T3_NameFromIntroShowsInGameScene()
    {
        yield return new WaitForSeconds(1f);

        // Find NameText
        GameObject nameText = GameObject.Find("NameText");
        Assert.IsNotNull(nameText, "NameText not found in Game scene");
        yield return new WaitForSeconds(0.1f);

        // Compare nameText with expected name from Test 1
        Assert.AreEqual("TestPlayerName", nameText.GetComponent<UnityEngine.UI.Text>().text, "NameText does not display the correct player name from Intro scene");
        Debug.Log("NameText shows correct player name of TestPlayerName from Intro scene");
        yield return new WaitForSeconds(0.1f);
    }



    [UnityTest]
    public IEnumerator T4_StopButtonStopsPlay()
    {
        // Load Game scene if not already loaded
        if (SceneManager.GetActiveScene().name != "Game")
        {
            SceneManager.LoadScene("Game");
            yield return new WaitForSeconds(1f);
        }

        // Find the StopButton
        GameObject stopButton = GameObject.Find("StopButton");
        Assert.IsNotNull(stopButton, "StopButton not found in Game scene");

        // Simulate a button click
        stopButton.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Exit scene
        Assert.AreEqual("Exit", SceneManager.GetActiveScene().name, "Exit scene not loaded after clicking StopButton in Game scene");
        Debug.Log("Exit scene loaded after clicking StopButton in Game scene");
        yield return new WaitForSeconds(0.1f);

    }

    [UnityTest]
    public IEnumerator T5_PlayAgainButtonRestartsGame()
    {
        // Load Exit scene if not already loaded
        if (SceneManager.GetActiveScene().name != "Exit")
        {
            SceneManager.LoadScene("Exit");
            yield return new WaitForSeconds(1f);
        }

        // Find the PlayAgainButton
        GameObject playAgainButton = GameObject.Find("PlayAgainButton");
        Assert.IsNotNull(playAgainButton, "StopButton not found in Game scene");

        // Simulate a button click
        playAgainButton.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Intro scene
        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name, "Intro scene not loaded after clicking PlayAgainButton in Exit scene");
        Debug.Log("Intro scene loaded after clicking PlayAgainButton in Exit scene");
        yield return new WaitForSeconds(0.1f);
    }

    [UnityTest]
    public IEnumerator T6_DestroyingFiveTargetsStopsPlay()
    {
        // Load Intro scene if not already loaded
        if (SceneManager.GetActiveScene().name != "Intro")
        {
            SceneManager.LoadScene("Intro");
            yield return new WaitForSeconds(1f);
        }

        // Find NameInputField
        GameObject nameInputField = GameObject.Find("NameInputField");
        Assert.IsNotNull(nameInputField, "NameInputField not found in Intro scene");
        nameInputField.GetComponent<UnityEngine.UI.InputField>().text = "TestPlayerName";
        yield return new WaitForSeconds(1f);

        // Find the PlayButton
        GameObject playButton = GameObject.Find("PlayButton");
        Assert.IsNotNull(playButton, "PlayButton not found in Intro scene");

        // Simulate a button click
        playButton.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Game scene
        Assert.AreEqual("Game", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking PlayButton");
        Debug.Log("Game scene loaded after clicking PlayButton in Intro scene");
        yield return new WaitForSeconds(0.1f);

        // Find the Player
        GameObject player = GameObject.Find("Player");
        Assert.IsNotNull(player, "Player not found in Game scene");

        // Destroy five targets
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject target in targets)
        {
            if (target != null)
            {
                player.transform.position = target.transform.position;
                yield return new WaitForSeconds(1); // Wait for 1 second before teleporting to the next target
            }
        }
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Exit scene
        Assert.AreEqual("Exit", SceneManager.GetActiveScene().name, "Exit scene not loaded after destroying five targets in Game scene");
        Debug.Log("Exit scene loaded after loaded after destroying five targets in Game scene");
        yield return new WaitForSeconds(0.1f);
    }
}
