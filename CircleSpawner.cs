using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public GameObject[] spritePrefabs; // Assign this in the inspector with your sprite prefab
    public int numberOfSprites = 8; // How many sprites you want to spawn
    public float moveSpeed = 0.5f;
    private Vector3 randomDirection;
    public float radius = 2f; // The radius of the circle

    public float despawnDistance = 100f; // Distance from the player at which sprites will be despawned
    [SerializeField] private int respawnThreshold = 0; // Number of sprites that must despawn before respawning
    private List<GameObject> spawnedSprites = new List<GameObject>(); // Keep track of spawned sprites
    private GameObject player; // To reference the player GameObject

    void Start()
    {
        player = FindObjectOfType<Creature>().gameObject; // Find the player GameObject

        player = FindObjectOfType<Creature>().gameObject;
    if (player != null)
    {
        //Debug.Log("Player found: " + player.name);
        SpawnSpritesInCircle();
    }
    else
    {
        //Debug.LogError("Player not found in the scene.");
    }
    }

    void Update()
{
    CheckForDespawn();
}

   void SpawnSpritesInCircle()
{
    //Debug.Log("Spawning sprites in a circle...");
    for (int i = 0; i < numberOfSprites; i++)
    {
        // Calculate angle for each sprite
        float angle = i * Mathf.PI * 2f / numberOfSprites;
        Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0) + transform.position;
        
        // Select a random prefab from the array
        GameObject spritePrefab = spritePrefabs[Random.Range(0, spritePrefabs.Length)];
        
        // Instantiate the prefab at the calculated position
        GameObject spawnedSprite = Instantiate(spritePrefab, newPos, Quaternion.identity);

        // Add the spawned sprite to the list
        spawnedSprites.Add(spawnedSprite);

        // Log to confirm the object is active in the scene
        //Debug.Log(spawnedSprite.name + " is active in hierarchy: " + spawnedSprite.activeInHierarchy);
    }
}

void CheckForDespawn()
{
    bool despawnedAny = false; // Flag to track if we despawned any sprites

    // Iterate through the list of spawned sprites
    for (int i = spawnedSprites.Count - 1; i >= 0; i--)
    {
        GameObject sprite = spawnedSprites[i];
        if (sprite != null)
        {
            float distance = Vector3.Distance(sprite.transform.position, player.transform.position);
            if (distance > despawnDistance)
            {
                //Debug.Log($"Despawning sprite {sprite.name} due to distance."); // Log when despawning a sprite
                Destroy(sprite);
                spawnedSprites.RemoveAt(i);
                despawnedAny = true; // Set the flag since we've despawned a sprite
            }
        }
    }

    // Check if we should respawn
    if (despawnedAny && spawnedSprites.Count <= respawnThreshold)
    {
        //Debug.Log("Respawn condition met. Respawning sprites...");
        SpawnSpritesInCircle();
    }
}

}
