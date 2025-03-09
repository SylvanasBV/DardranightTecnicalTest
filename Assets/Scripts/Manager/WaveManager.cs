using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject[] enemy; // Enemy of the wave
        public int enemyCount; // Count of the enemy
        public float spawnRate; // Rate of the enemy
    }

    public Wave[] waves; // Waves of the game
    public Transform[] spawnPoints; // Spawn points of the enemy
    public float timeBetweenWaves = 5f; // Time between waves

    private int currentWaveIndex = 0; // Current wave
    private bool spawningWave = false; // Spawning wave


    public void Start()
    {
        StartCoroutine(StartNextWave()); // Start the coroutine
    }

    IEnumerator StartNextWave()
    {
        while (currentWaveIndex < waves.Length) // Loop through the waves
        {
            spawningWave = true; // Set the spawning wave to true
            Wave currentWave = waves[currentWaveIndex]; // Get the current wave

            for (int i = 0; i < currentWave.enemyCount; i++)
            {
                SpawnEnemy(currentWave.enemy[Random.Range(0, currentWave.enemy.Length)]); // Spawn the enemy
                yield return new WaitForSeconds(currentWave.spawnRate); // Wait for the spawn rate
            }

            spawningWave = false; // Set the spawning wave to false
            currentWaveIndex++; // Increase the current wave index}
            yield return new WaitForSeconds(timeBetweenWaves); // Wait for the time between waves
        }
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)]; // Get a random spawn point
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity,this.transform); // Instantiate the enemy
    }
}
