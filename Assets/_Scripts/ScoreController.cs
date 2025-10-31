using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public int score = 100;
    public TMP_Text scoreText;
    void Start()
    {
        // increases score every 10 seconds
        // player is rewarded just for surviving more time
        InvokeRepeating("IncreaseScore", 8, 5f); // waits opening freeze, then increases every 5 seconds
    }

    void IncreaseScore()
    {
        score = int.Parse(scoreText.text);
        score = score + 10;
        scoreText.text = score.ToString();
    }

    public void DecreaseScore()
    {
        score = int.Parse(scoreText.text);
        score = score - 30;
        scoreText.text = score.ToString();
    }
    
    public void Powerup()
    {
        score = int.Parse(scoreText.text);
        score = score + 30;
        scoreText.text = score.ToString();
    }
}
