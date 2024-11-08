using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Public variables for the UI text, finish text, player object, and the timer duration
    public TextMeshProUGUI timerText;
    public GameObject finishText;
    public GameObject player;
    public float timer = 60f;
    private bool isFinished = false;// Store the initial position of the player


    private Vector3 playerInitialPosition;
    

    private void Start()
    {
        // Hide the finish text at the start of the game
        finishText.gameObject.SetActive(false);
        // Store the player's initial position (for possible resets)
        playerInitialPosition = player.transform.position;
        
    }

    private void Update()
    {
        // If the game is not finished, continue counting down the timer
        if (!isFinished )
        {
            // Decrease the timer by the time elapsed since the last frame
            timer -= Time.deltaTime;
            // Update the UI with the current timer value (rounded to the nearest second)
            timerText.text = "Timer: " + Mathf.Ceil(timer).ToString() + "s";
            // If the timer reaches zero, call the FinishGame method
            if (timer <= 0)
            {
                FinishGame();
            }
        }
       
    }

    // Method that gets called when the game finishes (timer reaches zero)

    private void FinishGame()
    {
        // Set the timer to 0 to prevent negative values
        timer = 0;
        // Display the finish text
        finishText.gameObject.SetActive(true);
        // Set the flag to indicate the game is finished
        isFinished = true;
        // Stop the player's movement by setting the rigidbody velocity to zero
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        // Disable the player controller to stop player input and movement
        player.GetComponent<PlayerController>().enabled = false;

       

        
    }
}