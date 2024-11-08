using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterCustomization : MonoBehaviour
{
    public GameObject playerModel;
    public Slider redSlider, greenSlider, blueSlider;
    private Renderer playerRenderer;
    public Button saveButton;

    private void Start()
    {
        // Get the Renderer component of the player model

        playerRenderer = playerModel.GetComponent<Renderer>();
        // Create a new material instance to modify the player's color

        playerRenderer.material = new Material(playerRenderer.sharedMaterial);

        // Load previously saved color from PlayerPrefs
        float savedR = PlayerPrefs.GetFloat("PlayerColorR", 1f);
        float savedG = PlayerPrefs.GetFloat("PlayerColorG", 1f);
        float savedB = PlayerPrefs.GetFloat("PlayerColorB", 1f);
        Color savedColor = new Color(savedR, savedG, savedB);
        // Apply the saved color to the player model
        playerRenderer.material.color = savedColor;
        // Set the sliders to match the saved color values
        redSlider.value = savedR;
        greenSlider.value = savedG;
        blueSlider.value = savedB;
        // Add listeners to sliders to update color preview when value changes
        redSlider.onValueChanged.AddListener(delegate { UpdateColorPreview(); });
        greenSlider.onValueChanged.AddListener(delegate { UpdateColorPreview(); });
        blueSlider.onValueChanged.AddListener(delegate { UpdateColorPreview(); });

        // Add listener to save button to save the color when clicked
        saveButton.onClick.AddListener(SaveColor);
    }
    // Method to update the color preview based on the slider values
    public void UpdateColorPreview()
    {
        // Create a new color based on the slider values
        Color selectedColor = new Color(redSlider.value, greenSlider.value, blueSlider.value);
        // Apply the selected color to the player model's material
        playerRenderer.material.color = selectedColor;
    }
    // Method to save the current color to PlayerPrefs
    public void SaveColor()
    {
        // Save the current color values to PlayerPrefs
        PlayerPrefs.SetFloat("PlayerColorR", playerRenderer.material.color.r);
        PlayerPrefs.SetFloat("PlayerColorG", playerRenderer.material.color.g);
        PlayerPrefs.SetFloat("PlayerColorB", playerRenderer.material.color.b);
        // Save the PlayerPrefs to disk
        PlayerPrefs.Save();
        // Log the saved color to the console for debugging
        Debug.Log("Color Saved: " + playerRenderer.material.color);
    }
    // Method to save the color and then transition to the next scene
    public void ContinueToNextScene()
    {
        // Save the color before transitioning to the next scene
        SaveColor();
        // Load the next scene by its name (replace "NextSceneName" with the actual scene name)
        SceneManager.LoadScene("NextSceneName");
    }
}