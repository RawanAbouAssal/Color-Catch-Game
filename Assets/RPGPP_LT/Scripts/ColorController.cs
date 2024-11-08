using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ColorController : MonoBehaviour
{
    public GameObject RedPrefab;
    public GameObject YellowPrefab;
    public GameObject GreenPrefab;
    public TextMeshProUGUI winningColorText;
    public GameObject CurrentWinningPrefab { get; private set; }
    public Material WinningMaterial { get; private set; }
    public Transform spawnPosition;
    public float changeInterval = 15f;

    void Start()
    {
        // Start the coroutine to change the winning color periodically
        StartCoroutine(ChangeWinningColor());
    }
    // Coroutine that changes the winning color at regular intervals
    IEnumerator ChangeWinningColor()
    {
        while (true)
        {
            // Destroy the current prefab if it exists
            if (CurrentWinningPrefab != null)
            {
                Destroy(CurrentWinningPrefab);
            }
            // Randomly select a color
            int colorIndex = Random.Range(0, 3);
            switch (colorIndex)
            {
                case 0:
                    // Instantiate the Red prefab at the specified spawn position
                    CurrentWinningPrefab = Instantiate(RedPrefab, spawnPosition.position, Quaternion.identity);
                    // Set the winning material to Red's material
                    WinningMaterial = RedPrefab.GetComponent<Renderer>().sharedMaterial;
                    // Update the UI text to show the target color and set the text color to red
                    winningColorText.text = "Target Color: Red";
                    winningColorText.color = Color.red;
                    break;
                case 1:
                    // Instantiate the Yellow prefab at the specified spawn position
                    CurrentWinningPrefab = Instantiate(YellowPrefab, spawnPosition.position, Quaternion.identity);
                    // Set the winning material to Yellow's material
                    WinningMaterial = YellowPrefab.GetComponent<Renderer>().sharedMaterial;
                    // Update the UI text to show the target color and set the text color to yellow
                    winningColorText.text = "Target Color: Yellow";
                    winningColorText.color = Color.yellow;
                    break;
                case 2:
                    // Instantiate the Green prefab at the specified spawn position
                    CurrentWinningPrefab = Instantiate(GreenPrefab, spawnPosition.position, Quaternion.identity);
                    // Set the winning material to Green's material
                    WinningMaterial = GreenPrefab.GetComponent<Renderer>().sharedMaterial;
                    // Update the UI text to show the target color and set the text color to green
                    winningColorText.text = "Target Color: Green";
                    winningColorText.color = Color.green;
                    break;
            }
            // Wait for the specified interval before changing the target color again
            yield return new WaitForSeconds(changeInterval);
        }
    }
}
