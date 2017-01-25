using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicController : MonoBehaviour {
	public KeyCode upKey, downKey;
	public float speed = 3;
	private Rigidbody2D rigid;

	void Start(){
		rigid = GetComponent<Rigidbody2D>();
	}
	// Update is called once per frame
	void Update() {
		if (Input.GetKey(upKey)) {
			rigid.velocity = new Vector2(0, speed);
		} else {
			rigid.velocity = new Vector2(0, 0);
		}
	}
}