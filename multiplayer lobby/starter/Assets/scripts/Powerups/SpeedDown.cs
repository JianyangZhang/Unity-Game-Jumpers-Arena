using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : Powerup {

    public override Item getItemObject(Player player) {
        SpeedDown.print("generate SpeedDown Item");
        Item item = new SpeedDownItem(player);
        return item;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
