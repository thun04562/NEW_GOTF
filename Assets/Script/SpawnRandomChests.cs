using UnityEngine;

public class SpawnRandomChests : MonoBehaviour
{
    public GameObject gemChestPrefab; // Assign your GemChest prefab in the Inspector
    public int numberOfChestsToSpawn = 1; // Adjust as needed
    public float spawnY = -3.84f; // Updated Y position to -3.84
    public float minDistanceBetweenChests = 1.0f; // Minimum distance between chests
    public float minAxisX = -10.0f; // Adjust the minimum random X position
    public float maxAxisX = 10.0f; // Adjust the maximum random X position

    private bool hasSpawned = false; // Flag to ensure spawning only once

    void Start()
    {
        if (!hasSpawned) // Check if the chest hasn't spawned yet
        {
            SpawnRandomChest(); // Call the SpawnRandomChests method
            hasSpawned = true; // Set the flag to true after spawning
        }
    }

    void SpawnRandomChest()
    {
        for (int i = 0; i < numberOfChestsToSpawn; i++)
        {
            // Attempt to find a valid spawn position
            Vector3 spawnPosition = FindValidSpawnPosition();

            if (spawnPosition != Vector3.zero)
            {
                // Instantiate the GemChest prefab at the calculated position
                Instantiate(gemChestPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("Could not find a valid spawn position for GemChest.");
            }
        }
    }

    Vector3 FindValidSpawnPosition()
    {
        int maxAttempts = 10;
        int attempts = 0;

        while (attempts < maxAttempts)
        {
            // Generate a random position within the specified range
            float randomX = Random.Range(minAxisX, maxAxisX); // Adjust using the minAxisX and maxAxisX variables

            // Create a position vector with the updated Y position and random X position
            Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

            // Check if the new chest position is too close to existing chests
            if (!IsPositionTooCloseToOtherChests(spawnPosition))
            {
                return spawnPosition; // Found a valid position
            }

            attempts++;
        }

        return Vector3.zero; // Couldn't find a valid position after maxAttempts
    }

    bool IsPositionTooCloseToOtherChests(Vector3 position)
    {
        CollectGem[] existingChests = FindObjectsOfType<CollectGem>();

        foreach (CollectGem chest in existingChests)
        {
            if (Vector3.Distance(chest.transform.position, position) < minDistanceBetweenChests)
            {
                return true; // The position is too close to an existing chest
            }
        }

        return false; // The position is clear
    }
}
