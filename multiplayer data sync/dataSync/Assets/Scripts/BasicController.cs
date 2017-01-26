using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BasicController : NetworkBehaviour {
	public KeyCode upKey, downKey, leftKey, rightKey;
	public float speed = 3;
	private Rigidbody2D rigid;


	void Start() {
		rigid = GetComponent<Rigidbody2D>();
	}
	// Update is called once per frame
	void Update() {
		if (isLocalPlayer == false) {
			return;
		}

		if (Input.GetKey(upKey)) {
			rigid.velocity = new Vector2(0, speed);
		} else if (Input.GetKey(downKey)) {
			rigid.velocity = new Vector2(0, -speed);
		} else if (Input.GetKey(leftKey)) {
			rigid.velocity = new Vector2(-speed, 0);
		} else if (Input.GetKey(rightKey)) {
			rigid.velocity = new Vector2(speed, 0);
		} else {
			rigid.velocity = new Vector2(0, 0);
		}
	}
}