using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverUIManager : MonoBehaviour
{
    public GameObject gameOverPanel; // Game Over Panel
    public TextMeshProUGUI GameOverText; // Score Text
    public Button restartButton; // Restart Button
    public Button mainMenuButton; // Main Menu Button
    void Start()
    {
        gameOverPanel.SetActive(false); // Set the Game Over Panel to false
        restartButton.onClick.AddListener(RestartGame); // Add the RestartGame method to the Restart Button
        mainMenuButton.onClick.AddListener(GoToMainMenu); // Add the MainMenu method to the Main Menu Button
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0; // Pausar el juego
        gameOverPanel.SetActive(true); // Set the Game Over Panel to true
        GameOverText.text = "" + GameManager.instanceGameManager.GetScore(); // Set the Game Over Text
    }

    void RestartGame()
    {
        Time.timeScale = 1; // Resumir el juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Load the current scene
    }

    void GoToMainMenu()
    {
        Time.timeScale = 1; // Resumir el juego
        SceneManager.LoadScene("StartMenu"); // Load the Main Menu scene
    }

}
