using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena{
	public class SimpleFloor : MonoBehaviour {

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			/*Camera.main.transform*/
			//if (Camera.main.transform.position.y + (-5) > transform.position.y)
			//	Destroy (gameObject);
		}

		void OnTriggerEnter2D(Collider2D e)
		{
			if (e.gameObject.tag.CompareTo("Player")==0&&(e.gameObject.GetComponent<Player>().velocity.y < 0))  
			{   
				Onpu.print("Touch");  
				//speedplus += 2f;
				//e.gameObject.GetComponent<Player>().velocity=new Vector2(0,8);//old:12
				if(e.gameObject.GetComponent<Player>().isStunned) {
					e.gameObject.GetComponent<Player> ().m_RigidBody2D.simulated = false;
				}
				//speedplus += 2f;
				else {
					e.gameObject.GetComponent<Player>().velocity=new Vector2(0,8);
				}
				//Destroy(e.gameObject);
			}  
		}
	}
}