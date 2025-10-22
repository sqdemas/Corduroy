using UnityEngine;
using System.Collections;

public class SpeedController : MonoBehaviour
{
    public void Start()
    {
        ObstacleMover.obsSpeed = 5; // default speed to start level
        StartCoroutine(SpeedIncrease());
    }

    // increases obstacle speed over course of 2 minute level
    IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(30f);

        ObstacleMover.obsSpeed = 6f;
        LoopingBackground2D.scrollSpeed += 0.5f;
        // Debug.Log("current obs speed: " + ObstacleMover.obsSpeed);
        yield return new WaitForSeconds(60f);

        ObstacleMover.obsSpeed = 6.5f;
        LoopingBackground2D.scrollSpeed += 0.5f;

    }

}
