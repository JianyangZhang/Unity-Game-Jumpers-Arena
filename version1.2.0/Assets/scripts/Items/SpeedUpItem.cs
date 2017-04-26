using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public static class SpeedUpItem {

    public static float speedRatio = 1.5f;
    public static int delay = 250;

    //public SpeedUpItem(Player p1) {
    //    this.player = p1;
    //    // 1 second = 50 timestemps
    //    delay = 250;
    //    speedRatio = 1.5f;
    //}

    public static void finish(Player player) {
        player.speedRatio = 1;
    }

    public static void execute(Player currentPlayer) {
        currentPlayer.speedRatio = speedRatio;
    }

    public static void use(Player currentPlayer, List<Player> targetPlayers) {
        //SpeedDownItem.print("Speed Down Use");
        currentPlayer.isAccelerated = true;
        currentPlayer.isDecelerated = false;
        int finishTime = currentPlayer.time + delay;
        EventBean bean = new EventBean();
        bean.finishTime = finishTime;
        bean.itemName = "SpeedUpItem";
        bean.className = "speed";
        bean.delay = delay;
        bean.id = currentPlayer.netId;
        Player.print("Speed Up Item " + bean.id);
        //currentPlayer.speedRatio = speedRatio;
        //currentPlayer.timeDic["speed"] = bean;
        if (currentPlayer.isClient)
            currentPlayer.CmdAddTask(bean);
        else
            currentPlayer.tasksList.Add(bean);
        //currentPlayer.RpcAddEvent("speed", bean);
        //StartCoroutine(waitAndPrint(4f, player));
    }

    //IEnumerator waitAndPrint(float waitTime, Player player) {
    //    yield return new WaitForSeconds(waitTime);
    //    player.speedRatio = 1;
    //}

}
