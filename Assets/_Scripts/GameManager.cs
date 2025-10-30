using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool isLevel01Complete;
    public static bool isScreenFrozen;
    public GameObject gameOverScreen;
    public GameObject level01CompleteScreen;
    public GameObject midGameMenu;

    private void Awake()
    {
        // AudioManager.instance.Play("BackgroundMusic");

        isGameOver = false;
        gameOverScreen.SetActive(false);

        midGameMenu.SetActive(false);
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

    public void MenuButton()
    {
        midGameMenu.SetActive(true);
        Time.timeScale = 0; // freeze objects from spawning game
        FreezeScreen(); // freezes background, corduroy, and level countdown
    }
    public void GoToEscalator()
    {
        SceneManager.LoadSceneAsync("Escalator");
    }
    
    public void PlayButton()
    {
        midGameMenu.SetActive(false);
        Time.timeScale = 1.0f; // unfreeze game
        UnfreezeScreen();
    }
}
