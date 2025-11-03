using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

[System.Serializable]
public class CutsceneLine
{
    public Sprite image;
    [TextArea(2,5)]
    public string dialogue;
}

public class CutsceneController : MonoBehaviour
{
    public Image sceneImage;
    public TextMeshProUGUI dialogueText;
    public Button nextButton;
    public CutsceneLine[] lines;
    private int currentIndex = 0;

    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 1f;

    private bool isFading = false;

    void Start()
    {
        nextButton.onClick.AddListener(NextLine);

        if (lines.Length > 0)
            ShowLine(currentIndex);

        if (fadeCanvasGroup != null)
            fadeCanvasGroup.alpha = 0f;
    }

    void ShowLine(int index)
    {
        if (index < lines.Length)
        {
            sceneImage.sprite = lines[index].image;
            dialogueText.text = lines[index].dialogue;
        }
    }

    public void NextLine()
    {
        if (isFading) return; // ignore clicks during fade

        currentIndex++; // move to next index

        if (currentIndex < lines.Length)
        {
            ShowLine(currentIndex);
        }
        else
        {
            // End of cutscene
            nextButton.interactable = false;
            StartCoroutine(FadeAndLoadLevel01());
        }
    }

    IEnumerator FadeAndLoadLevel01()
    {
        isFading = true;

        if (fadeCanvasGroup != null)
        {
            float timer = 0f;
            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                fadeCanvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
                yield return null;
            }
        }

        SceneManager.LoadScene("Level01");
    }
}
