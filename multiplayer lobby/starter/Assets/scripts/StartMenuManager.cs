using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour {
	public InputField playerNameInput;
	public Button[] buttons;
	public GameObject alert;
	// Use this for initialization
	void Start () {
		alert.SetActive(false);
		playerNameInput.text = BasicPlayerInfo.instance.playerName;
		buttons[BasicPlayerInfo.instance.characterIndex].onClick.Invoke();
		buttons[BasicPlayerInfo.instance.characterIndex].Select();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void pressGoBtn() {
		if (playerNameInput.text.Length > 0) {
			BasicPlayerInfo.instance.playerName = playerNameInput.text;
			SceneManager.LoadScene(1);
		} else {
			alert.SetActive(true);
			Invoke("disableAlert", 1f);
		}
	}
	private void disableAlert() {
		alert.SetActive(false);
	}

	public void pickCharacter(int i) {
		BasicPlayerInfo.instance.characterIndex = i;
	}
}