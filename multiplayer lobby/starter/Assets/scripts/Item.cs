using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public abstract class Item  {

    public string itemName;
    public abstract void use(Player currentPlayer, List<Player> targetPlayers);
    public Player player;
    public int finishTime;
    public int delay;

    public abstract void finish();
    
}
