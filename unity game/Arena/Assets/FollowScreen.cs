using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class FollowScreen : MonoBehaviour
    {

        public Transform Player;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector2.Scale(Player.transform.position, new Vector2(0, 1))
               + Vector2.Scale(transform.position, new Vector2(1, 0));
        }
    }
}