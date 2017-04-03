using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena{
	public class Bullet : MonoBehaviour {

		public int damage;
        public float lifetime = 5;
        float currentlifetime = 0;

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
				if (!e.gameObject.GetComponent<Player>().isShield)
					e.gameObject.GetComponent<Player>().hp-=damage;
				Destroy(gameObject);
            }
            if (e.gameObject.tag.CompareTo("Shield") == 0)
            {
                Destroy(gameObject);
            }
        }
	}

}