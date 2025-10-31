using UnityEngine.UI;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    public static int health = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Awake()
    {
        health = 3;
    }

    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        if (health > 3)
        {
            health = 3;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
}
