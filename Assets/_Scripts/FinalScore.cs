using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text finalText;

    void Update()
    {
        finalText.text = scoreText.text;
    }
}
