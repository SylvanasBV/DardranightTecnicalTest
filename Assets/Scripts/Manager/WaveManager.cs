using System.Collections;
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
    public float timeBetweenWaves = 2f; // Time between waves

    private int currentWaveIndex = 0; // Current wave
    private int enemiesAlive = 0; // Enemy alive     

    public void Start()
    {
        StartCoroutine(StartNextWave()); // Start the coroutine
    }

    IEnumerator StartNextWave()
    {
        while (currentWaveIndex < waves.Length) // Loop through the waves
        {
            Debug.Log("Wave " + (currentWaveIndex + 1)); // Print the wave
            Wave currentWave = waves[currentWaveIndex]; // Get the current wave
            enemiesAlive = currentWave.enemyCount; // Registrar la cantidad de enemigos de esta oleada

            for (int i = 0; i < currentWave.enemyCount; i++)
            {
                SpawnEnemy(currentWave.enemy[Random.Range(0, currentWave.enemy.Length)]); // Spawn the enemy
                yield return new WaitForSeconds(currentWave.spawnRate); // Wait for the spawn rate
            }

            yield return new WaitUntil(() => enemiesAlive <= 0);// Wait until all enemies are dead

            currentWaveIndex++; // Increase the current wave index}
            yield return new WaitForSeconds(timeBetweenWaves); // Wait for the time between waves
        }

        GameManager.instanceGameManager.GameWin(); // Call the Game Win method

    }


    void SpawnEnemy(GameObject enemyPrefab)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)]; // Get a random spawn point
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity); // Instantiate the enemy
        newEnemy.GetComponent<Enemy>().OnEnemyDeath += EnemyDefeated;// Subscribe to the enemy death event
    }

    void EnemyDefeated()
    {
        enemiesAlive--; // Decrease the enemies alive
    }
}
