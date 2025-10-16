using System.Collections.Generic;
using UnityEngine;


public class ObstacleGenerator : MonoBehaviour
{

    public List<GameObject> obstacles = new List<GameObject>();
    public Vector2 initPoint;
    public int obstacleNum = 4;
    private static int currentObs = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("PlaceObstacle", 0, 2f);

    }

    // Update is called once per frame
    void PlaceObstacle()
    {
        // int currentObs = Random.Range(0, obstacles.Count);
        // initPoint = new Vector2(Random.Range(0f, 10f), Random.Range(-4f, 0f));
        // Instantiate(obstacles[currentObs], initPoint, Quaternion.identity);

        // iterates through array of obstacles
        
        initPoint = new Vector2(Random.Range(0f, 10f), Random.Range(-4f, 0f));
        Instantiate(obstacles[currentObs], initPoint, Quaternion.identity);
        currentObs = (currentObs+1) % obstacleNum;

    }
}
