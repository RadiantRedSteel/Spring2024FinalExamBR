using UnityEngine;
using UnityEngine.UI;
// Brett Reynolds, NSU

public class SizeSliderValue : MonoBehaviour
{
    public Slider mySlider;
    public Text sizeText;
    public static float size;

    // Update is called once per frame
    void Update()
    {
        size = mySlider.value;
        if (sizeText != null )
        {
            sizeText.text = size.ToString("f2"); // float with two decimals
        }
    } 
}