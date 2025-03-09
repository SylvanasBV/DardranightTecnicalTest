using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpawner : MonoBehaviour
{
    [Header ("Configuration of the spawn")]
    public GameObject startPrefab; // Prefab of the stars
    [SerializeReference]private int poolsize = 10; // Number of stars
    [SerializeReference] private float unSpawnRate = 0.7f; // Every second spawn a star
    [SerializeReference] private Vector2 spawnRangeX = new Vector2(-9.90f, 9.90f); // Limit to spawn X 
    [SerializeReference] private Vector2 spawnRangeY = new Vector2(-4.40f, 6.50f); // Limit to spawn Y

    private Queue<GameObject> starPool;// Pool of stars
    // Start is called before the first frame update
    void Awake()
    {
        // Create the pool of stars
        starPool = new Queue<GameObject>();

        for (int i = 0; i < poolsize; i++)
        {
            GameObject start = Instantiate(startPrefab, this.transform); // Create the star into the main game object
            start.SetActive(false);// Deactivate the star
            starPool.Enqueue(start);// Add the star to the pool
        }
        StartCoroutine(SpawnStart());// Start the coroutine to spawn the stars
    }

    // class of corrutine to take the time to spawn the stars
    IEnumerator SpawnStart()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f); // Wait for the spawnRate
            spawnStar();// Spawn the method
        }
    }

    void spawnStar()
    {
        //Verify if there is a star in the pool
        if (starPool.Count >= 0)
        {
            // Get the star from the pool
            GameObject star = starPool.Dequeue();
            star.transform.position = new Vector2(Random.Range(spawnRangeX.x, spawnRangeX.y), Random.Range(spawnRangeY.x, spawnRangeY.y));// Set the position of the star
            star.SetActive(true);// Activate the star
            StartCoroutine(DeactivateStar(star));// Start the coroutine to deactivate the star
        }
    }

    IEnumerator DeactivateStar(GameObject star)
    {
        float duration = unSpawnRate;//live time of the star
        yield return new WaitForSeconds(unSpawnRate); // Wait for the spawnRate
        star.SetActive(false);// Deactivate the star
        starPool.Enqueue(star); // Return the star to the pool
    }


}
