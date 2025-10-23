using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ObstacleGenerator : MonoBehaviour
{

    public List<GameObject> obstacles = new List<GameObject>();
    private Vector2 initPoint;
    public int obstacleNum = 7; // number of obstacle assets, must update if any assets are added
    private static int currentObs = 0; // index of current obstacle in array
    private static float[] yRange = { -3f, 0.5f, -2.5f, -4f, -1f, -3.5f, 0.5f, -4f, -0.5f }; // preset y values for obstacles to spawn at 
    // high 0.5f
    // mid -0.5f
    // mid -1f
    // mid -2f
    // mid -3f
    // low -4f
    private static int yIndex = 0; // index to iterate through y values

    public static float waitTime;

    void Start()
    {
        waitTime = 1.5f; // default wait time to start level
        InvokeRepeating("PlaceObstacle", 3, waitTime);
        StartCoroutine(changeGenerationTime());

    }

    void PlaceObstacle()
    {
        initPoint = new Vector2(Random.Range(8f, 10f), yRange[yIndex % 9]); // random initial position to place obstacle
        Instantiate(obstacles[currentObs], initPoint, Quaternion.identity); // creates obstacles in array order
        currentObs = (currentObs + 1) % obstacleNum; // updates index of current obstacle
        yIndex++;
    }
    IEnumerator changeGenerationTime()
    {
        yield return new WaitForSeconds(30f);

        waitTime = 1.2f;
        CancelInvoke("PlaceObstacle");
        InvokeRepeating("PlaceObstacle", 1, waitTime);
        // Debug.Log("current wait time: " + waitTime);
        yield return new WaitForSeconds(30f);

        waitTime = 1f;
        CancelInvoke("PlaceObstacle");
        InvokeRepeating("PlaceObstacle", 1, waitTime);
    }
}
