using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class GameoverPowerup : MonoBehaviour
    {
        bool once;
        // Use this for initialization
        void Start()
        {
            once = true;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        void OnTriggerEnter2D(Collider2D e)
        {
            if (once && e.gameObject.tag.CompareTo("Player") == 0)
            {
                Player player = e.GetComponent<Player>();

                MainHelper.Instance.Gameover(1);
                once = false;
            }
        }
    }
}