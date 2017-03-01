using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DragonBones;

public class StartMenuManager : MonoBehaviour {
	public InputField playerNameInput;
	public Button[] buttons;
	public GameObject alert;
	public UnityArmatureComponent armatureComponent = null;
	// Use this for initialization
	void Start () {
		alert.SetActive(false);
		playerNameInput.text = BasicPlayerInfo.instance.playerName;
		buttons[BasicPlayerInfo.instance.characterIndex].onClick.Invoke();
		buttons[BasicPlayerInfo.instance.characterIndex].Select();
		UnityFactory.factory.LoadDragonBonesData ("MarvinCat/MarvinCat_ske");
		UnityFactory.factory.LoadTextureAtlasData ("MarvinCat/MarvinCat_tex");
		armatureComponent = UnityFactory.factory.BuildArmatureComponent ("MarvinCat");
		armatureComponent.animation.Play ("JumpBlink",2);
		armatureComponent.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
		armatureComponent.transform.localScale =  new Vector3(0.2f, 0.2f, 2.0f);
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
		if (armatureComponent) {
			armatureComponent.animation.Play ("HeadBlink", 1);
		}
	}
}