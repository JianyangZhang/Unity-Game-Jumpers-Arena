using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Powerup {

    //public override Item getItemObject(Player player) {
    //    SpeedUp.print("generate SpeedUp Item");
    //    Item item = new SpeedUpItem(player);
    //    return item;
    //}

    public override string getItemObject()
    {
        SpeedUp.print("generate SpeedUp Item");
        return "SpeedUpItem";
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }


}
