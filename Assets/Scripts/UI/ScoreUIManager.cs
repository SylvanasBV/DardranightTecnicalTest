
using UnityEngine;
using TMPro;

public class ScoreUIManager : MonoBehaviour
{
    public static ScoreUIManager instance; // Singleton
    public TMP_Text scoreText; // Score text
    public TMP_Text bestScoreText; // Best score text

    private void Awake()
    {
        if (instance == null) // Verify if the instance is null
        {
            instance = this; // Set the instance
        }
        else if (instance != this) // Verify if the instance is different of this
        {
            Destroy(gameObject); // Destroy the gameObject
        }
    }

    private void Start()
    {
        bestScoreText.text = "" + PlayerPrefs.GetInt("BestScore", 0); // Set the best score text
        scoreText.text = "0"; // Set the score text
    }

    public void UpdateScore(int score, int bestScore)
    {
        scoreText.text = "" + score; // Set the score text
        bestScoreText.text = "" + bestScore; // Set the best score text
    }

    public void ResetBestScore()
    {
        PlayerPrefs.SetInt("BestScore", 0); // Reset the best score
        PlayerPrefs.SetInt("CurrentScore", 0); // Reset the current score
        PlayerPrefs.Save(); // Save the best score
    }
}
