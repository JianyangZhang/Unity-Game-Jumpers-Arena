using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena { 
    public class U_Path : MonoBehaviour {

        public MainHelper mh;
        public Transform PlayerTransform;
        GameObject playericon;

        public float playerstart,playerend;

        // Use this for initialization
        void Start () {
            //mh = GameObject.Find("MainHelper");
            playerstart = -108;
            playerend = 108;
            playericon = GameObject.Find("U_Path_Player_0");
	    }
	
	    // Update is called once per frame
	    void Update () {
            Vector3 v = playericon.transform.localPosition;
            v=new Vector3(v.x,(playerend - playerstart) * (PlayerTransform.position.y / mh.currentStage.maxheight) + playerstart,v.z);
            playericon.transform.localPosition = v;

        }
    }
}