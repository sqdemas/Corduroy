using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // float growScale = Random.Range(1f, 4f);
        // transform.localPosition.x += Vector3.one * growScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 pos = new Vector2(
        //     gameObject.transform.position.x - speed * Time.deltaTime,
        //     gameObject.transform.position.y);
        // gameObject.transform.position = pos;   
    // Create a new vector where we modify the x position
        // of our game object
        Vector2 pos = new Vector2(
            gameObject.transform.position.x,
            gameObject.transform.position.y + speed);

        // Assign new position vector to game object
        gameObject.transform.position = pos;

        if(gameObject.transform.position.y >= 10f)
        {
            Destroy(gameObject);
        }
    
    }
}
