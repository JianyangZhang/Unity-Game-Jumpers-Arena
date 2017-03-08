using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena{
	public class Bullet : MonoBehaviour {

		public int damage;
		public GameObject shooter;

		// Use this for initialization
		void Awake () {
			damage = 10;
		}
		
		// Update is called once per frame
		void Update () {
		}


		void OnTriggerEnter2D(Collider2D e)
		{
			if (e.gameObject.tag.CompareTo("Player")==0)  
			{   
				if (!e.gameObject.GetComponent<Player>().isShield)
					e.gameObject.GetComponent<Player>().hp-=damage;
				Destroy(gameObject);
			}  
		}
	}

}