using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PowerUpGenerator : MonoBehaviour
{
    public List<GameObject> powers = new List<GameObject>();
    private Vector2 initPoint;

    private int powerNum = 2; // number of powerup assets, must update if any assets are added
    private static int current = 0; // index of current powerup to iterate through powers list

    private static float[] yRange = { -2f, 0.5f, -3f, -4f}; // preset y values for obstacles to spawn at 
    // high 0.5f
    // mid -0.5f
    // mid -1f
    // mid -2f
    // mid -3f
    // low -4f
    private static int yIndex = 0; // index to iterate through y value array

    public static float waitTime;

    void Start()
    {
        waitTime = 15f; // time to wait between spawning power ups
        InvokeRepeating("PlacePower", 20, waitTime);
    }

    void PlacePower()
    {
        initPoint = new Vector2(Random.Range(8f, 10f), yRange[yIndex % 4]); // random initial position to place obstacle, random x and one of 9 possible y values
        Instantiate(powers[current], initPoint, Quaternion.identity); // creates obstacles in array order
        current = (current + 1) % powerNum; // updates index of current obstacle
        yIndex++;
    }
}
