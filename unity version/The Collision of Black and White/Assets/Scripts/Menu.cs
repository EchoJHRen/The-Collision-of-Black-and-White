using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject taichi;
    public GameObject Particle1;    //白色粒子
    public GameObject Particle2;    //黑色粒子
    public GameObject bg;           //UI panel

    private float showTime = 0.3f;
    public float waitTime = 3.0f;

    public float rotateSpeed = 30.0f;

    private int flag = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitAndRun(waitTime));

        if (taichi.GetComponent<Image>().color.a >= 1 && taichi.transform.eulerAngles.z <= 180 && flag == 0)     //太极图透明度变回1之后
        {
            taichi.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
            if (taichi.transform.eulerAngles.z >= 180)
                flag = 1;
        }
        if (flag == 1)
        {
            Color color = taichi.GetComponent<Image>().color;
            color.a -= 0.03f;
            taichi.GetComponent<Image>().color = color;

            bg.GetComponent<CanvasGroup>().alpha += 0.01f ;
        }
    }

    void Show(float showTime)
    {
        Color color = taichi.GetComponent<Image>().color;
        color.a += Time.deltaTime * showTime;
        if (color.a >= 1)
        {
            Particle1.GetComponent<ParticleSystem>().Stop();
            Particle2.GetComponent<ParticleSystem>().Stop();    //停止粒子
        }
        taichi.GetComponent<Image>().color = color;
    }

    IEnumerator WaitAndRun(float waitTime)      //延迟执行
    {
        yield return new WaitForSeconds(waitTime);
        Show(showTime);
    }
}
