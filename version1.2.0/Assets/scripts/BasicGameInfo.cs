using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGameInfo : MonoBehaviour {
	public static BasicGameInfo instance;
	public int gameMode;
	public bool isMute;

	void Awake() {
		if (instance) {
			Destroy(gameObject);
		} else {
			instance = this;
			gameMode = 0;
			isMute = false;
			DontDestroyOnLoad(gameObject);
		}
	}

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}
}