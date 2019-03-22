using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueMusic : MonoBehaviour {

    public GameObject menuBGM;
    private GameObject obj = null;

    // Use this for initialization
    void Start () {
        obj = GameObject.FindGameObjectWithTag("MenuMusic");
        if (obj == null)
        {
            Instantiate(menuBGM);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
