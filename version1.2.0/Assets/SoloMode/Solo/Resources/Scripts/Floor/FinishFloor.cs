using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena { 
    public class FinishFloor : MonoBehaviour {

        MainHelper mh;

        private void Awake()
        {
            mh = GameObject.Find("MainHelper").GetComponent<MainHelper>();
        }

        // Use this for initialization
        void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {

        }

        void OnTriggerEnter2D(Collider2D e)
        {
            if (e.gameObject.tag.CompareTo("Player") == 0)
            {
                print ("finish");
                mh.Gameover(1);
            }
        }
    }

}