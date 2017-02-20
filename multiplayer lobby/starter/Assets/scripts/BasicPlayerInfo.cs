using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerInfo : MonoBehaviour {
	public static BasicPlayerInfo instance;
	public string playerName;
	public int characterIndex;
	void Awake() {
		if (instance) {
			Destroy(gameObject);
		} else {
			instance = this;
			playerName = "";
			characterIndex = 0;
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