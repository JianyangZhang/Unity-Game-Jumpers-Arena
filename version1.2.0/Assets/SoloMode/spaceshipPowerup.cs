using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class spaceshipPowerup : MonoBehaviour
    {
        public float time;
        public bool activate;
        //public float value;
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
                player.SetMorphoType(activate?1:0, time);
                //MainHelper.Instance.SetCameraFollow(false);
                Destroy(gameObject);
            }
        }
    }
}