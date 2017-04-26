using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class BasicBullet : MonoBehaviour
    {

        public int damage = 10;
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
            if (e.gameObject.tag.CompareTo("Player") == 0 && (e.gameObject.GetComponent<Player>().velocity.y < 0))
            {
                Onpu.print("Shooted");
                //speedplus += 2f;
                e.gameObject.GetComponent<Player>().Hp-=damage;
                Destroy(gameObject);
            }
        }
    }
}