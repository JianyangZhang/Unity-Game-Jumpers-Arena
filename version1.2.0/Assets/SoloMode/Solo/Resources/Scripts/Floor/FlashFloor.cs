using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashFloor : MonoBehaviour {

	float currentTime=0f;
	public float KeepTime=1f;
	public float TransTime=0.5f;
	public float MissTime=1f;
	float totalTime=0f;
	Color defaultColor;

	// Use this for initialization
	void Start () {
		currentTime = 0f;
		defaultColor = GetComponent<SpriteRenderer> ().color;
	}

	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate()
	{
		float totalTime = KeepTime + TransTime + MissTime + TransTime;
		currentTime += Time.deltaTime;
		while (totalTime <= currentTime)
			currentTime -= totalTime;
		if (currentTime < KeepTime)
			//GetComponent<BoxCollider2D> ().isTrigger = true;
			GetComponent<Rigidbody2D>().simulated=true;
		else if (currentTime < KeepTime + TransTime)
			GetComponent<SpriteRenderer> ().color = new Color(defaultColor.r,defaultColor.g,defaultColor.b, 1 - ((currentTime - KeepTime) / TransTime));
		else if (currentTime < KeepTime + TransTime + MissTime)
			//GetComponent<BoxCollider2D> ().isTrigger = false;
			GetComponent<Rigidbody2D>().simulated=false;
		else
			GetComponent<SpriteRenderer> ().color = new Color(defaultColor.r,defaultColor.g,defaultColor.b, 1 - ((totalTime - currentTime) / TransTime));

		//if (Camera.main.transform.position.y+ (-5) > transform.position.y)
		//	Destroy (gameObject);
	}
}
