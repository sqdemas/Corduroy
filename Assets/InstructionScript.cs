using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartButtonController : MonoBehaviour
{
    public string NextSceneName = "Level01"; // Name of the next scene
    public float FadeDuration = 1f;          // Fade time in seconds

    private Image fadeImage;

    void Start()
    {
        // Create a full-screen black image for fading
        GameObject fadeObj = new GameObject("FadeImage");
        fadeObj.transform.SetParent(transform, false);
        fadeImage = fadeObj.AddComponent<Image>();
        fadeImage.color = new Color(0, 0, 0, 0); // fully transparent
        RectTransform rect = fadeImage.rectTransform;
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
    }

    public void OnStartButtonPressed()
    {
        StartCoroutine(FadeAndLoadScene());
    }

    private IEnumerator FadeAndLoadScene()
    {
        float elapsed = 0f;
        while (elapsed < FadeDuration)
        {
            elapsed += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, Mathf.Clamp01(elapsed / FadeDuration));
            yield return null;
        }
        SceneManager.LoadScene("Level01");
    }
}
