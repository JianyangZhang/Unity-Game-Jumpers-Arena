using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class SimpleShooter : MonoBehaviour {

        public Transform bulletcollection;
        public Object[] bullets;
        private List<Object> bulletlist;
        private float spacetime;
        public float fazhitime;
        public float speed;
        public float minAngle;
        public float maxAngle;
        public bool ShootEnable;

        // Use this for initialization
        void Start() {
            bulletlist = new List<Object>();
        }


        // Update is called once per frame
        void Update() {

            if (ShootEnable)
            { 

                float angle = Random.Range(minAngle, maxAngle);

                spacetime += Time.deltaTime;
                if (spacetime > fazhitime)
                {
                    bulletlist.Add(Instantiate(bullets[0], transform.position + new Vector3(0,0,0), Quaternion.identity, bulletcollection));
                    ((GameObject)bulletlist[bulletlist.Count - 1]).GetComponent<Bullet>().SetSpeed(new Vector2(Mathf.Cos(angle) * speed, -Mathf.Sin(angle) * speed));

                    spacetime = 0;
                }
            }

        }

        void ShootOnce(int bulletid,float angle)
        {
            bulletlist.Add(Instantiate(bullets[bulletid], transform.position + new Vector3(0, 0, 0), Quaternion.identity, bulletcollection));
            ((GameObject)bulletlist[bulletlist.Count - 1]).GetComponent<Bullet>().SetSpeed(new Vector2(Mathf.Cos(angle) * speed, -Mathf.Sin(angle) * speed));

        }
    }
}