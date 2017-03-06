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
		BasicPlayerInfo.UpdateEyes (BasicPlayerInfo.instance.eyesIndex, armatureComponent);
		BasicPlayerInfo.UpdateChar (BasicPlayerInfo.instance.characterIndex, armatureComponent);
		BasicPlayerInfo.UpdateColor (BasicPlayerInfo.instance.colorIndex, armatureComponent);
		armatureComponent.animation.Play ("JumpBlink",1);
		armatureComponent.transform.localPosition = new Vector3 (-1.0f, -0.6f, -7.0f);
		armatureComponent.transform.localScale =  new Vector3(0.8f, 0.8f, 2.0f);
		//armatureComponent.DispatchEvent(UnityEngine.EventType.MouseDown, )
		//armatureComponent.AddEventListener (UnityEngine.EventType.MouseDown, AnimationController.PlayRandomEventHandler);
		armatureComponent.gameObject.AddComponent<AnimationController>();
		BoxCollider box = armatureComponent.gameObject.AddComponent<BoxCollider> ();
		box.size = new Vector3 (2.0f, 4.0f, 1.0f);
		box.center = new Vector3 (0.0f, 1.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void pressGoBtn() {
		if (playerNameInput.text.Length > 0) {
			if (armatureComponent) {
			}
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

	public void ChgEyesBtnOnClick(){
		BasicPlayerInfo.instance.eyesIndex %= BasicPlayerInfo.eyesRange;
		BasicPlayerInfo.instance.eyesIndex += 1;
		if (armatureComponent) {
			BasicPlayerInfo.UpdateEyes (BasicPlayerInfo.instance.eyesIndex, armatureComponent);
			armatureComponent.animation.Play ("Blink", 1);
		}
	}

	public void ChgCharBtnOnClick(){
		BasicPlayerInfo.instance.characterIndex %= BasicPlayerInfo.characterRange;
		BasicPlayerInfo.instance.characterIndex += 1;

		if (armatureComponent) {
			BasicPlayerInfo.UpdateChar (BasicPlayerInfo.instance.characterIndex, armatureComponent);
			armatureComponent.animation.Play ("Excited", 1);
		}

		GameObject.Find ("Char").GetComponentInChildren<Text> ().text = 
			BasicPlayerInfo.instance.CharacterDiscription[BasicPlayerInfo.instance.characterIndex - 1];
	}

	public void ChgColorBtnOnClick(){
		BasicPlayerInfo.instance.colorIndex %= BasicPlayerInfo.colorRange;
		BasicPlayerInfo.instance.colorIndex += 1;
		if (armatureComponent) {
			BasicPlayerInfo.UpdateColor (BasicPlayerInfo.instance.colorIndex, armatureComponent);
			armatureComponent.animation.Play ("HeadBlink", 1);
		}
	}
}