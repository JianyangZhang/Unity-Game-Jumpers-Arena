using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : Powerup {

    //public override Item getItemObject(Player player) {
    //    SpeedDown.print("generate SpeedDown Item");
    //    Item item = new SpeedDownItem(player);
    //    return item;
    //}

    public override string getItemObject()
    {
        SpeedUp.print("generate SpeedDown Item");
        return "SpeedDownItem";
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
