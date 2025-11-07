using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PullButtonController : MonoBehaviour
{
    public Button PullButton;       // The drawn button
    public Text InstructionText;    // Optional instruction text
    public Image FadeImage;         // Drag the pre-made FadeImage here

    public int PressesRequired = 3;
    public float FadeDuration = 1f;
    public string FinalCutsceneScene = "FinalCutscene";

    private int currentPresses = 0;

    void Start()
    {
        if (PullButton != null)
            PullButton.onClick.AddListener(OnButtonPressed);

        if (FadeImage != null)
            FadeImage.color = new Color(1, 1, 1, 0); // start fully transparent
    }

    public void OnButtonPressed()
    {
        currentPresses++;
        Debug.Log("Button pressed: " + currentPresses);

        if (currentPresses >= PressesRequired)
        {
            if (InstructionText != null)
                InstructionText.gameObject.SetActive(false); // hide instructions
            StartCoroutine(FadeAndLoadFinalCutscene());
        }
    }

    private IEnumerator FadeAndLoadFinalCutscene()
    {
        if (FadeImage == null)
        {
            Debug.LogWarning("FadeImage not assigned!");
            yield break;
        }

        float elapsed = 0f;
        while (elapsed < FadeDuration)
        {
            elapsed += Time.deltaTime;
            FadeImage.color = new Color(1, 1, 1, Mathf.Clamp01(elapsed / FadeDuration));
            yield return null;
        }

        SceneManager.LoadScene("FinalCutscene");
    }
}
