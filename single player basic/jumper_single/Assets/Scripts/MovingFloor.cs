using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour {

	Vector2 origin;
	Vector2 current;

	// Use this for initialization
	void Start () {
		origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		current = transform.position;
	}

	void FixedUpdate()
	{
		//GetComponent<Rigidbody2D> ().velocity+= /*origin-current+*/new Vector2(5,0);
	}
}
