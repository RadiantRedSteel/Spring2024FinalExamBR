using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Security.Cryptography;
// Brett Reynolds, NSU

public class TargetSpawner : MonoBehaviour
{
    public Button stopButton;
    public GameObject targetPrefab;
    public Text scoreText;
    private string targetPlayerName = PlayerData.playerName;
    private int scoreTargets = 0;
    private int totalTargets = 5;
    private string secretKey = "mySecretKey";
    private string addScoreURL = "http://localhost/reynol13/addscore.php?";

    void Start()
    {
        SpawnTargets(totalTargets);
    }

    void SpawnTargets(int numTargets)
    {
        for (int i = 0; i < numTargets; i++)
        {
            float x = UnityEngine.Random.Range(-4.0f, 4.0f);
            float y = UnityEngine.Random.Range(-4.0f, 4.0f);

            Instantiate(targetPrefab, new Vector3(x, y, 0), Quaternion.identity);
        }
    }

    void Update()
    {
        // All targets have been destroyed
        if (GameObject.FindGameObjectsWithTag("Target").Length == 0) // Assuming the targets have the tag "Target"
        {
            
            Debug.Log("Name: " + targetPlayerName + "; Score: " + scoreTargets);
            StartCoroutine(PostScores(targetPlayerName, scoreTargets));

            SceneManager.LoadScene("Exit");
        }
    }

    public void TargetDestroyed()
    {
        scoreTargets++;
        scoreText.text = scoreTargets.ToString();
        Debug.Log("Targets Destroyed: " + scoreTargets);
    }

    public void PostScoresEarly()
    {
        Debug.Log("Name: " + targetPlayerName + "; Score: " + scoreTargets);
        StartCoroutine(PostScores(targetPlayerName, scoreTargets));
    }

    IEnumerator PostScores(string name, int score)
    {
        string hash = HashInput(name + score + secretKey);
        string post_url = addScoreURL + "name=" +
               UnityWebRequest.EscapeURL(name) + "&score="
               + score + "&hash=" + hash;
        UnityWebRequest hs_post = UnityWebRequest.PostWwwForm(post_url, hash);
        yield return hs_post.SendWebRequest();
        if (hs_post.error != null)
            Debug.Log("There was an error posting the high score: "
                    + hs_post.error);
    }

    public string HashInput(string input)
    {
        SHA256Managed hm = new SHA256Managed();
        byte[] hashValue =
                hm.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input));
        string hash_convert =
                 BitConverter.ToString(hashValue).Replace("-", "").ToLower();
        return hash_convert;
    }
}
