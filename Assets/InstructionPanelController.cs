using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class InstructionPanelController : MonoBehaviour
{
    public GameObject InstructionPanel;
    public Image InstructionImage;
    public GameObject NextButton;
    public GameObject BackButton;
    public GameObject StartButton;

    public Sprite FirstImage;
    public Sprite SecondImage;

    public string NextSceneName = "Level01";
    public float FadeDuration = 1f;

    private int currentPage = 1;
    private Image fadeImage;

    void Start()
    {
        ShowPage(1);
        InstructionPanel.SetActive(true);

        GameObject fadeObj = new GameObject("FadeImage");
        fadeObj.transform.SetParent(InstructionPanel.transform.parent, false);
        fadeImage = fadeObj.AddComponent<Image>();
        fadeImage.color = new Color(0,0,0,0);
        RectTransform rect = fadeImage.rectTransform;
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
    }

    private void ShowPage(int page)
    {
        currentPage = page;
        if(page == 1)
        {
            InstructionImage.sprite = FirstImage;
            BackButton.SetActive(false);
            NextButton.SetActive(true);
            StartButton.SetActive(false);
        }
        else if(page == 2)
        {
            InstructionImage.sprite = SecondImage;
            BackButton.SetActive(true);
            NextButton.SetActive(false);
            StartButton.SetActive(true);
        }
    }

    public void OnNext() { if(currentPage<2) ShowPage(currentPage+1); }
    public void OnBack() { if(currentPage>1) ShowPage(currentPage-1); }

    public void OnStart()
    {
        NextButton.SetActive(false);
        BackButton.SetActive(false);
        StartButton.SetActive(false);
        StartCoroutine(FadeAndLoadScene());
    }

    private IEnumerator FadeAndLoadScene()
    {
        float elapsed = 0f;
        while(elapsed < FadeDuration)
        {
            elapsed += Time.deltaTime;
            fadeImage.color = new Color(0,0,0, Mathf.Clamp01(elapsed / FadeDuration));
            yield return null;
        }
        SceneManager.LoadScene("Level01");
    }
}
