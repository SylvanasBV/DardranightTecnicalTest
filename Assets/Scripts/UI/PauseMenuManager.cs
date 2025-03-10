using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel; // Panel de pausa
    [SerializeField] private GameObject gameOverPanel; // Panel de Game Over
    [SerializeField] private GameObject gameWinPanel; // Panel de Game Win
    [SerializeField] private GameObject tutorialPanel; // Panel del tutorial

    private bool isPaused = false; // Estado del juego

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Detecta la tecla Escape
        {
            // Verifica que NO estén activos GameOver, GameWin o el tutorial
            if (!IsBlockedByOtherPanels())
            {
                if (isPaused)
                    ResumeGame();
                else
                    PauseGame();
            }
        }
    }

    private bool IsBlockedByOtherPanels()
    {
        return (gameOverPanel != null && gameOverPanel.activeSelf) ||
                (gameWinPanel != null && gameWinPanel.activeSelf) ||
                (tutorialPanel != null && tutorialPanel.activeSelf);
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true); // Mostrar el panel
        Time.timeScale = 0; // Pausar el tiempo del juego
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false); // Ocultar el panel
        Time.timeScale = 1; // Reanudar el tiempo
        isPaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Reanudar tiempo antes de reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recargar nivel
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1; // Reanudar tiempo antes de salir
        SceneManager.LoadScene("StartMenu"); // Cargar el menú principal
    }
    
}
