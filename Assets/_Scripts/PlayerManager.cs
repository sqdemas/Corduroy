using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool isLevel01Complete;
    public GameObject gameOverScreen;
    public GameObject level01CompleteScreen;

    private void Awake()
    {
        isGameOver = false;
        gameOverScreen.SetActive(false);
        isLevel01Complete = false;
        level01CompleteScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0; // freezes game
            LoopingBackground2D.time = 0; // freezes background scroll
        }

        if (isLevel01Complete)
        {
            level01CompleteScreen.SetActive(true);
            Time.timeScale = 0; // freezes game
            LoopingBackground2D.time = 0; // freezes background scroll
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reloads current scene
    }
    
    public void GoToEscalator()
    {
        SceneManager.LoadSceneAsync("Escalator");
    }
}
