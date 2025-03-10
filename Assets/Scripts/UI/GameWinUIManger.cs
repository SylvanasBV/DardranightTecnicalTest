using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameWinUIManger : MonoBehaviour
{
    public GameObject gameWinPanel; // Game Over Panel
    public TextMeshProUGUI GameWinText; // Score Text
    public Button mainMenuButton; // Main Menu Button
    void Start()
    {
        gameWinPanel.SetActive(false); // Set the Game Over Panel to false
        mainMenuButton.onClick.AddListener(GoToMainMenu); // Add the MainMenu method to the Main Menu Button
    }

    public void ShowGameWin()
    {
        Time.timeScale = 0; // Pausar el juego
        gameWinPanel.SetActive(true); // Set the Game Over Panel to true
        GameWinText.text = "" + GameManager.instanceGameManager.GetScore(); // Set the Game Over Text
    }

    void GoToMainMenu()
    {
        Time.timeScale = 1; // Resumir el juego
        SceneManager.LoadScene("StartMenu"); // Load the Main Menu scene
    }
}
