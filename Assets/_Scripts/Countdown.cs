using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour
{
    // controls 321 countdown at start of game
    public GameObject threeTwoOne;
    public Sprite three;
    public Sprite two;
    public Sprite one;

    public void Start()
    {
        StartCoroutine(CountRoutine());
    }

    IEnumerator CountRoutine()
    {
        threeTwoOne.GetComponent<Image>().sprite = three;
        threeTwoOne.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(1f);
        threeTwoOne.GetComponent<Image>().enabled = false;

        threeTwoOne.GetComponent<Image>().sprite = two;
        threeTwoOne.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(1f);
        threeTwoOne.GetComponent<Image>().enabled = false;

        threeTwoOne.GetComponent<Image>().overrideSprite = one;
        threeTwoOne.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(1f);
        threeTwoOne.GetComponent<Image>().enabled = false;

    }

}
