using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena{

	public class Hero : MonoBehaviour {

		public string id;
		public Character character;
		public string alias;
		public int hp;
		public List<Item> items;
		public bool isShield;
		public bool isAccelerated;
		public bool isDecelerated;
		public bool isStunned;

		public Vector2 velocity{get{return GetComponent<Rigidbody2D>().velocity;}set{GetComponent<Rigidbody2D>().velocity = value;}}

		public Vector2 location{get{return transform.position;}set{transform.position = value;}}

		float speedmul;
		Vector2 movement;
		public Camera maincamera;

		private Rigidbody2D m_RigidBody2D;

		Vector2 nowvelocity;

		// Use this for initialization
		void Awake () {
			//Initialize Module Linking
			m_RigidBody2D=GetComponent<Rigidbody2D>();

			speedmul = 5f;
		}
		
		// Update is called once per frame
		void Update () {
			movement = new Vector2(Input.GetAxis("Horizontal") * speedmul, 0);
		}

		void FixedUpdate() {
			
			nowvelocity = m_RigidBody2D.velocity;
			m_RigidBody2D.velocity= new Vector2(0f,GetComponent<Rigidbody2D> ().velocity.y);
			m_RigidBody2D.velocity+= movement;

			//if (nowvelocity.y > 0)
			//maincamera.transform.position += new Vector3 (0f, Mathf.Max(transform.position.y-maincamera.transform.position.y,0) ,0);
			maincamera.transform.position += new Vector3 (0f, transform.position.y-maincamera.transform.position.y ,0);

		}

		void OnTriggerEnter2D(Collider2D e)
		{
			if (e.gameObject.tag.CompareTo("Floor")==0&&(nowvelocity.y < 0))  
			{   
				Onpu.print("Touch");  
				//speedplus += 2f;
				m_RigidBody2D.velocity=new Vector2(0,15);
				//Destroy(e.gameObject);
			}  
		}

	}
}