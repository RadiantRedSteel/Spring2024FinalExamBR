using UnityEngine;
using UnityEngine.UI;
// Brett Reynolds, NSU

public class DisplayName : MonoBehaviour
{
    public Text playerNameText;
    private string displayName = PlayerData.playerName;

    // Start is called before the first frame update
    void Start()
    {
        DisplayMyPlayerName(displayName);
    }

    public void DisplayMyPlayerName(string playerName)
    {
        if (playerName != null)
        {
            playerNameText.text = playerName;
        }
    }
}
