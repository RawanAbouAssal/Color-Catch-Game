using UnityEngine;

public class PlayerColorManager : MonoBehaviour
{
    // Private variable to store the player's Renderer component
    private Renderer playerRenderer;

    private void Start()
    {
        // Get the Renderer component attached to the player object
        playerRenderer = GetComponent<Renderer>();
        // Create a new material instance to modify the player's color without affecting shared materials
        playerRenderer.material = new Material(playerRenderer.sharedMaterial);
        // Load previously saved color values from PlayerPrefs
        float savedR = PlayerPrefs.GetFloat("PlayerColorR", 1f);
        float savedG = PlayerPrefs.GetFloat("PlayerColorG", 1f);
        float savedB = PlayerPrefs.GetFloat("PlayerColorB", 1f);
        // Create a new Color object using the loaded RGB values
        Color savedColor = new Color(savedR, savedG, savedB);
        // Apply the saved color to the player model's material
        playerRenderer.material.color = savedColor;
        // Log the loaded color to the console for debugging purposes
        Debug.Log("Loaded color: " + savedColor);
    }
}