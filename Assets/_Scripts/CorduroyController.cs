using UnityEngine;

public class CorduroyController : MonoBehaviour
{
    public float speed = 0.5f;

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
            // Create a new vector where we modify the y position
            // of our game object
            Vector2 pos = new Vector2(
                gameObject.transform.position.x,
                gameObject.transform.position.y + speed);

            // Assign new position vector to game object
            gameObject.transform.position = pos;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
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
