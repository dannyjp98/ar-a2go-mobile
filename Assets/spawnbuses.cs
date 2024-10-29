using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbuses : MonoBehaviour
{
    public GameObject objectToSpawn; // The GameObject to spawn
    public Transform playerTransform; // Reference to the player's transform
    public float spawnRadius = 50f; // The radius around the player to spawn objects
    public float spawnInterval = 10f; // The interval between spawns

    private float timer = 0f;

    // Start is called before the first frame update
    void Update()
    {
        // Increment timer
        timer += Time.deltaTime;

        // Check if it's time to spawn
        if (timer >= spawnInterval)
        {
            // Reset timer
            timer = 0f;

            // Spawn object
            SpawnObject();
        }
    }

    // Update is called once per frame
     void SpawnObject()
    {
        // Calculate random position around the player
        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = playerTransform.position + new Vector3(randomOffset.x, 2f, randomOffset.y);

        // Spawn the object
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
