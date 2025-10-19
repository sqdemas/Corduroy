using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour
{
    public GameObject countdown;

    public void Start()
    {
        StartCoroutine(CountRoutine());
    }

    IEnumerator CountRoutine()
    {
        countdown.GetComponent<Text>().text = "3";
        countdown.SetActive(true);
        yield return new WaitForSeconds(1f);
        countdown.SetActive(false);

        countdown.GetComponent<Text>().text = "2";
        countdown.SetActive(true);
        yield return new WaitForSeconds(1f);
        countdown.SetActive(false);

        countdown.GetComponent<Text>().text = "1";
        countdown.SetActive(true);
        yield return new WaitForSeconds(1f);
        countdown.SetActive(false);

    }

}
