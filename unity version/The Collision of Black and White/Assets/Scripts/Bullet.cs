using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float moveSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
            Destroy(gameObject);
        if (gameObject.tag == "bullet2" && other.tag == "Hero1")
        {
            other.GetComponent<Hero>().hp--;
            Destroy(gameObject);
        }
        if (gameObject.tag == "bullet1" && other.tag == "Hero2")
        {
            other.GetComponent<Hero>().hp--;
            Destroy(gameObject);
        }
    }
}
