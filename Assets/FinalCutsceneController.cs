using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

[System.Serializable]
public class FinalCutsceneLine
{
    public Sprite image;
    [TextArea(2, 5)]
    public string dialogue;
}

public class FinalCutsceneController : MonoBehaviour
{
    [Header("UI Elements")]
    public Image slideImage;
    public Text dialogueText;
    public Button nextButton;
    public FinalCutsceneLine[] lines;

    [Header("Fade Settings")]
    public Image fadeImage;
    public float fadeDuration = 2f;
    public string nextSceneName = "Main Menu";

    private int currentIndex = 0;
    private bool isFading = false;

    void Start()
    {
        // Set up button listener
        nextButton.onClick.AddListener(NextLine);

        // Initialize fade as transparent
        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }

        // Show first line
        if (lines.Length > 0)
            ShowLine(currentIndex);
    }

    void ShowLine(int index)
    {
        if (index < lines.Length)
        {
            slideImage.sprite = lines[index].image;
            dialogueText.text = lines[index].dialogue;
        }
    }

    public void NextLine()
    {
        if (isFading) return; // ignore clicks during fade

        currentIndex++; // advance to next

        if (currentIndex < lines.Length)
        {
            ShowLine(currentIndex);
        }
        else
        {
            // End of cutscene reached — start fade
            nextButton.interactable = false;
            StartCoroutine(FadeAndLoadNextScene());
        }
    }

    IEnumerator FadeAndLoadNextScene()
    {
        isFading = true;

        if (fadeImage != null)
        {
            float timer = 0f;
            Color c = fadeImage.color;

            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                c.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
                fadeImage.color = c;
                yield return null;
            }

            c.a = 1f;
            fadeImage.color = c;
        }

        SceneManager.LoadScene(nextSceneName);
    }
}
