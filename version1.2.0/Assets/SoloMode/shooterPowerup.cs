using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class shooterPowerup : MonoBehaviour
    {
        public float time;
        public float value;
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
                Player player = e.GetComponent<Player>();
                player.AddBuff("Shooter", value, time);
                Destroy(gameObject);
            }
        }
    }
}