using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PowerUpGenerator : MonoBehaviour
{
    public List<GameObject> powers = new List<GameObject>();
    private Vector2 initPoint;

    private int powerNum = 2; // number of powerup assets in powers list, must update when assets are added
    private static int current = 0; // index to iterate through powers list

    private static float[] yRange = { -2f, 0.5f, -3f, -4f}; // preset y values for obstacles to spawn at 
    // high 0.5f
    // mid -2f
    // mid -3f
    // low -4f
    private static int yIndex = 0; // index to iterate through y value list

    private static float waitTime = 14f; // time to wait between spawning power ups

    void Start()
    {
        InvokeRepeating("PlacePower", 20, waitTime);
    }

    void PlacePower()
    {
        initPoint = new Vector2(Random.Range(9f, 10f), yRange[yIndex % 4]); // initial position to place obstacle, random x and one of 4 possible y values
        Instantiate(powers[current], initPoint, Quaternion.identity); // creates obstacles in list order
        current = (current + 1) % powerNum; // updates index of current obstacle
        yIndex++;
    }
}
