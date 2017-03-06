using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DragonBones;

public class AnimationController : MonoBehaviour {
	private static string[] randomActionSet = { "Blink", "Excited", "ExcitedJump", "HeadBlink", "JumpBlink" };
	// Use this for initialization
	void Start () {
		//var _armatureComponent = this.gameObject.GetComponent<UnityArmatureComponent> ();
	}
	
	// Update is called once per frame
	void Update () {
	}


	void OnMouseDown(){
		var _armatureComponent = this.gameObject.GetComponent<UnityArmatureComponent> ();
		int action = Random.Range (0, AnimationController.randomActionSet.Length);
		if (AnimationController.randomActionSet [action] == _armatureComponent.animation.lastAnimationName) {
			action = (action + 1) % AnimationController.randomActionSet.Length;
		}
		_armatureComponent.animation.Play (AnimationController.randomActionSet [action], 1);
	}
}
