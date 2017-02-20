using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {
	// public string id; 可以用 Network.connections 返回的是NetworkPlayer[] 有toString方法
	public Character character;
	public string alias;
	public int hp;
	public List<Item> items;
	public bool isShield;
	public bool isAccelerated;
	public bool isDecelerated;
	public bool isStunned;


	public Vector2 velocity {
		get {
			return GetComponent<Rigidbody2D>().velocity;
		}
		set {
			GetComponent<Rigidbody2D>().velocity = value;
		}
	}

	public Vector2 location {
		get {
			return transform.position;
		}
		set {
			transform.position = value;
		}
	}


	// Use this for initialization
	void Start() {
		switch (BasicPlayerInfo.instance.characterIndex) {
			case 0:
				character.slots = 2;
				character.role = "ninja";
				break;				
			case 1:
				character.slots = 3;
				character.role = "hunter";
				break;	
			case 2:
				character.slots = 1;
				character.role = "enchanter";
				break;	
			case 3:
				character.slots = 2;
				character.role = "thief";
				break;	
			default:
				character.slots = 2;
				character.role = "ninja";
				break;
		}
		alias = BasicPlayerInfo.instance.playerName;
		hp = 100;
		items = null;
		isShield = false;
		isAccelerated = false;
		isDecelerated = false;
		isStunned = false;
	}
	
	// Update is called once per frame
	void Update() {
		if (isLocalPlayer == false) {
			return;
		}
	}
}