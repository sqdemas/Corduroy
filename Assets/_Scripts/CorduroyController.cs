using UnityEngine;

public class CorduroyController : MonoBehaviour
{
    public float speed = 0.02f;

    private Vector2 initPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Corduroy is bounded by y position 0 on top
            if(gameObject.transform.position.y <= 0)
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
            if(gameObject.transform.position.y >= -4)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            // On collision with obstacle, subtract 1 health
            HealthController.health--;
            // code to visually show collision by having corduroy bounce back

            // code below should check if health <=0 then lose condition
        }
    }

}
