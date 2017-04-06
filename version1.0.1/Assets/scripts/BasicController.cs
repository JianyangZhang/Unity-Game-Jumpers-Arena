using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BasicController : NetworkBehaviour {
	public KeyCode upKey, downKey, leftKey, rightKey;
	public float speed = 3;
	private Rigidbody2D rigid;
	public GameObject bulletPrefab_r;
	public Transform bulletSpawn_r;


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

		if (Input.GetKeyDown(KeyCode.Space)) {
			CmdFire();
		}
	}

	[Command]
	void CmdFire() {
		GameObject bullet_r = Instantiate(bulletPrefab_r, bulletSpawn_r.position, bulletSpawn_r.rotation);
		bullet_r.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
		Destroy(bullet_r, 2);
		NetworkServer.Spawn(bullet_r);
	}
	/*
	public override void OnStartLocalPlayer() {
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}
	*/
}