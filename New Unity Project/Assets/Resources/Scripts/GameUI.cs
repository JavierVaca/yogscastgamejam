
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    Text statBox;

    Santa santa;

    public GameObject gameOverPanel;

    // Game switch
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);

        statBox = GetComponentInChildren<Text>();
        santa = GameObject.FindGameObjectWithTag("Player").GetComponent<Santa>();  
    }

    // Update is called once per frame
    void Update()
    {
        DisplaySantaStats();
        GameOver();
    }

    void DisplaySantaStats()
    {
        statBox.text = string.Format("Lives: {0}\nScore: {1}", santa.lives, santa.score);
    }

    public void RestartGame()
    {
        gameOverPanel.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    void GameOver()
    {
        if (isGameOver)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
