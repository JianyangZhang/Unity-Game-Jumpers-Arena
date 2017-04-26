using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			animator.SetInteger("state", 0);

		}
		if (Input.GetKeyUp(KeyCode.R)) {
			animator.SetInteger("state", 1);

		}
	}
}
