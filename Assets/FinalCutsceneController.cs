using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FinalCutsceneController : MonoBehaviour
{
    [Header("Slides & Dialogue")]
    public Sprite[] slides;
    public string[] dialogues;
    public Image slideImage;
    public Text dialogueText;
    public Button nextButton;
    public Image fadeImage;

    [Header("Fade Settings")]
    public float fadeDuration = 2f;
    public string nextSceneName;

    private int currentSlide = 0;
    private bool isFading = false;

    void Start()
    {
        // Reset fade to transparent
        Color c = fadeImage.color;
        c.a = 0;
        fadeImage.color = c;

        // Ensure the button listener is clean
        nextButton.onClick.RemoveAllListeners();
        nextButton.onClick.AddListener(OnNextClicked);

        // Show first slide
        ShowSlide(currentSlide);
    }

    void ShowSlide(int index)
    {
        slideImage.sprite = slides[index];
        dialogueText.text = dialogues[index];
    }

    void OnNextClicked()
    {
        if (isFading) return; // Prevent clicks while fading

        if (currentSlide < slides.Length - 1)
        {
            // Move to next slide
            currentSlide++;
            ShowSlide(currentSlide);
        }
        else
        {
            // Last slide clicked: start fade coroutine
            StartCoroutine(FadeOutAndLoad());
        }
    }

    IEnumerator FadeOutAndLoad()
    {
        isFading = true;

        // Pause 10 seconds before fading
        yield return new WaitForSeconds(10f);

        float timer = 0f;
        Color c = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            c.a = Mathf.Lerp(0, 1, timer / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }

        c.a = 1;
        fadeImage.color = c;

        SceneManager.LoadScene("Main Menu");
    }
} 
