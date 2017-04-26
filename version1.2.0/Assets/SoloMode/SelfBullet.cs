using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{

    public class SelfBullet : Bullet
    {
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
            if (e.gameObject.tag.CompareTo("Enemy") == 0)
            {
                IDamage enemy = e.GetComponent<IDamage>();
                if (!enemy.IsIDamageWork)
                {
                    enemy.Hp -= damage;
                }
                Destroy(gameObject);
            }
            if (e.gameObject.tag.CompareTo("Filter") == 0)
            {
                
                Destroy(gameObject);
            }
        }
    }
}