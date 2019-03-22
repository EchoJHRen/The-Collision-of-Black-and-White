using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour {

    public AudioSource BGM;

    public GameObject circle;
    public GameObject mask;
    public GameObject pausePanel;
    public GameObject Hero1;
    public GameObject Hero2;

    private float rotateSpeed = 30.0f;

    // Use this for initialization
    void Start ()
    {
        BGM.loop = true;
        BGM.Play();

        Destroy(GameObject.FindGameObjectWithTag("MenuMusic"));
    }
	
	// Update is called once per frame
	void Update ()
    {
        //背景旋转
        circle.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        mask.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime * 2);

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

}
