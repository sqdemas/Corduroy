using UnityEngine;

public class SecurityGuardController : MonoBehaviour
{
    //public GameObject corduroy;
    public float guardSpeed = 0.01f;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.position.y >= gameObject.transform.position.y)
        {
            if (gameObject.transform.position.y <= 0.5) // upper bound of screen
            {
                // Create a new vector where we modify the x position
                // of our game object
                Vector2 pos = new Vector2(
                    gameObject.transform.position.x,
                    gameObject.transform.position.y - guardSpeed * Time.deltaTime);
                gameObject.transform.position = pos;
            }
        }
        if (GameObject.FindGameObjectWithTag("Player").transform.position.y < gameObject.transform.position.y)
        {
            if (gameObject.transform.position.y >= -4) // lower bound of screen
                {
                // Create a new vector where we modify the x position
                // of our game object
                Vector2 pos = new Vector2(
                    gameObject.transform.position.x,
                    gameObject.transform.position.y + guardSpeed * Time.deltaTime);
                gameObject.transform.position = pos;
                }
        }
    }
}
