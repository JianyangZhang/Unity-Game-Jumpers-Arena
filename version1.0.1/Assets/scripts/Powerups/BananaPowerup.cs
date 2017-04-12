using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPowerup : Powerup {

    public override string getItemObject() {
        MissilePowerup.print("generate BananaPowerup Item");
        return "BananaItem";
    }
}