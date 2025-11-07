using UnityEngine;

public class SecurityGuardController : MonoBehaviour
{
    public float guardSpeed = 0.01f;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.position.y >= gameObject.transform.position.y)
        {
                // move guard up if player is higher
                Vector2 pos = new Vector2(
                    gameObject.transform.position.x,
                    gameObject.transform.position.y + guardSpeed * Time.deltaTime);
                gameObject.transform.position = pos;
            
        }
        if (GameObject.FindGameObjectWithTag("Player").transform.position.y < gameObject.transform.position.y)
        {

                // move guard down if Corduroy is lower
                Vector2 pos = new Vector2(
                    gameObject.transform.position.x,
                    gameObject.transform.position.y - guardSpeed * Time.deltaTime);
                gameObject.transform.position = pos;
        }
    }
}
