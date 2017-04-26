using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class GameData
    {
        static GameData instance;

        public static GameData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameData();
                }
                return instance;
            }
        }
    }

    public class GameManager : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
