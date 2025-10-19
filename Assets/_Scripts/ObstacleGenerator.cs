using System.Collections.Generic;
using UnityEngine;


public class ObstacleGenerator : MonoBehaviour
{

    public List<GameObject> obstacles = new List<GameObject>();
    public Vector2 initPoint;
    public int obstacleNum = 4; // number of obstacle assets, must update if any assets are added
    private static int currentObs = 0; // index of current obstacle in array
    private static float[] yRange = { -2f, -4f, 0.5f, -3f, -4f, -1f, -0.5f}; // preset y values for obstacles to spawn at
    private static int yIndex = 0; // index to iterate through y values

    void Start()
    {
        InvokeRepeating("PlaceObstacle", 3, 1.5f);
    }

    void PlaceObstacle()
    {   
        initPoint = new Vector2(Random.Range(8f, 10f), yRange[yIndex%6]); // random initial position to place obstacle
        Instantiate(obstacles[currentObs], initPoint, Quaternion.identity); // creates obstacles in array order
        currentObs = (currentObs + 1) % obstacleNum; // updates index of current obstacle
        yIndex++; 
    }
}
