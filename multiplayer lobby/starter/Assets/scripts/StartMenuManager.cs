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
		playerNameInput.text = GameManager.instance.playerName;
		buttons[GameManager.instance.characterIndex].onClick.Invoke();
		buttons[GameManager.instance.characterIndex].Select();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void pressGoBtn() {
		if (playerNameInput.text.Length > 0) {
			GameManager.instance.playerName = playerNameInput.text;
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
		GameManager.instance.characterIndex = i;
	}
}