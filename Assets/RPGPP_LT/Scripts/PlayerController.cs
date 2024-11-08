using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public ColorController colorController;
    public AudioSource winSound;
    public AudioSource loseSound;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 10;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI FinalScore;
    private float timer = 60f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();// Get the Rigidbody component for physics-based movement
        count = 0; // Initialize score counter
        SetCountText();// Update the count display
        SetTimerText();// Update the timer display
        winTextObject.SetActive(false);// Hide the win/lose text initially
    }

    void Update()
    {
        // Get the horizontal and vertical input axes for movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // Create a movement vector and apply movement to the player
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);
        // Update the timer if the game is still ongoing
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            SetTimerText();
            // If the timer runs out, end the game
            if (timer <= 0)
            {
                EndGame(false); //Game Over
            }
        }
    }

 
    // FixedUpdate is called at fixed intervals and is used for physics-related movement
    private void FixedUpdate()
    {
        // Apply force based on the movement input received in OnMove
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);// Move the player using Rigidbody physics
    }

    // OnTriggerEnter is called when the player collides with another collider
    void OnTriggerEnter(Collider other)
    {
        Renderer otherRenderer = other.GetComponent<Renderer>();
        // Check if the object has a Renderer and matches the winning color
        if (otherRenderer != null && otherRenderer.sharedMaterial == colorController.WinningMaterial)
        {
            // If the color matches, increase the score, play the win sound, and deactivate the object
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
            winSound.Play();
        }
        else
        {
            // If the color doesn't match, decrease the score and play the lose sound
            loseSound.Play();
            count -= 1;
            SetCountText();

        }
        // Destroy the collected object after the collision
        Destroy(other.gameObject);
    }
    // Update the score UI text
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();// Update count display
        FinalScore.text = "FinalScore: " + count.ToString();// Update final score display
    }
    // Update the timer UI text
    void SetTimerText()
    {
        timerText.text = "Time: " + Mathf.Ceil(timer).ToString();// Display remaining time (rounded)
    }
    // End the game, either with a win or loss, and show the appropriate message
    void EndGame(bool won)
    {
        // If the game was won, display "You Win!", else display "Game Over!"
        if (won)
        {
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!";
            winSound.Play();
        }
        else
        {
            winTextObject.GetComponent<TextMeshProUGUI>().text = "Game Over!";
            loseSound.Play();
        }
        // Display the win/lose message and stop further gameplay
        winTextObject.SetActive(true);
        enabled = false;// Disable this script to stop the game
    }
}
