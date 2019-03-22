using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoMove : MonoBehaviour {

    public float speed = 1;
    public int flag;        //flag=1：黑球，flag=0：白球

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        speed = speed + Time.deltaTime;
        if (flag == 1)
        {
            transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
            if (transform.position.x >= -0.45)
            {
                Destroy(gameObject);
            }
        }
        else if (flag == 0)
        {
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
            if (transform.position.x <= 0.45)
            {
                Destroy(gameObject);
            }
        }
    }
}
