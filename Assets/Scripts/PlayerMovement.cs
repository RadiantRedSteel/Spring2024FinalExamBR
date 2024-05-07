using UnityEngine;
using UnityEngine.SceneManagement;
// Brett Reynolds, NSU

public class PlayerMovement : MonoBehaviour
{
    public float movement = 4.0f;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial size of the player
        transform.localScale = new Vector3(SizeSliderValue.size, SizeSliderValue.size, SizeSliderValue.size);
    }

    // Update is called once per frame
    void Update() 
    {
        // Update the size of the player
        transform.localScale = new Vector3(SizeSliderValue.size, SizeSliderValue.size, SizeSliderValue.size);

        // the actual movements are in separate functions so you can call those functions in edit mode and the update function in playmode
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }
        else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MoveBack();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
    }

    private void MoveLeft() 
    {
        this.transform.Translate(speed * movement * Time.deltaTime * Vector3.left);
    }

    public void MoveRight() 
    {
        this.transform.Translate(speed * movement * Time.deltaTime * Vector3.right);
    }

    private void MoveForward()
    {
        this.transform.Translate(speed * movement * Time.deltaTime * Vector3.forward);
    }

    private void MoveBack()
    {
        this.transform.Translate(speed * movement * Time.deltaTime * Vector3.back);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Destroy(collision.gameObject);
            FindObjectOfType<TargetSpawner>().TargetDestroyed();
        }
    }
}
