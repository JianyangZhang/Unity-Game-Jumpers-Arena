using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

//public abstract class Item  {

//    public string itemName;
//    public abstract void use(Player currentPlayer, List<Player> targetPlayers);
//    public Player player;
//    public int finishTime;
//    public int delay;

//    public abstract void finish();

//}


public static class Item {
    private static List<Player> targetPlayers = null;

    public static void initItem() {
        targetPlayers = null;
    }

    private static void getPlayers() {
        if (targetPlayers != null)
            return;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        Player.print(objs.Length + "player objs");
        List<Player> players = new List<Player>();
        foreach (GameObject gameObj in objs) {
            Player p = gameObj.GetComponent<Player>();
            players.Add(p);
            Player.print("network id :" + p.netId);
            Player.print("name :" + p.alias);
        }
        targetPlayers = players;
    }

    public static void use(string itemName, Player currentPlayer) {
        getPlayers();
        if (itemName == "SpeedDownItem") {
            SpeedDownItem.use(currentPlayer, targetPlayers);
        } else if (itemName == "SpeedUpItem") {
            SpeedUpItem.use(currentPlayer, targetPlayers);
        } else if (itemName == "MissileItem") {
            MissileItem.use(currentPlayer, targetPlayers);
        } else if (itemName == "BananaItem") {
            BananaItem.use(currentPlayer, targetPlayers);
        }
    }

    public static void execute(string itemName, Player currentPlayer) {
        if (itemName == "SpeedDownItem") {
            SpeedDownItem.execute(currentPlayer);
        } else if (itemName == "SpeedUpItem") {
            SpeedUpItem.execute(currentPlayer);
        } else if (itemName == "MissileItem") {
            MissileItem.execute(currentPlayer);
        } else if (itemName == "BananaItem") {
            BananaItem.execute(currentPlayer);
        }
    }

    public static void finish(string itemName, Player currentPlayer) {
        if (itemName == "SpeedDownItem") {
            SpeedDownItem.finish(currentPlayer);
        } else if (itemName == "SpeedUpItem") {
            SpeedUpItem.finish(currentPlayer);
        } else if (itemName == "MissileItem") {
            MissileItem.finish(currentPlayer);
        } else if (itemName == "BananaItem") {
            BananaItem.finish(currentPlayer);
        }
    }
}