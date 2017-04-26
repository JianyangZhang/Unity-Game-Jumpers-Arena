using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MissileItem {
    
    public static void finish(Player player) {
        player.missileHited = false;
    }

    public static void execute(Player currentPlayer) {
        if (!currentPlayer.isShield) {
            currentPlayer.missileHited = true;
        }
    }

    public static void use(Player currentPlayer, List<Player> targetPlayers) {
        currentPlayer.CmdSetupMissile(currentPlayer.netId);
    }
    
}