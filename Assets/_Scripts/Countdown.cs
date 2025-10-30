using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour
{
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
        // threeTwoOne.SetActive(true);
        yield return new WaitForSeconds(1f);
        threeTwoOne.GetComponent<Image>().enabled = false;
        //threeTwoOne.SetActive(false);

        threeTwoOne.GetComponent<Image>().sprite = two;
     threeTwoOne.GetComponent<Image>().enabled = true;
        // threeTwoOne.SetActive(true);
        yield return new WaitForSeconds(1f);
        threeTwoOne.GetComponent<Image>().enabled = false;
        //threeTwoOne.SetActive(false);

        threeTwoOne.GetComponent<Image>().overrideSprite = one;
     //threeTwoOne.SetActive(true);
     threeTwoOne.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(1f);
        threeTwoOne.GetComponent<Image>().enabled = false;
     //threeTwoOne.SetActive(false);

        // threeTwoOne.GetComponent<Text>().text = "3";
        // threeTwoOne.SetActive(true);
        // yield return new WaitForSeconds(1f);
        // threeTwoOne.SetActive(false);

        // threeTwoOne.GetComponent<Text>().text = "2";
        // threeTwoOne.SetActive(true);
        // yield return new WaitForSeconds(1f);
        // threeTwoOne.SetActive(false);

        // threeTwoOne.GetComponent<Text>().text = "1";
        // threeTwoOne.SetActive(true);
        // yield return new WaitForSeconds(1f);
        // threeTwoOne.SetActive(false);

    }

}
