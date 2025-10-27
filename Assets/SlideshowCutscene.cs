using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlideshowCutscene : MonoBehaviour
{
    [System.Serializable]
    public class Slide
    {
        public Sprite image;
        [TextArea(2, 5)] public string dialogue;
    }

    public Image slideImage;
    public TMP_Text dialogueText;
    public Slide[] slides;

    private int currentSlide = 0;

    void Start()
    {
        ShowSlide();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left click to advance
        {
            NextSlide();
        }
    }

    void ShowSlide()
    {
        if (currentSlide < slides.Length)
        {
            slideImage.sprite = slides[currentSlide].image;
            dialogueText.text = slides[currentSlide].dialogue;
        }
        else
        {
            EndCutscene();
        }
    }

    void NextSlide()
    {
        currentSlide++;
        ShowSlide();
    }

    void EndCutscene()
    {
        Debug.Log("Cutscene ended!");
        // if there's extra time: load next scene or trigger gameplay
        // SceneManager.LoadScene("NextScene");
    }
}
