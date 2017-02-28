using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class MainHelper : MonoBehaviour
    {

        public Player hero;
        public GameObject resultDialog;
        public GameObject middleGround;

        public float hp
        {
            get{ return (hero != null) ? hero.hp : -1; }
        }

        public float height
        {
            get { return (hero != null) ? hero.transform.position.y : -1; }
        }

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Gameover(int status)
        {
            resultDialog.active = true;
            middleGround.active = false;
        }
    }
}
