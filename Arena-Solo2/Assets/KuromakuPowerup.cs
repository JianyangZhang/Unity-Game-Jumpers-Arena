using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{

    public class KuromakuPowerup : MonoBehaviour
    {

        public float time;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter2D(Collider2D e)
        {
            if (e.gameObject.tag.CompareTo("Player") == 0)
            {
                MainHelper.Instance.Kuromaku(5);
                Destroy(gameObject);
            }
        }
    }
}