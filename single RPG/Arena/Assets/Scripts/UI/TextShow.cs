using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Arena
{
    public class TextShow : MonoBehaviour
    {
        public MainHelper mh;
        Text t_hp,t_height,t_time,t_debug;

        // Use this for initialization
        void Start()
        {
            t_hp=GameObject.Find("T_Hp").GetComponent<Text>();
            t_height = GameObject.Find("T_Height").GetComponent<Text>();
            t_time = GameObject.Find("T_Timeleft").GetComponent<Text>();
            t_debug = GameObject.Find("T_Debug").GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            t_hp.text = mh.hp.ToString();
            t_height.text = mh.height.ToString();
            t_time.text = "99";
            t_debug.text = "Acc.X: "+Input.acceleration.x+"\nAcc.Y: "+Input.acceleration.y+"\nAcc.Z: "+Input.acceleration.z+"\n";
        }

        public void Resetbutton()
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }
}