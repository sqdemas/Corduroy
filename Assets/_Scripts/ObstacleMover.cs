using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float obsSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = new Vector2(
             gameObject.transform.position.x - obsSpeed * Time.deltaTime,
             gameObject.transform.position.y);
         gameObject.transform.position = pos;   
    // Create a new vector where we modify the x position
        // of our game object
  

        // Assign new position vector to game object
        gameObject.transform.position = pos;

        // if(gameObject.transform.position.x <= -10f)
        // {
        //     Destroy(gameObject);
        // }
    
    }
}
