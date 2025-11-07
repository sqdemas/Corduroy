using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // buttons for opening menu   
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("OpeningCutscene");
    }

    public void QuitGame()
    {
        Application.Quit();   
    }

}
 