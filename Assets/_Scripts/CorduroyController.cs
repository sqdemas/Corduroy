using UnityEngine;
using System.Collections;

public class CorduroyController : MonoBehaviour
{
    public float speed = 0.02f;
    private Vector2 initPosition;

    void Start()
    {
        initPosition = gameObject.transform.position;
        Physics2D.IgnoreLayerCollision(7, 8, false); // resets collisions each time the scene reloads
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.isScreenFrozen == false)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                // Corduroy is bounded by y position 0 on top
                if (gameObject.transform.position.y <= 0)
                {
                    // Create a new vector where we modify the y position
                    // of our game object
                    Vector2 pos = new Vector2(
                        gameObject.transform.position.x,
                        gameObject.transform.position.y + speed);

                    // Assign new position vector to game object
                    gameObject.transform.position = pos;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                // Corduroy is bounded by y position -4 on bottom
                if (gameObject.transform.position.y >= -4)
                {
                    // Create a new vector where we modify the x position
                    // of our game object
                    Vector2 pos = new Vector2(
                      gameObject.transform.position.x,
                    gameObject.transform.position.y - speed);

                    // Assign new position vector to game object
                    gameObject.transform.position = pos;
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            // On collision with obstacle, subtract 1 health
            HealthController.health--;
            // Play sound effect
            AudioManager.instance.Play("TakeDamage");
            // Code to visually show collision
            StartCoroutine(GetHurt());
            // Code to check if health <=0 then plays GameOver screen
            if (HealthController.health <= 0)
            {
                GameManager.isGameOver = true;
            }


        }
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(7, 8); // prevents player from taking damage from obstacle for 3 seconds after collision
        GetComponent<Animator>().SetLayerWeight(1, 1); // plays hurt animation for 3 seconds
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(7, 8, false); // resets collisions
    }

}
