using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BananaItem {

    public static void finish(Player player) {
        if (player.isStunned) {
            player.isStunned = false;
            player.velocity = new Vector2(0, 3);
        }
        //player.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    public static void execute(Player currentPlayer) {
        if (!currentPlayer.isShield) {
            currentPlayer.isStunned = true;
            currentPlayer.velocity = new Vector2(0, 0);
        }
        //currentPlayer.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    public static void use(Player currentPlayer, List<Player> targetPlayers) {
        currentPlayer.CmdSetBanana();
    }

}