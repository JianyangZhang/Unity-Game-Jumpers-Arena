using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logofadeout : MonoBehaviour {

    int fadestatus = 0;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Animation>().Play();
    }

    void FadeIn(float time)
    {
    }

    void FadeOut(float time)
    {
    }
	
	// Update is called once per frame
	void Update () {
	}
}
