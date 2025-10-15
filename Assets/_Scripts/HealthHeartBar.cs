using UnityEngine.UI;
using UnityEngine;

public class HealthHeartBar : MonoBehaviour
{

    public int health = 3;

    public Image[] hearts;

    public Sprite fullHeart;

    public Sprite emptyHeart;

    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hearts) {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++) {
            hearts[i].sprite = fullHeart;
        }
    }
}
