using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour {

    private int playerflag1 = 0;    //Hero1的flag
    private int playerflag2 = 0;    //Hero2的flag
    private int moveflag = 0;   //墙移动方向
    public float moveSpeed = 0.5f;

    public GameObject Hero1;
    public GameObject Hero2;

    public float startPosition;
    public float endPosition;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //移动墙
        if (gameObject.transform.position.x <= startPosition)
            moveflag = 0;
        if (gameObject.transform.position.x >= endPosition)
            moveflag = 1;
        if (moveflag == 0)
        {
            gameObject.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (playerflag1 == 1)
                Hero1.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (playerflag2 == 1)
                Hero2.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (moveflag == 1)
        {
            gameObject.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (playerflag1 == 1)
                Hero1.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (playerflag2 == 1)
                Hero2.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hero1")
        {
            playerflag1 = 1;
        }
        if (collision.gameObject.tag == "Hero2")
        {
            playerflag2 = 1;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Hero1")
        {
            playerflag1 = 0;
        }
        if (collision.gameObject.tag == "Hero2")
        {
            playerflag2 = 0;
        }
    }

}
