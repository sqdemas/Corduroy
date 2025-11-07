using UnityEngine;
using System.Collections;

public class SpeedController : MonoBehaviour
{
    // changes speed of obstacles in ObstacleMover
    public void Start()
    {
        ObstacleMover.obsSpeed = 5; // default speed to start level
        StartCoroutine(SpeedIncrease());
    }

    
    IEnumerator SpeedIncrease()
    {
        // increases obstacle speed every 30 seconds
        yield return new WaitForSeconds(33f); // extra 3 seconds bc of beginning countdown

        ObstacleMover.obsSpeed = 6f;
        LoopingBackground2D.scrollSpeed = 2.5f;
        
        yield return new WaitForSeconds(30f);

        ObstacleMover.obsSpeed = 7f;
        LoopingBackground2D.scrollSpeed = 3.5f;

    }

}
