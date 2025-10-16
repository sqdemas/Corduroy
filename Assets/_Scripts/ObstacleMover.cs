using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float minSpeed = 0.5f;
    public float maxSpeed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = new Vector2(
             gameObject.transform.position.x - Random.Range(minSpeed, maxSpeed) * Time.deltaTime,
             gameObject.transform.position.y);
         gameObject.transform.position = pos;   
    // Create a new vector where we modify the x position
        // of our game object
  

        // Assign new position vector to game object
        gameObject.transform.position = pos;

        if(gameObject.transform.position.y <= -10f)
        {
            Destroy(gameObject);
        }
    
    }
}
