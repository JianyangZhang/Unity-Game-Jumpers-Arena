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
        Text t_score,t_height,t_time,t_debug;

        // Use this for initialization
        void Start()
        {
            t_score=GameObject.Find("T_Score").GetComponent<Text>();
            //t_height = GameObject.Find("T_Height").GetComponent<Text>();
            t_time = GameObject.Find("T_Timeleft").GetComponent<Text>();
            //t_debug = GameObject.Find("T_Debug").GetComponent<Text>();
            Input.simulateMouseWithTouches = true;
        }

        // Update is called once per frame
        void Update()
        {
            t_score.text = mh.score.ToString();
            //t_height.text = mh.height.ToString();
            t_time.text = ((int)mh.time).ToString();
            //t_debug.text = "Acc.X: "+Input.acceleration.x+"\nAcc.Y: "+Input.acceleration.y+"\nAcc.Z: "+Input.acceleration.z+"\n";
            //t_debug.text = Input.touchCount.ToString();


            //for (int i=0;i< Input.touches.Length;i++)
            //    t_debug.text += "Tou.X: " + Input.touches[i].position.x+ "\nTou.Y: " + Input.touches[i].position.y+"\n";

        }

        public void Resetbutton()
        {
            SceneManager.LoadScene("run_solo");
        }

		public void Quitbutton()
		{
			SceneManager.LoadScene("MainMenu");
		}
    }
}