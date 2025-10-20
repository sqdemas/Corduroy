using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
public class LevelCountdown : MonoBehaviour
{
    [SerializeField] TMP_Text countdownText;
    [SerializeField] float remainingTime;

    void Update()
    {
        if (CorduroyController.canMove) // countdown will begin after intial 3, 2, 1 countdown
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime; // update regularly
            }
            else if (remainingTime <= 0)
            {
                remainingTime = 0; // prevents negative values
                PlayerManager.isLevel01Complete = true;
                AudioManager.instance.Play("LevelComplete"); // plays positive sound effect
                CorduroyController.canMove = false; // players cannot move corduroy when level finishes, prevents sound effect from looping
            }
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
