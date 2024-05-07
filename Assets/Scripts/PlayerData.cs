using UnityEngine;
using UnityEngine.UI;
// Brett Reynolds, NSU

public class PlayerData : MonoBehaviour
{
    public InputField nameInput;
    public static string playerName;

    // to execute any time inputfield changes
    public void MyPlayerName()
    {
        playerName = nameInput.text;
        Debug.Log(playerName);
    }
}
