using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instanceGameManager; // Singleton

    public int playerHealth = 100; // Score of the player
    private int score = 0; // Score of the player

    void Awake()
    {
        if (instanceGameManager == null) // Verify if the instance is null
        {
            instanceGameManager = this; // Set the instance
        }
        else if (instanceGameManager != this) // Verify if the instance is different of this
        {
            Destroy(gameObject); // Destroy the gameObject
        }
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage; // Decrease the player health

        if (playerHealth <= 0) // Verify if the player health is less or equal to 0
        {
            Debug.Log("Game Over"); // Print Game Over
        }
    }

    private void playerDeath() {
        Debug.Log("¡El jugador ha muerto!");
    }

    public void AddScore(int points)
    {
        score += points; // Increase the score
        Debug.Log("Score: " + score); // Print the score
    }

    public int GetScore()
    {
        return score; // Return the score
    }
}
