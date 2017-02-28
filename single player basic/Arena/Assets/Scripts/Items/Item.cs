using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item {

    public string itemName;
    public abstract void use(Player1 currentPlayer, List<Player1> targetPlayers);
    public Player1 player;
    public int finishTime;
    public int delay;

    public abstract void finish();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
