using UnityEngine;

public class Boundary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject); // Destroys obstacles once they hit boundary offscreen
    }
}
