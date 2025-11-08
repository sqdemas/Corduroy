using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PullButtonController : MonoBehaviour
{
    [Header("UI Elements")]
    public Button PullButton;        // The button the player presses
    public Image InstructionImage;   // "Press the button" prompt
    public Image BackgroundImage;    // Background (optional)
    public Image FadeImage;          // Full-screen fade overlay

    [Header("Settings")]
    public int PressesRequired = 3;          // How many presses to trigger fade
    public float FadeDuration = 1f;          // Duration of fade in seconds
    public string NextSceneName = "FinalCutscene";  // Scene to load afterward

    private int currentPresses = 0;
    private bool isFading = false;

    void Start()
    {
        // Make sure time isn't frozen if you came from a previous scene
        Time.timeScale = 1f;

        if (PullButton != null)
            PullButton.onClick.AddListener(OnButtonPressed);

        if (FadeImage != null)
            FadeImage.color = new Color(1, 1, 1, 0); // start transparent
    }

    private void OnButtonPressed()
    {
        if (isFading) return; // Ignore presses during fade

        currentPresses++;
        Debug.Log($"Button pressed: {currentPresses}");

        if (currentPresses >= PressesRequired)
        {
            // Hide visuals before fade
            if (InstructionImage != null)
                InstructionImage.gameObject.SetActive(false);
            if (BackgroundImage != null)
                BackgroundImage.gameObject.SetActive(false);

            StartCoroutine(FadeAndLoadNextScene());
        }
    }

    private IEnumerator FadeAndLoadNextScene()
    {
        isFading = true;

        if (FadeImage == null)
        {
            Debug.LogWarning("FadeImage not assigned!");
            yield break;
        }

        float elapsed = 0f;
        Color c = FadeImage.color;

        // Fade in smoothly, unaffected by timeScale
        while (elapsed < FadeDuration)
        {
            elapsed += Time.unscaledDeltaTime;
            c.a = Mathf.Clamp01(elapsed / FadeDuration);
            FadeImage.color = c;
            yield return null;
        }

        // Fully faded — now switch scenes
        SceneManager.LoadScene("FinalCutscene");
    }
}
