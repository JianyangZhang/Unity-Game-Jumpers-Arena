using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
	public abstract class Item : MonoBehaviour {

		public string itemName;
		public abstract void use(Player currentPlayer, List<Player> targetPlayers);

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}
	}
}
