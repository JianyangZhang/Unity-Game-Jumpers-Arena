using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Arena
{
    /*public class powerupRequest
    {
        public int targetType;
        public string name;
        public float value;
        public float time;
    }

    public class powerupType
    {
        public string sid;
        public Sprite basicPic;
        public List<powerupRequest> powerupRequest;
        public powerupType(string sidto,Sprite texture)
        {
            sid = sidto;
            basicPic = texture;
        }
        public powerupType AddPowerupRequest(int a,string b,float c,float d)
        {
            powerupRequest e = new powerupRequest();
            e.targetType = a;
            e.name = b;
            e.value = c;
            e.time = d;
            return this;
        }
    }*/

    public class SimplePowerup : MonoBehaviour
    {
        //public static List<powerupType> powerupList=null;

        public int BuffType;

        // Use this for initialization
        void Start()
        {
            //Initialize Poweruplist
            /*if (powerupList==null)
            {
                powerupList = new List<powerupType>();

                powerupType pw;
                pw = new powerupType("none", Resources.Load<Sprite>("Images/powerups/speedup"));
                powerupList.Add(pw);
                pw = new powerupType("speedup", Resources.Load<Sprite>("Images/powerups/speedup"));
                pw.AddPowerupRequest(0, "JumpMul", 1.5f, 10f);
                powerupList.Add(pw);
                pw = new powerupType("speeddown", Resources.Load<Sprite>("Images/powerups/speeddown"));
                pw.AddPowerupRequest(0, "JumpMul", 0.75f, 10f);
                powerupList.Add(pw);
            }*/
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D e)
        {
            /*if (e.gameObject.tag.CompareTo("Player") == 0)
            {
                //Buff Here
                Destroy(gameObject);
            }*/
            /*if (e.gameObject.tag.CompareTo("Shield") == 0)
            {
                Destroy(gameObject);
            }*/
        }
    }
}
