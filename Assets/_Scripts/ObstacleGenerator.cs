using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ObstacleGenerator : MonoBehaviour
{

    public List<GameObject> obstacles = new List<GameObject>();
    private Vector2 initPoint;
    private int obstacleNum = 11; // number of obstacle assets, must update if any assets are added
    private static int currentObs = 0; // index of current obstacle to iterate through obstacles list
    private static float[] yRange = { -3f, 0.5f, -2.5f, -4f, -1f, -3.5f, 0.5f, -4f, -0.5f }; // preset y values for obstacles to spawn at 
    // high 0.5f
    // mid -0.5f
    // mid -1f
    // mid -2f
    // mid -3f
    // low -4f
    private static int yIndex = 0; // index to iterate through y values

    public static float waitTime; // time between obstacle spawns

    void Start()
    {
        waitTime = 1.5f; // default time to start level
        InvokeRepeating("PlaceObstacle", 3, waitTime);
        StartCoroutine(changeGenerationTime()); // changes wait time over course of level

    }

    void PlaceObstacle()
    {
        initPoint = new Vector2(Random.Range(8f, 10f), yRange[yIndex % 9]); // initial position to place obstacle, random x and one of 9 possible y values
        Instantiate(obstacles[currentObs], initPoint, Quaternion.identity); // creates obstacles in list order
        currentObs = (currentObs + 1) % obstacleNum; // updates index of current obstacle
        yIndex++;
    }
    IEnumerator changeGenerationTime()
    {
        // every 30 seconds, wait time decreases
        yield return new WaitForSeconds(30f);

        waitTime = 1.1f;
        CancelInvoke("PlaceObstacle");
        InvokeRepeating("PlaceObstacle", 1, waitTime);
        
        yield return new WaitForSeconds(30f);

        waitTime = 0.85f;
        CancelInvoke("PlaceObstacle");
        InvokeRepeating("PlaceObstacle", 1, waitTime);
    }
}
