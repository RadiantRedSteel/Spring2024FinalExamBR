using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
// Brett Reynolds, NSU

public class DisplayScores : MonoBehaviour
{
    private string highscoreURL = "http://localhost/reynol13/display.php";
    public Text highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = "";
        StartCoroutine(GetScores());
    }

    IEnumerator GetScores()
    {
        UnityWebRequest hs_get = UnityWebRequest.Get(highscoreURL);
        yield return hs_get.SendWebRequest();
        if (hs_get.error != null)
            Debug.Log("There was an error getting the high score: "
                    + hs_get.error);
        else
        {
            string dataText = hs_get.downloadHandler.text;
            MatchCollection mc = Regex.Matches(dataText, @"_");
            if (mc.Count > 0)
            {
                string[] splitData = Regex.Split(dataText, @"_");
                for (int i = 0; i < mc.Count; i++)
                {
                    if (i % 2 == 0)
                        highscoreText.text += splitData[i];
                    else
                        highscoreText.text += splitData[i];
                }
            }
        }
    }
}
