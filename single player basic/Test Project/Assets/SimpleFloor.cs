using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFloor : MonoBehaviour {
	public Camera maincamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (maincamera.transform.position.y + (-5) > transform.position.y)
			DestroyImmediate (this);
	}
}
