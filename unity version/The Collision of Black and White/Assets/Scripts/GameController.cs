using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject pausePanel;

    private int clickCount = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) == true)
            clickCount++;
	}

    public void OnLevelSelect(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseExit(int sceneNum)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneNum);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pausePanel.GetComponent<CanvasGroup>().alpha = 0;
    }

}
