using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // controls main game state, panels, buttons
    public static bool isGameOver;
    public static bool isLevel01Complete;
    public static bool isScreenFrozen;
    public GameObject mainPanel;
    public GameObject gameOverScreen;
    public GameObject level01CompleteScreen;
    public GameObject pauseMenu;

    private void Awake()
    {
        // default configuration
        mainPanel.SetActive(true);

        isGameOver = false;
        gameOverScreen.SetActive(false);

        pauseMenu.SetActive(false);
        isLevel01Complete = false;

        level01CompleteScreen.SetActive(false);
        isScreenFrozen = true;

        Time.timeScale = 1.0f;
        StartCoroutine(BeginningFreeze());
        
    }

    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
            FreezeScreen();
            Time.timeScale = 0; // freeze objects from spawning game

        }

        if (isLevel01Complete)
        {
            level01CompleteScreen.SetActive(true);
            mainPanel.SetActive(false); // hides main interface
            FreezeScreen();
            Time.timeScale = 0; // freeze objects from spawning game
        }
    }

    public static void FreezeScreen()
    {
        // freezes background, corduroy, and level countdown
        isScreenFrozen = true;
        LoopingBackground2D.timeScale = 0f;
    }
    public static void UnfreezeScreen()
    {
        isScreenFrozen = false;
        LoopingBackground2D.timeScale = 1f;
    }
    IEnumerator BeginningFreeze()
    {
        // freezes screen for beginning 321 countdown
        FreezeScreen();
        yield return new WaitForSeconds(3f);
        UnfreezeScreen();
        // begin walking animation after three seconds
        GameObject player = GameObject.Find("CorduroyAnimation");
        player.GetComponent<CorduroyController>().StartWalking();
    }
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reloads current scene
    }

    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0; // freeze objects from spawning game
        FreezeScreen(); // freezes background, corduroy, and level countdown
    }
    public void LevelCompleteButton()
    {
        SceneManager.LoadSceneAsync("Level02");
    }
    
    public void PlayButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f; // unfreeze game
        UnfreezeScreen();
    }
}
