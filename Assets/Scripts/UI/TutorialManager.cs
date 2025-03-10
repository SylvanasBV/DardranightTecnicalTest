using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel; // Tutorial window

    void Start()
    {
        tutorialPanel.SetActive(true); // Active the tutorial
        Time.timeScale = 0; // pause the game
    }

    void Update()
    {
        // Type any key to close the tutorial
        if (tutorialPanel.activeSelf && Input.anyKeyDown)
        {
            CloseTutorial();
        }
    }

    public void CloseTutorial()
    {
        tutorialPanel.SetActive(false); // Hiden the tutorial
        Time.timeScale = 1; // Reactivate the game
    }
}
