using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menuBtnClick : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		BasicGameInfo.instance.isMute = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onBtnClick(int i) {
		if (i == 1) {
			animator.SetInteger("clickState", i);
			animator.Play("BtnsClick1", 0, 0.0f);
			BasicGameInfo.instance.gameMode = 1;
			Invoke("loadStartMenu", 1.2f);
		}
		if (i == 2) {
			animator.SetInteger("clickState", i);
			animator.Play("BtnsClick2", 0, 0.0f);
			BasicGameInfo.instance.gameMode = 2;
			Invoke("loadStartMenu", 1.2f);
		}
		if (i == -1) {
			Application.Quit();
		}
	}

	void loadStartMenu() {
		SceneManager.LoadScene("startmenu");
	}

	public void onToggle() {
		BasicGameInfo.instance.isMute = !BasicGameInfo.instance.isMute;
	}
}


