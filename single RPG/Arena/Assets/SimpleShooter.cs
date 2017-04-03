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
        public Vector2 speed;

        // Use this for initialization
        void Start() {
            bulletlist = new List<Object>();
        }



        // Update is called once per frame
        void Update() {

            spacetime += Time.deltaTime;
            if (spacetime > fazhitime)
            {
                bulletlist.Add(Instantiate(bullets[0], transform.position + new Vector3(0, -0.1f, 0), Quaternion.identity, bulletcollection));
                ((GameObject)bulletlist[bulletlist.Count - 1]).GetComponent<Bullet>().SetSpeed(speed);

                spacetime = 0;
            }

        }
    }
}