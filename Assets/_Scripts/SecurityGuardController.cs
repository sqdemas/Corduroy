using UnityEngine;

public class SecurityGuardController : MonoBehaviour
{
    public float guardSpeed = 0.01f;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.position.y >= gameObject.transform.position.y)
        {
                // Create a new vector where we modify the x position
                // of our game object
                Vector2 pos = new Vector2(
                    gameObject.transform.position.x,
                    gameObject.transform.position.y + guardSpeed * Time.deltaTime);
                gameObject.transform.position = pos;
            
        }
        if (GameObject.FindGameObjectWithTag("Player").transform.position.y < gameObject.transform.position.y)
        {

                // Create a new vector where we modify the x position
                // of our game object
                Vector2 pos = new Vector2(
                    gameObject.transform.position.x,
                    gameObject.transform.position.y - guardSpeed * Time.deltaTime);
                gameObject.transform.position = pos;
        }
    }
}
