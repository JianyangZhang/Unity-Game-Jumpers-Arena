using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class BasicPlayerInfo : MonoBehaviour {
	public static BasicPlayerInfo instance;
	public string playerName;
	public int characterIndex;
	public int eyesIndex;
	public int colorIndex;
	public const int characterRange = 4;
	public const int eyesRange = 5;
	public const int colorRange = 4;
	public string[] CharacterDiscription = {"Assasin", "Archer", "Berserker","Enchanter"};

	void Awake() {
		if (instance) {
			Destroy(gameObject);
		} else {
			instance = this;
			playerName = "";
			characterIndex = 1;
			eyesIndex = 1;
			colorIndex = 1;
			DontDestroyOnLoad(gameObject);
		}
	}

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	public static void UpdateEyes(int index, UnityArmatureComponent armatureComponent) {
		if (!armatureComponent)
			return;
		string picName = "eyes-" + index;
		UnityFactory.factory.ReplaceSlotDisplay ("cat", "MarvinCat", "eyes", picName, armatureComponent.armature.GetSlot("eyes"));
	}

	public static void UpdateChar(int index, UnityArmatureComponent armatureComponent) {
		if (!armatureComponent)
			return;
		string picName = "-deco-" + index;
		UnityFactory.factory.ReplaceSlotDisplay ("cat", "MarvinCat", "body-deco", "body"+picName, armatureComponent.armature.GetSlot("body-deco"));
		UnityFactory.factory.ReplaceSlotDisplay ("cat", "MarvinCat", "head-deco", "head"+picName, armatureComponent.armature.GetSlot("head-deco"));
		UnityFactory.factory.ReplaceSlotDisplay ("cat", "MarvinCat", "lefthand-deco", "lh"+picName, armatureComponent.armature.GetSlot("lefthand-deco"));
		UnityFactory.factory.ReplaceSlotDisplay ("cat", "MarvinCat", "righthand-deco", "rh"+picName, armatureComponent.armature.GetSlot("righthand-deco"));
		UnityFactory.factory.ReplaceSlotDisplay ("cat", "MarvinCat", "leftthigh-deco", "lt"+picName, armatureComponent.armature.GetSlot("leftthigh-deco"));
		UnityFactory.factory.ReplaceSlotDisplay ("cat", "MarvinCat", "leftleg-deco", "ll"+picName, armatureComponent.armature.GetSlot("leftleg-deco"));
		UnityFactory.factory.ReplaceSlotDisplay ("cat", "MarvinCat", "rightthigh-deco", "rt"+picName, armatureComponent.armature.GetSlot("rightthigh-deco"));
		UnityFactory.factory.ReplaceSlotDisplay ("cat", "MarvinCat", "rightleg-deco", "rl"+picName, armatureComponent.armature.GetSlot("rightleg-deco"));
	}

	public static void UpdateColor(int index, UnityArmatureComponent armatureComponent) {
		if (!armatureComponent)
			return;

		string picName = "-color-" + index;
		UnityFactory.factory.ReplaceSlotDisplay ("cat", "MarvinCat", "body-color", "body"+picName, armatureComponent.armature.GetSlot("body-color"));
		UnityFactory.factory.ReplaceSlotDisplay ("cat", "MarvinCat", "head-color", "head"+picName, armatureComponent.armature.GetSlot("head-color"));
		UnityFactory.factory.ReplaceSlotDisplay ("cat", "MarvinCat", "lefthand-color", "lh"+picName, armatureComponent.armature.GetSlot("lefthand-color"));
		UnityFactory.factory.ReplaceSlotDisplay ("cat", "MarvinCat", "righthand-color", "rh"+picName, armatureComponent.armature.GetSlot("righthand-color"));
		UnityFactory.factory.ReplaceSlotDisplay ("cat", "MarvinCat", "leftthigh-color", "lt"+picName, armatureComponent.armature.GetSlot("leftthigh-color"));
		UnityFactory.factory.ReplaceSlotDisplay ("cat", "MarvinCat", "leftleg-color", "ll"+picName, armatureComponent.armature.GetSlot("leftleg-color"));
		UnityFactory.factory.ReplaceSlotDisplay ("cat", "MarvinCat", "rightthigh-color", "rt"+picName, armatureComponent.armature.GetSlot("rightthigh-color"));
		UnityFactory.factory.ReplaceSlotDisplay ("cat", "MarvinCat", "rightleg-color", "rl"+picName, armatureComponent.armature.GetSlot("rightleg-color"));
	}
}