#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instanceGameManager; // Singleton

    public int playerHealth = 100; // Score of the player
    private int score = 0; // Score of the player
    private int bestScore = 0; // Best score of the player

    private GameOverUIManager gameOverUIManager; // Game Over UI Manager
    private GameWinUIManger gameWinUIManager; // Game Over UI Manager


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

        bestScore = PlayerPrefs.GetInt("BestScore", 0);// Get the best score

    }

    void Start()
    {
        gameOverUIManager = FindObjectOfType<GameOverUIManager>(); // Get the Game Over UI Manager
        gameWinUIManager = FindObjectOfType<GameWinUIManger>(); // Get the Game Over UI Manager
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage; // Decrease the player health

        if (playerHealth <= 0) // Verify if the player health is less or equal to 0
        {
            playerDeath(); // Call the player death method
        }
    }

    private void playerDeath() {
        if (gameOverUIManager != null)
        {
            gameOverUIManager.ShowGameOver(); // Call the ShowGameOver method
        }
    }

    public void AddScore(int points)
    {
        score += points; // Increase the score

        if (score > bestScore)
        {
            bestScore = score;// Set the best score
            PlayerPrefs.SetInt("BestScore", bestScore);// Set the best score
            PlayerPrefs.Save(); // Guarda el puntaje en el almacenamiento persistente
        }

        ScoreUIManager.instance.UpdateScore(score, bestScore);

    }

    public int GetScore()
    {
        return score; // Return the score
    }

    public int GetBestScore()
    {
        return bestScore; // Return the best score
    }

    public void GameWin()
    {
        if (gameWinUIManager != null)
        {
            gameWinUIManager.ShowGameWin(); // Call the ShowGameOver method
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameLevels"); // Charge the game scene
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Quit the game in the editor
        #else
        Application.Quit(); // Quit the game in the build
        #endif
    }
}
