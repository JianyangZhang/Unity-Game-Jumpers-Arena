/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena { 
    public class BorderDetection : MonoBehaviour {

        public int direction=0;
        public float offset=0.05f;
        public Transform player;

	    // Use this for initialization
	    void Awake () {
	    }
	
	    // Update is called once per frame
	    void Update () {
        }
         
        private void OnTriggerEnter2D(Collider2D e)
        {
            /*if (e.gameObject.tag.CompareTo("Player") == 0)
            {
                Onpu.print("Kabe");
                e.gameObject.GetComponent<Player>().location += new Vector2(offset * direction, 0);
            }*/
/*        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class BorderDetection : MonoBehaviour
    {

        public int direction = 0;
        public float offset = 0.05f;
        public Transform player;
        private Transform origin_location;
        public Vector2 location { get { return transform.position; } set { transform.position = value; } }
        // Use this for initialization
        void Awake()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnTriggerEnter2D(Collider2D e)
        {
            if (e.gameObject.tag.CompareTo("Player") == 0)
            {
                //e.gameObject.GetComponent<Player> ().coll.isTrigger = false;
                //.gameObject.GetComponent<Player> ().coll.isTrigger = true;
                //  Onpu.print("Kabe");
                origin_location = player;
                e.gameObject.GetComponent<Transform>().position = new Vector3(origin_location.position.x * (-0.99f), origin_location.position.y, origin_location.position.z);

                //e.gameObject.GetComponent<Player>().location += new Vector2(offset * direction, 0);
            }
            if (e.gameObject.tag.CompareTo("MovingFloor") == 0)
            {
                Debug.Log("Detected");
                e.gameObject.GetComponent<Rigidbody2D>().velocity *= -1;
            }
        }
    }
}