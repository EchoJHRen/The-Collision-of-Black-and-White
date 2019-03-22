using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour {

    public AudioSource BGM;

    public GameObject taichi;
    public GameObject mask;
    public GameObject Hero1;
    public GameObject Hero2;
    public GameObject pausePanel;

    private float rotateSpeed = 30.0f;
    private float fadeSpeed = 0.1f;
    private int alphaFlag = 0;

    // Use this for initialization
    void Start () {
        BGM.loop = true;
        BGM.Play();

        Destroy(GameObject.FindGameObjectWithTag("MenuMusic"));
	}
	
	// Update is called once per frame
	void Update () {
        //太极旋转
        taichi.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        alphaChange();

        //左右互通
        if (Hero1.transform.position.x <= -6.7)
        {
            Hero1.transform.position = new Vector3((float)6.7, Hero1.transform.position.y, Hero1.transform.position.z);
        }
        if (Hero1.transform.position.x >= 6.7)
        {
            Hero1.transform.position = new Vector3((float)-6.7, Hero1.transform.position.y, Hero1.transform.position.z);
        }
        if (Hero2.transform.position.x <= -6.7)
        {
            Hero2.transform.position = new Vector3((float)6.7, Hero2.transform.position.y, Hero2.transform.position.z);
        }
        if (Hero2.transform.position.x >= 6.7)
        {
            Hero2.transform.position = new Vector3((float)-6.7, Hero2.transform.position.y, Hero2.transform.position.z);
        }

        //暂停面板
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
        {
            pausePanel.GetComponent<CanvasGroup>().alpha = 1;
            Time.timeScale = 0;
        }

        //胜利判定
        if (Hero1.transform.position.y <= -5.5 || Hero1.GetComponent<Hero>().hp <= 0)
            SceneManager.LoadScene(6);
        if (Hero2.transform.position.y <= -5.5 || Hero2.GetComponent<Hero>().hp <= 0)
            SceneManager.LoadScene(5);
    }

    void alphaChange()
    {
        //背景渐变
        Color color = mask.GetComponent<Image>().color;
        if (alphaFlag == 0)
        {
            color.a += Time.deltaTime * fadeSpeed;
        }
        if (color.a >= 1)
        {
            alphaFlag = 1;
        }
        if (alphaFlag == 1)
        {
            color.a -= Time.deltaTime * fadeSpeed;
        }
        if (color.a <= 0)
        {
            alphaFlag = 0;
        }
        mask.GetComponent<Image>().color = color;
    }

}
