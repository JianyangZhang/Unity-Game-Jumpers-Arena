using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{ 
    public class blooddisplay : MonoBehaviour {

        public Object target;
        
        IDamage idm;
        LineRenderer lren;
        public float length;
        public float thick;
        public Vector3 left, right;

        public Vector3[] temp_2vec;

	    // Use this for initialization
	    void Start () {
            lren = GetComponent<LineRenderer>();
            lren.startWidth = thick;
            lren.endWidth = thick;
            left = new Vector3(-length / 2, 0, 0);
            right = new Vector3(length / 2, 0, 0);

            idm = ((GameObject)target).GetComponent<IDamage>();
            //idm = ((GameObject)target).GetComponent<Player>();
            //if (idm==null) idm = ((GameObject)target).GetComponent<Enemy>();
        }
	
	    // Update is called once per frame
	    void Update ()
        {
            if ((idm == null)) return;
            if (!(idm is IDamage)) return;
            
            temp_2vec = new Vector3[2] { left, Vector3.Lerp(left, right, idm.Hp / (float)idm.MaxHp) };
            lren.numPositions = 2;
            lren.SetPositions(temp_2vec);
        }
    }
}