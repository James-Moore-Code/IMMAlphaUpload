using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Variables
    private float speed = 12.0f;
    private int lives;
    private int score;
    private bool itemHeld = false;
    public int howManyHeld;
    private Rigidbody playerRb;
    public Animator playerAnim;

    private AudioSource playerAudio;
    public AudioClip clownSound;
    public AudioClip teaSound;
    public AudioClip hatterSound;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();

        lives = 3;
        score = 0;
        howManyHeld = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        
    }

    void MovePlayer()
    {
        //Get the horizontal and vertical input from arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

        //fix look rotation viewing vector is zero with if statement
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

        //Move the player
        playerRb.AddForce(Vector3.right * speed * horizontalInput);

        playerRb.AddForce(Vector3.forward * speed * verticalInput);

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            playerAnim.SetBool("IsRunning", true);
        }
        else
            playerAnim.SetBool("IsRunning", false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lives -= 1;
            Debug.Log("Life: " + lives);
            itemHeld = false;
            playerAudio.PlayOneShot(clownSound, 1.0f);
            howManyHeld = 0;

            if (lives <= 0)
            {
                Debug.Log("Life: " + lives + ". Score: " + score + ". GameOver!!!");
                GameOver();

            }
        }

        if (collision.gameObject.CompareTag("DropZone") && itemHeld == true)
        {
            itemHeld = false;
            score += howManyHeld;
            Debug.Log("Score: " + score);
            playerAudio.PlayOneShot(hatterSound, 1.0f);
            howManyHeld = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);
            itemHeld = true;
            howManyHeld += 1;
            Debug.Log("Bring the food to youre family!!!");
            playerAudio.PlayOneShot(teaSound, 1.0f);
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("Menu");
    }

    
}