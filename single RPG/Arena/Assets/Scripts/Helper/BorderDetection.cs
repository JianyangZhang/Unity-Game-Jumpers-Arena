using System.Collections;
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
        }
    }
}