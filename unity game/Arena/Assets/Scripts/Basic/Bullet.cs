using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena{
	public class Bullet : MonoBehaviour {

		public int damage;
        public float lifetime;
        float currentlifetime = 0;

		private Player P1;
		private Hero H1;
		private Hero hero_bullet;
        public GameObject shooter;
        private Rigidbody2D m_RigidBody2D;

        public void SetSpeed(Vector2 vtar)
        {
            m_RigidBody2D.velocity = vtar;
        }

		// Use this for initialization
		void Awake () {
			damage = 10;
            m_RigidBody2D = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        void Update ()
        {
            currentlifetime += Time.deltaTime;
            if (currentlifetime > lifetime) Destroy(gameObject);

        }


		void OnTriggerEnter2D(Collider2D e)
		{
			if (e.gameObject.tag.CompareTo("Player")==0)  
			{  
				//Destroy (e.gameObject);
				P1 = e.gameObject.GetComponent<Player> ();
				if (!P1.isShield)
					P1.hp -= damage;
				P1.player_renderer.material.shader = Shader.Find ("Custom/NewSurfaceShader");
				if (P1.hp == 0) {
					P1.scale = new Vector3 (1, 1, 1);
					P1.isShield = true;
					P1.isStunned = true;
					P1.velocity = new Vector2 (0, 0);
					//P1.m_RigidBody2D.simulated = false;
					Invoke ("frozen", 2);

					//e.gameObject.GetComponent<Player> ().velocity = new Vector2 (0,0);
				} 
				else {
					P1.scale = new Vector3 (1, 1, 1);
					Invoke ("Message", 0.1f);
				}
            }
        }

		private void Message() {
			P1.player_renderer.material.shader = Shader.Find ("Sprites/Default");
		}
		private void frozen() {
			P1.hp = 100;
			P1.player_renderer.material.shader = Shader.Find ("Sprites/Default");
			P1.isStunned = false;
			P1.isShield = false;
			P1.m_RigidBody2D.simulated = true;
		}
		}
	}