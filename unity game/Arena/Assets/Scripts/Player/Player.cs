using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena{

	public class Player : MonoBehaviour,IDamage {

		public string id;
		public Character character;
		public string alias;
		public int hp;
		public int timeleft;
		public float f_timeleft;
		public List<Item> items;
		public bool isShield;
		public bool isAccelerated;
		public bool isDecelerated;
		public bool isStunned;

        public int Hp { set { hp = value; } get { return hp; } }
        public bool IsIDamageWork { get { return false;} }
        public void Damage(int damageto)
        {
            hp -= damageto;
        }

        public Vector2 velocity{get{return GetComponent<Rigidbody2D>().velocity;}set{GetComponent<Rigidbody2D>().velocity = value;}}

		public Vector2 location{get{return transform.position;}set{transform.position = value;}}

		public Vector2 scale{get{return transform.localScale;}set{transform.localScale = value;}}
		float speedmul;
		Vector2 movement;
		public Camera maincamera;
		public BoxCollider2D coll;
		public SpriteRenderer player_renderer;
		public Rigidbody2D m_RigidBody2D;

		Vector2 nowvelocity;

		// Use this for initialization
		void Awake () {
			//Initialize Module Linking
			coll = GetComponent<BoxCollider2D>(); 
			m_RigidBody2D=GetComponent<Rigidbody2D>();
			player_renderer = gameObject.GetComponent<SpriteRenderer>();
			speedmul = 10f;
		}

		// Update is called once per frame
		void Update () {
            movement = new Vector2(Input.GetAxis("Horizontal") * speedmul, 0);
           // movement = new Vector2(Input.acceleration.x * speedmul, 0);

			if (((facingleft && movement.x < 0) || (movement.x > 0 && !facingleft)) && hp != 0)
                flip();

            Camera.main.transform.position += new Vector3(0f, transform.position.y - Camera.main.transform.position.y, 0);
            //maincamera.transform.position += new Vector3(0f, transform.position.y - maincamera.transform.position.y, 0);

        }

        bool facingleft;
        void flip()
        {
            facingleft = !facingleft;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale=temp;
        }

		void FixedUpdate() {
			nowvelocity = m_RigidBody2D.velocity;
			if (isStunned) {
				//m_RigidBody2D.velocity = new Vector2(0f, 0f);
				//not_implemented
			}
			else {
				m_RigidBody2D.velocity= new Vector2(0f,GetComponent<Rigidbody2D> ().velocity.y);
				m_RigidBody2D.velocity+= movement;
			}
			f_timeleft += Time.fixedDeltaTime;
			timeleft = (int)f_timeleft;
			Debug.Log (Time.fixedDeltaTime);
            //if (nowvelocity.y > 0)
            //maincamera.transform.position += new Vector3 (0f, Mathf.Max(transform.position.y-maincamera.transform.position.y,0) ,0);
        }


    }
}