using UnityEngine;
using System.Collections;
public class LoopingBackground2D : MonoBehaviour
{

    public static float scrollSpeed = 1.5f; // background scroll speed
    public float backgroundWidth; // width of background

    private Transform[] backgrounds; // array for references to backgrounds
    public static float timeScale;

    void Start()
    {
        // Get references to the child background tiles
        backgrounds = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }

        // Calculate the width of a single background tile
        // Assuming both tiles have the same width and a SpriteRenderer
        if (backgrounds.Length > 0 && backgrounds[0].GetComponent<SpriteRenderer>() != null)
        {
            backgroundWidth = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
        }
        else
        {
            Debug.LogError("Background tiles or SpriteRenderer not found!");
        }
    }

    void Update()
    {
        // Move all background tiles to the left
        foreach (Transform bg in backgrounds)
        {
            bg.Translate(Vector3.left * scrollSpeed * timeScale * Time.deltaTime); // time scale allows backrgound loop to freeze
        }

        // Check if the first background tile is off-screen and reposition it
        if (backgrounds[0].position.x < -backgroundWidth)
        {
            // Move the first tile to the right of the second tile
            backgrounds[0].position = new Vector3(backgrounds[1].position.x + backgroundWidth, backgrounds[0].position.y, backgrounds[0].position.z);
            // Swap the order in the array to maintain the "first" and "second" tile concept
            Transform temp = backgrounds[0];
            backgrounds[0] = backgrounds[1];
            backgrounds[1] = temp;
        }
    }
}
