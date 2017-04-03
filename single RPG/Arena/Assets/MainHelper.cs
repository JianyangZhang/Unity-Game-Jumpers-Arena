using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Arena
{
    public class MainHelper : MonoBehaviour
    {

        public Player hero;
        public GameObject resultDialog;
        public GameObject middleGround;
        public GameObject temp_Result_Height;

        public FloorMapSetting currentStage;

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
            currentStage = new FloorMapSetting();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Gameover(int status)
        {
            resultDialog.active = true;
            middleGround.active = false;
            temp_Result_Height.GetComponent<Text>().text = hero.transform.position.y.ToString("f0");
        }
    }


    public class FloorMapSetting
    {
        public float maxheight = 220;
        public float width = 4;
        public floorBlockSetting[] blocks;

        public FloorMapSetting()
        {
            blocks = new floorBlockSetting[6];
            blocks[0] = new floorBlockSetting(0, 1, new float[3] { 0.5f, 1f, 1f }, 0, 1, 1, 0, new floorPlacing[1] { new floorPlacing(0, 0, 0) });
            blocks[1] = new floorBlockSetting(1, 30, new float[3] { 0.5f, 1f, 1f }, 2, 2, 3, 0, new floorPlacing[0]);
            blocks[2] = new floorBlockSetting(30, 60, new float[3] { 0.5f, 0.75f, 1f }, 2, 2, 4, 0, new floorPlacing[0]); //new floorPlacing[1] { new floorPlacing(0, 0, 0) });
            blocks[3] = new floorBlockSetting(60, 100, new float[3] { 0.25f, 0.75f, 1f }, 2, 2, 4, 0, new floorPlacing[0]);
            blocks[4] = new floorBlockSetting(100, 200, new float[3] { 0f, 1f, 1f }, 2, 3, 4, 0, new floorPlacing[1] { new floorPlacing(1, 0, 0) });
            blocks[5] = new floorBlockSetting(200, 220, new float[3] { 0f, 0.75f, 1f }, 0, 3, 4, 0, new floorPlacing[1] { new floorPlacing(1, 0, 0) });
        }
    }

    public struct floorBlockSetting
    {
        public float startpoint;
        public float endpoint;
        public float[] floorProb;
        public float quantityOfSlice;
        public float minSliceDuration;
        public float maxSliceDuration;
        public floorPlacing[] placingData;
        //public float sliceDurationAugment;

        public floorBlockSetting(float aa, float a, float[] b, float c, float d, float e, float f, floorPlacing[] g)
        {
            startpoint = aa;
            endpoint = a;
            floorProb = (float[])b.Clone();
            quantityOfSlice = c;
            minSliceDuration = d;
            maxSliceDuration = e;
            //sliceDurationAugment=f;
            placingData = (floorPlacing[])g.Clone();
        }
    }

    public struct floorPlacing
    {
        public int blockType;
        public float x;
        public float y;
        public floorPlacing(int a, float b, float c)
        {
            blockType = a;
            x = b;
            y = c;
        }

    }

}
