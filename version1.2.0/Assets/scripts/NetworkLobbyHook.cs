using UnityEngine;
using Prototype.NetworkLobby;
using System.Collections;
using UnityEngine.Networking;

public class NetworkLobbyHook : LobbyHook {
	public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer) {
		LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
		Player localPlayer = gamePlayer.GetComponent<Player>();

		localPlayer.alias = lobby.playerName;
		localPlayer.role = lobby.playerRole;
		localPlayer.slots = lobby.playerSlots;
		localPlayer.eyes = lobby.playerEyes;
		localPlayer.skin = lobby.playerSkin;
        //localPlayer.camera = Camera.main; 
	}
}