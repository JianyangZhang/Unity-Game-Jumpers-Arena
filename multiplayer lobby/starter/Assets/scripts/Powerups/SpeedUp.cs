using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Powerup {

    public override Item getItemObject(Player player) {
        SpeedUp.print("generate SpeedUp Item");
        Item item = new SpeedUpItem(player);
        return item;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }


}
