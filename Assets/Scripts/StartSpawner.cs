using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpawner : MonoBehaviour
{
    [Header ("Configuration of the spawn")]
    public GameObject startPrefab; // Prefab of the stars
    public int poolsize = 10; // Number of stars
    public float unSpawnRate = 0.9f; // Every second spawn a star
    public Vector2 spawnRangeX = new Vector2(-4.2f, 6.2f); // Limit to spawn X 
    public Vector2 spawnRangeY = new Vector2(-7.50f, 7.50f); // Limit to spawn Y

    private Queue<GameObject> starPool;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        // Create the pool of stars
        starPool = new Queue<GameObject>();

        for (int i = 0; i < poolsize; i++)
        {
            GameObject start = Instantiate(startPrefab);
            start.SetActive(false);
            starPool.Enqueue(start);
        }
        StartCoroutine(SpawnStart());
    }

    // class of corrutine to take the time to spawn the stars
    IEnumerator SpawnStart()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f); // Wait for the spawnRate
            spawnStar();
        }
    }

    void spawnStar()
    {
        //Verify if there is a star in the pool
        if (starPool.Count >= 0)
        {
            // Get the star from the pool
            GameObject start = starPool.Dequeue();
            start.transform.position = new Vector2(Random.Range(spawnRangeX.x, spawnRangeX.y), Random.Range(spawnRangeY.x, spawnRangeY.y));
            start.SetActive(true);
            StartCoroutine(DeactivateStar(start));
        }
    }

    IEnumerator DeactivateStar(GameObject star)
    {
        yield return new WaitForSeconds(unSpawnRate); // Wait for the spawnRate
        star.SetActive(false);// Deactivate the star
        starPool.Enqueue(star); // Return the star to the pool
    }


}
