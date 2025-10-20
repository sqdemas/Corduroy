using UnityEngine;
using UnityEngine.UI;

public class FinalHeartDisplay : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    void Update()
    {
        foreach (Image img in hearts) {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < HealthController.health; i++) {
            hearts[i].sprite = fullHeart;
        }
    }
}
