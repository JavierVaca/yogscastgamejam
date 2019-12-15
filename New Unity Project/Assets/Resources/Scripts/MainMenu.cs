
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject TutorialPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowTutorial()
    {
        MainMenuPanel.SetActive(false);
        TutorialPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        MainMenuPanel.SetActive(true);
        TutorialPanel.SetActive(false);
    }
}
