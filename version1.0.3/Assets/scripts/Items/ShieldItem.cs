using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShieldItem {

    public static int delay = 250;

    public static void finish(Player player) {
        player.isShield = false;
    }

    public static void execute(Player currentPlayer) {
        currentPlayer.isShield = true;
    }

    public static void use(Player currentPlayer, List<Player> targetPlayers) {
        //SpeedDownItem.print("Speed Down Use");
        Player.print("Shield On");
        int finishTime = currentPlayer.time + delay;
        EventBean bean = new EventBean();
        bean.finishTime = finishTime;
        bean.itemName = "ShieldItem";
        bean.className = "shield";
        bean.delay = delay;
        bean.id = currentPlayer.netId;
        Player.print("Shield Item " + bean.id);
        if (currentPlayer.isClient)
            currentPlayer.CmdAddTask(bean);
        else
            currentPlayer.tasksList.Add(bean);
    }
}