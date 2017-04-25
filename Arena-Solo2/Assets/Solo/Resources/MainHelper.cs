using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Arena
{
    public class MainHelper : MonoBehaviour
    {
        static MainHelper _instance;

        bool isGameOver;

        void Awake()
        {
            _instance = this;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        public static MainHelper Instance
        {
            get
            {
                return _instance;
            }
        }

        Player hero;
        GameObject resultDialog;
        GameObject middleGround;
        GameObject temp_Result_Enemy, temp_Result_Score, temp_Result_Time, temp_Result_Final;
        
        float nextLockHeight;

        int currentCamera;
        GameObject[] cameraArray;
        bool followstatus;

        public GameObject CurrentCamera
        {
            get { return cameraArray[currentCamera]; }
        }

        public GameObject FollowCamera
        {
            get { return cameraArray[1]; }
        }

        void setCurrentCamera(int tar)
        {
            for (int i = 0; i < cameraArray.Length; i++)
                if (i == tar) cameraArray[i].SetActive(true); else cameraArray[i].SetActive(false);
        }

        public void SetCameraFollow(bool yn)
        {
            if (cameraArray == null) return;
            switch (yn)
            {
                case true:
                    followstatus = true;
                    setCurrentCamera(1);
                    break;
                case false:
                    //followstatus = false;
                    //setCurrentCamera(0);
                    nextLockHeight = hero.transform.position.y+5;
                    break;
                default:
                    break;
            }
        }

        public FloorMapSetting currentStage;

        public float hp
        {
            get{ return (hero != null) ? hero.Hp : -1; }
        }

        public float height
        {
            get { return (hero != null) ? hero.transform.position.y : -1; }
        }

        public float coin
        {
            get;set;
        }

        public int enemykilled
        {
            get; set;
        }

        public float score
        {
            get; set;
        }

        public float time
        {
            get; set;
        }

        // Use this for initialization
        void Start()
        {
            currentStage = new FloorMapSetting();
            hero = GameObject.Find("Hero").GetComponent<Player>();
            resultDialog = GameObject.Find("Result");
            temp_Result_Score = GameObject.Find("T_Result_Score");
            temp_Result_Enemy = GameObject.Find("T_Result_Enemy");
            temp_Result_Time = GameObject.Find("T_Result_Time");
            temp_Result_Final = GameObject.Find("T_Result_Final");
            resultDialog.SetActive(false);
            middleGround = GameObject.Find("MiddleGround");

            cameraArray = new GameObject[3];
            cameraArray[0] = GameObject.Find("CameraLock");
            cameraArray[1] = GameObject.Find("CameraFollow");
            cameraArray[2] = GameObject.Find("CameraTween");
            SetCameraFollow(true);

            currentCamera = 1;

            nextLockHeight = -1;

            time = 300;

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!isGameOver) time -= Time.deltaTime;

            //NextLock
            if (nextLockHeight!=-1&&nextLockHeight<hero.transform.position.y)
            {
                followstatus = false;
                setCurrentCamera(0);
                nextLockHeight = -1;
            }

            //camera
            //cameraArray[1].transform.position = Vector2.Scale(hero.transform.position, new Vector2(0, 1))
            //   + Vector2.Scale(transform.position, new Vector2(1, 0));

            //Camera Lock follow with Camera Follow
            if (followstatus)
            {
                cameraArray[0].transform.position = cameraArray[1].transform.position;
            }

        }

        void Update()
        {

            //kuromaku
            if (kuromakutimeleft > 0)
            {
                kuromakutimeleft -= Time.deltaTime;
                kuromakutransform.localPosition = new Vector3(0,
                    ((GameObject)CurrentCamera).transform.position.y + 24 * (kuromakutimefull - kuromakutimeleft) - 12,
                    kuromakutransform.position.z);
            }
        }

        public void Kuromaku(float time)
        {
            kuromakutimefull = time;
            kuromakutimeleft = time;
            if (kuromakutransform == null) kuromakutransform = GameObject.Find("kuromaku").GetComponent<Transform>();
        }

        float kuromakutimeleft;
        float kuromakutimefull;
        Transform kuromakutransform;

        public void Gameover(int status)
        {
            float finalscore = score + enemykilled+ time;
            if (status == 0)
            {
                finalscore -= time;
                time = 0;
            }
            resultDialog.SetActive(true);
            isGameOver = true;
            //middleGround.SetActive(false);
            //temp_Result_Height.GetComponent<Text>().text = hero.transform.position.y.ToString("f0");
            temp_Result_Score.GetComponent<Text>().text = score.ToString("f0");
            temp_Result_Enemy.GetComponent<Text>().text = enemykilled.ToString("f0");
            temp_Result_Time.GetComponent<Text>().text = time.ToString("f0");
            temp_Result_Final.GetComponent<Text>().text = finalscore.ToString("f0");
        }
    }



}
