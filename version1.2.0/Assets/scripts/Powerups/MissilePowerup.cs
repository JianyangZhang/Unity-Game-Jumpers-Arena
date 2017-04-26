using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePowerup : Powerup {

    //public override Item getItemObject(Player player) {
    //    SpeedDown.print("generate SpeedDown Item");
    //    Item item = new SpeedDownItem(player);
    //    return item;
    //}

    public override string getItemObject() {
        MissilePowerup.print("generate MissilePowerup Item");
        return "MissileItem";
    }


}