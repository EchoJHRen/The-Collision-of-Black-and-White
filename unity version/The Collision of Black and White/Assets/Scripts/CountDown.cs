using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public GameObject text;
    public GameObject hero1;
    public GameObject hero2;
    public int TotalTime = 3;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(CountDownM());
        hero1.SetActive(false);
        hero2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CountDownM()
    {
        while (TotalTime >= 0)
        {
            text.GetComponent<Text>().text = TotalTime.ToString();
            yield return new WaitForSeconds(1);
            TotalTime--;
            if (TotalTime == 0)
            {
                hero1.SetActive(true);
                hero2.SetActive(true);
                Destroy(text);
            }
        }
    }

}
