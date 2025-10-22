using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public static float obsSpeed = 5f;

    void Update()
    {
        // Create a new vector where we modify the x position
        // of our game object
        Vector2 pos = new Vector2(
             gameObject.transform.position.x - obsSpeed * Time.deltaTime,
             gameObject.transform.position.y);
         gameObject.transform.position = pos;   

        // Assign new position vector to game object
        gameObject.transform.position = pos;
    
    }
}
