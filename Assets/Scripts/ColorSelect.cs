using UnityEngine;
using UnityEngine.UI;
// Brett Reynolds, NSU

public class ColorSelect : MonoBehaviour
{
    public Dropdown ColorDropdown;
    public Text ColorText;
    public GameObject PlayerSphere;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSphere.GetComponent<Renderer>().material.color = Color.green;
    }

    public void ChooseColor() // use in the change event for the dropdown
    {
        switch (ColorDropdown.value)
        {
            case 1:
                ColorText.text = ColorDropdown.options[1].text;
                PlayerSphere.GetComponent<Renderer>().material.color = Color.magenta;
                break;
            case 2:
                ColorText.text = ColorDropdown.options[2].text;
                PlayerSphere.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case 3:
                ColorText.text = ColorDropdown.options[3].text;
                PlayerSphere.GetComponent<Renderer>().material.color = Color.blue;
                break;
            default: // color if not one of the choices is selected
                ColorText.text = ColorDropdown.options[0].text;
                PlayerSphere.GetComponent<Renderer>().material.color = Color.green;
                break;
        }
    }

}