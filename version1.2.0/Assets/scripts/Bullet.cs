using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{

    public class Bullet : MonoBehaviour
    {
        public int damage;
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
                if (!player.buffStatus.IsShield)
                {
                    player.Hp -= damage;
                }
                Destroy(gameObject);
            }
            if (e.gameObject.tag.CompareTo("Shield") == 0)
            {
                
                Destroy(gameObject);
            }
            if (e.gameObject.tag.CompareTo("Filter") == 0)
            {

                Destroy(gameObject);
            }
        }

        public void SetSpeed(Vector2 target)
        {
            GetComponent<Rigidbody2D>().velocity = target;
        }
    }
}