using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject instructionPanel;

    public void ShowInstructions()
    {
        instructionPanel.SetActive(true);
        Time.timeScale = 0f; // pause gameplay if you want
    }

    public void HideInstructions()
    {
        instructionPanel.SetActive(false);
        Time.timeScale = 1f; // resume gameplay
    }
}
