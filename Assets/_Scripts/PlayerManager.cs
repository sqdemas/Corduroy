using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;

    private void Awake()
    {
        isGameOver = false;
        gameOverScreen.SetActive(false);
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
    }
    
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reloads current scene
    }
}
