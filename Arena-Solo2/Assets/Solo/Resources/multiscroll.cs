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
        public Vector3 initialPosition;
        public Vector3 initialScale;
        public GameObject gameObject;


        public string name;
        public bgscrolldata(string n, Vector3 m,Vector3 b,Vector3 e,Vector3 f,Vector3 g)
        {
            name = n;
            multiplyer = m;
            beginHeight = b;
            endHeight = e;
            initialPosition = f;
            initialScale = g;
        }
    }

    public class bgscrolldataset
    {
        public bgscrolldata[] data = new bgscrolldata[20]
        {
            //new bgscrolldata("bg_1_1",new Vector3(0,0.85f,0),new Vector3(0,0,0),new Vector3(0,20,0),new Vector3(0,0,10),new Vector3(1,1,1)),
            //new bgscrolldata("bg_1_2",new Vector3(0,0.9f,0),new Vector3(0,0,0),new Vector3(0,200,0),new Vector3(0,0,20),new Vector3(1,1,1)),
            //new bgscrolldata("bg_1_3",new Vector3(0,1f,0),new Vector3(0,0,0),new Vector3(0,300,0),new Vector3(0,0,50),new Vector3(1,1,1)),
            //new bgscrolldata("bg_1_4",new Vector3(0,0.97f,0),new Vector3(0,0,0),new Vector3(0,300,0),new Vector3(0,0,30),new Vector3(1,1,1)),
            //new bgscrolldata("bg_1_4",new Vector3(0,0.975f,0),new Vector3(0,0,0),new Vector3(0,300,0),new Vector3(2.72f,-0.52f,40),new Vector3(0.85f,0.92f,1)),
            //new bgscrolldata("bg_1_4",new Vector3(0,0.975f,0),new Vector3(0,0,0),new Vector3(0,300,0),new Vector3(-1.73f,-1.04f,42),new Vector3(0.67f,0.92f,1)),
            new bgscrolldata("bg_grassfield",new Vector3(0,0.85f,0),new Vector3(0,0,0),new Vector3(0,200,0),new Vector3(0,12,10),new Vector3(1,1,1)),
            new bgscrolldata("bg_grassfield",new Vector3(0,0.825f,0),new Vector3(0,0,0),new Vector3(0,400,0),new Vector3(0,7.5f,9),new Vector3(1,1,1)),
            new bgscrolldata("bg_grassfield",new Vector3(0,0.80f,0),new Vector3(0,0,0),new Vector3(0,600,0),new Vector3(0,0,8),new Vector3(1,1,1)),
            new bgscrolldata("bg_treeslots",new Vector3(0,0.90f,0),new Vector3(0,0,0),new Vector3(0,200,0),new Vector3(0,10,20),new Vector3(1,1,1)),
            new bgscrolldata("bg_bluesky",new Vector3(0,1f,0),new Vector3(0,0,0),new Vector3(0,320,0),new Vector3(0,0,50),new Vector3(1,1,1)),
            new bgscrolldata("bg_mountain",new Vector3(0,0.945f,0),new Vector3(0,0,0),new Vector3(0,300,0),new Vector3(0,5,30),new Vector3(1,1,1)),
            new bgscrolldata("bg_mountain",new Vector3(0,0.955f,0),new Vector3(0,0,0),new Vector3(0,300,0),new Vector3(2.72f,3.52f,40),new Vector3(0.85f,0.92f,1)),
            new bgscrolldata("bg_volcano",new Vector3(0,0.955f,0),new Vector3(0,0,0),new Vector3(0,300,0),new Vector3(-1.73f,3.04f,42),new Vector3(0.67f,0.92f,1)),
            new bgscrolldata("bg_universefade",new Vector3(0,0.5f,0),new Vector3(0,240f,0),new Vector3(0,280,0),new Vector3(0f,15f,44),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_universeloop",new Vector3(0,1f,0),new Vector3(0,276f,0),new Vector3(0,1000,0),new Vector3(0f,0f,44),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_starry",new Vector3(0,0.8f,0),new Vector3(0,280,0),new Vector3(0,500,0),new Vector3(0f,10f,40),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_starry",new Vector3(0,0.7f,0),new Vector3(0,320,0),new Vector3(0,500,0),new Vector3(-0.5f,10f,39),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_starry",new Vector3(0,0.6f,0),new Vector3(0,360,0),new Vector3(0,500,0),new Vector3(0.5f,10f,38),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_starry",new Vector3(0,0.8f,0),new Vector3(0,380,0),new Vector3(0,1000,0),new Vector3(-0.5f,10f,40),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_starry",new Vector3(0,0.7f,0),new Vector3(0,420,0),new Vector3(0,1000,0),new Vector3(0.5f,10f,39),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_starry",new Vector3(0,0.6f,0),new Vector3(0,460,0),new Vector3(0,1000,0),new Vector3(0f,10f,38),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_starry",new Vector3(0,0.8f,0),new Vector3(0,480,0),new Vector3(0,1000,0),new Vector3(0.5f,10f,40),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_starry",new Vector3(0,0.7f,0),new Vector3(0,520,0),new Vector3(0,1000,0),new Vector3(0f,10f,39),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_starry",new Vector3(0,0.6f,0),new Vector3(0,560,0),new Vector3(0,1000,0),new Vector3(-0.5f,10f,38),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_2_2",new Vector3(0,1f,0),new Vector3(0,490,0),new Vector3(0,500,0),new Vector3(0f,10f,42),new Vector3(1f,1f,1)),
        };
        /*public bgscrolldata[] data = new bgscrolldata[10]
        {
            new bgscrolldata("bg_treeslots",new Vector3(0,0.90f,0),new Vector3(0,0,0),new Vector3(0,200,0),new Vector3(0,0,20),new Vector3(1,1,1)),
            new bgscrolldata("bg_bluesky",new Vector3(0,1f,0),new Vector3(0,0,0),new Vector3(0,35,0),new Vector3(0,0,50),new Vector3(1,1,1)),
            new bgscrolldata("bg_universefade",new Vector3(0,0.5f,0),new Vector3(0,0,0),new Vector3(0,300,0),new Vector3(0f,10f,42),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_universeloop",new Vector3(0,1f,0),new Vector3(0,25f,0),new Vector3(0,300,0),new Vector3(0f,0f,42),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_starry",new Vector3(0,0.8f,0),new Vector3(0,20,0),new Vector3(0,300,0),new Vector3(0f,10f,40),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_starry",new Vector3(0,0.7f,0),new Vector3(0,50,0),new Vector3(0,300,0),new Vector3(-0.5f,10f,39),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_starry",new Vector3(0,0.6f,0),new Vector3(0,80,0),new Vector3(0,300,0),new Vector3(0.5f,10f,38),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_starry",new Vector3(0,0.8f,0),new Vector3(0,100,0),new Vector3(0,300,0),new Vector3(-0.5f,10f,40),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_starry",new Vector3(0,0.7f,0),new Vector3(0,130,0),new Vector3(0,300,0),new Vector3(0f,10f,39),new Vector3(1f,1f,1)),
            new bgscrolldata("bg_starry",new Vector3(0,0.6f,0),new Vector3(0,160,0),new Vector3(0,300,0),new Vector3(0.5f,10f,38),new Vector3(1f,1f,1)),
        };*/
        public bool islinked=false;

        public bool link() //May removed
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

        

        public Object bgproto;
        Transform bgparent;

        bgscrolldataset bgs=new bgscrolldataset();


        // Use this for initialization
        void Awake()
        {
            beginPosition = transform.position;
        }

        // Use this for initialization
        void Start()
        {

            bgparent = GameObject.Find("BackGround").transform;
            //Intitiate of BG
            bgs.link();
            for (int i = 0; i < bgs.data.Length; i++)
            {
                GameObject gm2 = (GameObject)Instantiate<Object>(bgproto,bgs.data[i].initialPosition+bgparent.position, Quaternion.identity,bgparent);
                gm2.name = bgs.data[i].name;
                gm2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image_Beta/bg_101/"+bgs.data[i].name);
                gm2.transform.localScale = bgs.data[i].initialScale;
                //GameObject gm = GameObject.Find("BackGround/" + bgs.data[i].name);
                bgs.data[i].gameObject = gm2;
            }



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

                if (MainHelper.Instance.CurrentCamera.transform.position.y < current.endHeight.y)
                    offset = Vector3.Scale(MainHelper.Instance.CurrentCamera.transform.position - current.beginHeight, Vector2.one);
                
                offset.Scale(current.multiplyer);
                //Vector2.Scale(speed,direction) * Time.deltaTime;

                //Temporarily deal with beginheight
                if (MainHelper.Instance.CurrentCamera.transform.position.y < current.beginHeight.y) offset += new Vector3(450, 0, 0);

                current.gameObject.transform.position = current.beginPosition + offset+ current.beginHeight;
            }

        }
    }
}
