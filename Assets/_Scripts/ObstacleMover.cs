using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int minSpeed = 1;
    public int maxSpeed = 10;
    private int speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // float growScale = Random.Range(1f, 4f);
        speed = Random.Range(minSpeed, maxSpeed);
        // transform.localScale += Vector3.one * growScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = new Vector2(
            gameObject.transform.position.x - speed * Time.deltaTime,
            gameObject.transform.position.y);
        gameObject.transform.position = pos;   
    }
}
