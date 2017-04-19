using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour {
	Vector3 origin;
	Vector3 current;
	float multi=0.5f;
	float speed=1f;
	float startoffset=0.2f;
	public Vector2 velocity{get{return GetComponent<Rigidbody2D>().velocity;}set{GetComponent<Rigidbody2D>().velocity = value;}}
	// Use this for initialization
	void Awake ()
    {
        multi = Random.Range (0.005f, 0.01f);
		startoffset= Random.Range (1f, 3f)*(Random.Range(0,1)*2-1);
		if ((startoffset + transform.position.x) > 2.025f) {
			transform.position = new Vector3(2.025f, transform.position.y, 0) ;
		} else if ((startoffset + transform.position.x) < -2.025f) {
			transform.position = new Vector3(-2.025f, transform.position.y, 0);
		}
		else {
			transform.position +=new Vector3(startoffset,0,0);
		}
		Debug.Log (transform.position.x);
		//Debug.Log (gameObject.GetComponent<BorderDetection> ().location.x);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate()
	{
        //GetComponent<Rigidbody2D> ().velocity+= Vector2.Scale(origin-current+new Vector2(speed,0),new Vector2(multi,1));

		GetComponent<Rigidbody2D>().velocity += (Vector2)((transform.position - new Vector3(1, transform.position.y, 0)) * (-multi));
        //print (origin.ToString()+" "+current.ToString());
        //if (Camera.main.transform.position.y+ (-5) > transform.position.y)
        //	Destroy (gameObject);
    }
}
