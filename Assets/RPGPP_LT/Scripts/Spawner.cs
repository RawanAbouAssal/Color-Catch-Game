using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject myObject; // The object to spawn
    public Transform player; // Reference to the player's Transform
    public float minDistance = 10f; // Minimum distance between pickups and from the player
    public float maxDistance = 20f; // Maximum distance for spawning pickups
    public int pickupsToSpawn = 4; // Number of pickups to spawn

    void Start()
    {
        // Use the player's actual position
        Vector3 playerPosition = player.position;

        // Loop through and spawn the specified number of pickups
        for (int j = 0; j < pickupsToSpawn; j++)
        {
            Vector3 spawnPosition = Vector3.zero; // Initialize spawnPosition

            // Ensure each spawn position is far enough from the player
            bool validPosition = false;
            int attempts = 0; // Prevent infinite loop
            while (!validPosition && attempts < 100)
            {
                // Generate a random spawn position based on player position
                spawnPosition = playerPosition + new Vector3(
                    Random.Range(minDistance, maxDistance) * Random.Range(-1f, 1f), // Random x offset
                    0, // Set y to 0 
                    Random.Range(minDistance, maxDistance) * Random.Range(-1f, 1f)  // Random z offset
                );

                // Set y position to be the same as the player's y position
                spawnPosition.y = playerPosition.y;

                // Check if the generated position is sufficiently far from the player
                if (Vector3.Distance(spawnPosition, playerPosition) > minDistance)
                {
                    validPosition = true;
                }

                attempts++; // Increment attempts counter
            }

            // If a valid position was found, instantiate the object
            if (validPosition)
            {
                Instantiate(myObject, spawnPosition, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("Failed to find a valid spawn position after 100 attempts");
            }
        }
    }
}
