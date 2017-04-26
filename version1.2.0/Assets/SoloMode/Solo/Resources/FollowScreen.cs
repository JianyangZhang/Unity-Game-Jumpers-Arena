using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class FollowScreen : MonoBehaviour
    {
        public Vector3 Offset;
        //public GameObject Player;
        private GameObject player;
        private Transform playertransform;
        private Player playerscript;
        private Transform cameratransform;
        public bool FollowPlayer;

        // Use this for initialization
        void Start()
        {
            player = GameObject.Find("Hero");
            playertransform = player.GetComponent<Transform>();
            playerscript = player.GetComponent<Player>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            cameratransform = MainHelper.Instance.CurrentCamera.transform;
            if (FollowPlayer) transform.position = Vector2.Scale(playertransform.position, new Vector2(0, 1))
               + Vector2.Scale(transform.position, new Vector2(1, 0));
            else transform.position = Vector2.Scale(cameratransform.position, new Vector2(0, 1))
               + Vector2.Scale(transform.position, new Vector2(1, 0));
            transform.position += playerscript.ScreenOffset;
            transform.position += Offset;
        }
    }
}