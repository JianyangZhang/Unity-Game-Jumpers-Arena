using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class bgscrolldata
    {
        public Vector3 multiplyer;
        public Vector3 beginHeight;
        public Vector3 endHeight; //Cancelled
        public Vector3 beginPosition;
        public GameObject gameObject;
        public string name;
        public bgscrolldata(string n, Vector3 m,Vector3 b,Vector3 e)
        {
            name = n;
            multiplyer = m;
            beginHeight = b;
            endHeight = e;
        }
    }

    public class bgscrolldataset
    {
        public bgscrolldata[] data = new bgscrolldata[6]
        {
            new bgscrolldata("bg_1_1",new Vector3(0,0.85f,0),new Vector3(0,0,0),new Vector3(0,20,0)),
            new bgscrolldata("bg_1_2",new Vector3(0,0.9f,0),new Vector3(0,0,0),new Vector3(0,200,0)),
            new bgscrolldata("bg_1_3",new Vector3(0,1f,0),new Vector3(0,0,0),new Vector3(0,300,0)),
            new bgscrolldata("bg_1_4_a",new Vector3(0,0.97f,0),new Vector3(0,0,0),new Vector3(0,300,0)),
            new bgscrolldata("bg_1_4_b",new Vector3(0,0.975f,0),new Vector3(0,0,0),new Vector3(0,300,0)),
            new bgscrolldata("bg_1_4_c",new Vector3(0,0.975f,0),new Vector3(0,0,0),new Vector3(0,300,0)),
        };
        public bool islinked=false;

        public bool link()
        {
            for(int i=0;i<data.Length;i++)
            {
                GameObject gm = GameObject.Find("BackGround/"+data[i].name);
                if (gm == null) return false;
                data[i].gameObject=gm;
            }
            return true;
        }
    }

    public class multiscroll : MonoBehaviour
    {

        Vector3 beginPosition;
        public Player hero;

        bgscrolldataset bgs=new bgscrolldataset();


        // Use this for initialization
        void Awake()
        {
            beginPosition = transform.position;
        }

        // Use this for initialization
        void Start()
        {
            bgs.link();
            foreach (bgscrolldata bgd in bgs.data)
            {
                bgd.beginPosition = bgd.gameObject.transform.position;
            }
            //hero = GameObject.Find("Hero").GetComponent<Player>();
        }

        // Update is called once per frame
        void Update()
        {
            if (hero == null) return;//Why?
            
            for (int i=0;i<bgs.data.Length;i++)
            {
                bgscrolldata current = bgs.data[i];
                Vector3 offset = current.endHeight - current.beginHeight;

                if (hero.transform.position.y < current.endHeight.y)
                    offset = Vector3.Scale(hero.transform.position - current.beginHeight, Vector2.one);

                offset.Scale(current.multiplyer);
                //Vector2.Scale(speed,direction) * Time.deltaTime;
                current.gameObject.transform.position = current.beginPosition + offset;
            }

        }
    }
}
