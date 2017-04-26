using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public static class SpeedDownItem {
    
    public static float speedRatio = 0.5f;
    public static int delay = 250;

    //public SpeedDownItem(Player p1) {
    //    this.player = p1;
    //    // 1 second = 50 timestemps
    //    delay = 250;
    //    speedRatio = 0.5f;
    //}

    public static void finish(Player player) {
        player.speedRatio = 1;
        player.isDecelerated = false;
    }

    public static void execute(Player currentPlayer) {
        if (!currentPlayer.isShield) {
            currentPlayer.speedRatio = speedRatio;
            currentPlayer.isAccelerated = false;
            currentPlayer.isDecelerated = true;
        }
    }

    public static void use(Player currentPlayer, List<Player> targetPlayers) {
        Player.print("Speed Down Use");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Player.print(players.Length);
        int finishTime = currentPlayer.time + delay;
        //currentPlayer.speedRatio = speedRatio;
        EventBean bean = new EventBean();
        bean.finishTime = finishTime;
        bean.itemName = "SpeedDownItem";
        bean.className = "speed";
        bean.delay = delay;
        //currentPlayer.timeDic["speed"] = bean;
        //currentPlayer.RpcAddEvent("speed", bean);
        foreach (Player player in targetPlayers) {
            Player.print(player.netId);
            Player.print(currentPlayer.netId);
            if (player.netId != currentPlayer.netId) {
                Player.print("apply speedDown, current: " + currentPlayer.netId + "player id:" + player.netId);
                //player.speedRatio = speedRatio;
                bean.id = player.netId;
                if (currentPlayer.isClient)
                    currentPlayer.CmdAddTask(bean);
                else
                    currentPlayer.tasksList.Add(bean);
                //currentPlayer.tasksList.Add(bean);
                //player.RpcAddEvent("speed", bean);
            }
        }
        //StartCoroutine(waitAndPrint(4f, player));

    }

    //IEnumerator waitAndPrint(float waitTime, Player player) {
    //    yield return new WaitForSeconds(waitTime);
    //    player.speedRatio = 1;
    //}
}
