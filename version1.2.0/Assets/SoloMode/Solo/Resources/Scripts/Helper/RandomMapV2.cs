using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Arena
{


    public class FloorMapSetting
    {
        public float maxheight = 550;
        public float width = 2;
        public floorBlockSetting[] blocks;

        public FloorMapSetting()
        {
            blocks = new floorBlockSetting[9];
            blocks[0] = new floorBlockSetting(0, 15, 0, 1, 1, 0, new floorPlacing[15] {
                new floorPlacing(0, 0, 0), new floorPlacing(2, 0, 1.25f), new floorPlacing(2, 0, 2.5f),
                new floorPlacing(2, 0, 3.75f), new floorPlacing(2, 0, 5f), new floorPlacing(2, 0, 6.25f),
                new floorPlacing(2, 0, 7.5f),
                new floorPlacing(2, -1, 8.75f),new floorPlacing(2, 1, 8.75f),new floorPlacing(2, -2, 10f),
                new floorPlacing(2, 0, 10f),new floorPlacing(2, 2, 10f),new floorPlacing(2, -1, 11.67f),
                new floorPlacing(2, 1, 11.67f),new floorPlacing(2, 0, 13.33f)});
            blocks[0].powerupsPlacingData = new floorPlacing[1] {
                new floorPlacing(0, 0, 10.5f)};
            blocks[0].powerupsPrec = 0f;


            blocks[1] = new floorBlockSetting(16, 140, 2, 2, 4, 0, new floorPlacing[0]);
            blocks[1].randomPowerupsProbData = new int[8] { 0, 1, 2, 3, 3, 4, 4, 5 };
            blocks[1].randomFloorsProbData = new int[2] { 0, 1 };
            blocks[1].powerupsPrec = 0.33f;

            blocks[2] = new floorBlockSetting(141, 200, 2, 2, 4, 0, new floorPlacing[0]);
            blocks[2].randomPowerupsProbData = new int[8] { 0, 1, 2, 3, 3, 4, 4, 4 };
            blocks[2].randomFloorsProbData = new int[4] { 0, 0, 1, 2 };
            blocks[2].powerupsPrec = 0.33f;

            blocks[3] = new floorBlockSetting(201, 250, 0, 1, 1, 0, new floorPlacing[1] { new floorPlacing(0, 0, 0) });
            blocks[3].powerupsPlacingData = new floorPlacing[4] {
                new floorPlacing(1, 0, 1f), new floorPlacing(3, 0, 0), new floorPlacing(4, 0, 10f), new floorPlacing(2, 0, 12f) };
            blocks[3].randomPowerupsProbData = new int[10] { 4, 4, 4, 4, 3, 3, 3, 3, 2, 0 };
            blocks[3].randomFloorsProbData = new int[1] { 1 };
            blocks[3].powerupsPrec = 0.67f;

            blocks[4] = new floorBlockSetting(251, 400, 2, 3, 4, 0, new floorPlacing[0]);
            blocks[4].randomPowerupsProbData = new int[10] { 4, 4, 4, 4, 3, 3, 3, 3, 2, 0 };
            blocks[4].randomFloorsProbData = new int[1] { 1 };
            blocks[4].powerupsPrec = 0.67f;

            blocks[5] = new floorBlockSetting(401, 433, 2, 3, 4, 0, new floorPlacing[1] { new floorPlacing(3, 0, 0) });
            blocks[5].powerupsPlacingData = new floorPlacing[1] { new floorPlacing(5, 0, 1f) };
            blocks[5].randomPowerupsProbData = new int[8] { 0, 1, 2, 2, 4, 4, 4, 4 };
            blocks[5].randomFloorsProbData = new int[4] { 1, 1, 2, 2 };
            blocks[5].powerupsPrec = 0.2f;

            blocks[6] = new floorBlockSetting(434, 450, 0, 1, 1, 0, new floorPlacing[11] {
                new floorPlacing(2, -2, 0f), new floorPlacing(2, -1.2f, 0f),
                new floorPlacing(2, -1.2f, 2.5f), new floorPlacing(2, -0.4f, 2.5f), new floorPlacing(2, -0.4f, 5f),
                new floorPlacing(2, 0.4f, 5f),
                new floorPlacing(2, 0.4f, 7.5f),new floorPlacing(2, 1.2f, 7.5f),new floorPlacing(2, 1.2f, 10f),
                new floorPlacing(2, 2, 10f),new floorPlacing(2, 0, 12.5f),});
            blocks[6].powerupsPlacingData = new floorPlacing[1] { new floorPlacing(5, 0, 1f) };
            blocks[6].randomPowerupsProbData = new int[8] { 0, 1, 2, 2, 4, 4, 4, 4 };
            blocks[6].randomFloorsProbData = new int[4] { 0, 1, 1, 2 };
            blocks[6].powerupsPrec = 0.2f;

            blocks[7] = new floorBlockSetting(451, 500, 2, 2, 3, 0, new floorPlacing[8] {
                new floorPlacing(3, 0, 0),new floorPlacing(3, 0, 10),new floorPlacing(3, 0, 20),
            new floorPlacing(3, 0, 30),new floorPlacing(3, 0, 40),new floorPlacing(3, 0, 44),new floorPlacing(3, 0, 48),new floorPlacing(3, 0, 52),});
            blocks[7].randomPowerupsProbData = new int[8] { 0, 1, 2, 2, 4, 4, 4, 4 };
            blocks[7].randomFloorsProbData = new int[3] { 1, 2, 2 };
            blocks[7].powerupsPrec = 0.2f;

            blocks[8] = new floorBlockSetting(501, 800, 0, 3, 4, 0, new floorPlacing[2] { new floorPlacing(3, 0, 4), new floorPlacing(2, 0, 9) });
            blocks[8].powerupsPlacingData = new floorPlacing[2] {
                new floorPlacing(3, 0, 5f), new floorPlacing(7, 0, 9.5f) };
            blocks[8].powerupsPrec = 0.2f;

        }
    }

    public struct floorBlockSetting
    {
        public float startpoint;
        public float endpoint;
        //public float[] floorProb;//DEP?
        public float quantityOfSlice;
        public float minSliceDuration;
        public float maxSliceDuration;
        public floorPlacing[] placingData;
        public floorPlacing[] powerupsPlacingData;
        public int[] randomFloorsProbData;
        public int[] randomPowerupsProbData;
        public float powerupsPrec;
        //public float sliceDurationAugment;

        public floorBlockSetting(float aa, float a, /*float[] b, */float c, float d, float e, float f, floorPlacing[] g)
        {
            startpoint = aa;
            endpoint = a;
            //floorProb = (float[])b.Clone();
            quantityOfSlice = c;
            minSliceDuration = d;
            maxSliceDuration = e;
            //sliceDurationAugment=f;
            placingData = (floorPlacing[])g.Clone();
            powerupsPlacingData = new floorPlacing[0];
            randomFloorsProbData = new int[0];
            randomPowerupsProbData = new int[0];
            powerupsPrec = 0.1f;
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

    public class RandomMapV2 : MonoBehaviour
    {

        //public Object[] prefabs;
        //const int maxprefabs = 2;

        const float shownOffset = 15f;

        public MainHelper mh;
        public Transform floorcollection;
        public Object[] prefabsfloors;
        public Object[] specprefabsfloors;
        FloorMapSetting fms;

        public Object[] prefabspowerups;
        public Object[] specprefabspowerups;
        //float powerupsperc = 0.5f;

        float builtheight;
        float shownheight;
        int pBlock;


        List<Object> floorlist;

        // Use this for initialization
        void Start()
        {

            //Load Floor map settings
            fms = new FloorMapSetting();

            builtheight = 0;
            shownheight = /*GameObject.Find("Hero").transform.position.z*/0 + shownOffset;

            floorlist = new List<Object>();
            floorlist.Add(Instantiate(prefabsfloors[0], new Vector3(0, -2, -5), Quaternion.identity, floorcollection));
            pBlock = 0;
        }

        // Update is called once per frame
        void Update()
        {


            float adds = GameObject.Find("Hero").transform.position.y + shownOffset;
            if (shownheight < adds) shownheight = adds;



            while (builtheight < shownheight)
            {

                //Break to avoid out range of blocks
                if (pBlock >= fms.blocks.Length) break;

                if (builtheight == 0 || builtheight > fms.blocks[pBlock].endpoint)  //builtheight==0 will be replaced
                {

                    //Move to next Block
                    while (builtheight > fms.blocks[pBlock].endpoint) pBlock += 1;

                    //Break to avoid out range of blocks
                    if (pBlock >= fms.blocks.Length) break;

                    //Move builtheight
                    if (builtheight < fms.blocks[pBlock].startpoint)
                        builtheight = fms.blocks[pBlock].startpoint;

                    //generate placing Block?
                    for (int iMust = 0; iMust < fms.blocks[pBlock].placingData.Length; iMust++)
                    {
                        floorlist.Add(
                            Instantiate(
                                specprefabsfloors[fms.blocks[pBlock].placingData[iMust].blockType], new Vector3(
                                    fms.blocks[pBlock].placingData[iMust].x,
                                    fms.blocks[pBlock].startpoint + fms.blocks[pBlock].placingData[iMust].y,
                                    100),
                                Quaternion.identity,
                                floorcollection
                            )
                        );
                    }

                    //generate placing powerups
                    for (int iMust = 0; iMust < fms.blocks[pBlock].powerupsPlacingData.Length; iMust++)
                    {
                        floorlist.Add(
                            Instantiate(
                                specprefabspowerups[fms.blocks[pBlock].powerupsPlacingData[iMust].blockType], new Vector3(
                                    fms.blocks[pBlock].powerupsPlacingData[iMust].x,
                                    fms.blocks[pBlock].startpoint + fms.blocks[pBlock].powerupsPlacingData[iMust].y,
                                    100),
                                Quaternion.identity,
                                floorcollection
                            )
                        );
                    }
                }

                while (builtheight <= fms.blocks[pBlock].endpoint && builtheight < shownheight)
                {
                    for (int iSlice = 0; iSlice < fms.blocks[pBlock].quantityOfSlice; iSlice++)
                    {
                        if (fms.blocks[pBlock].randomFloorsProbData.Length > 0/* rtype < prefabsfloors.Length*/)
                        {
                            int dice = Random.Range(0, fms.blocks[pBlock].randomFloorsProbData.Length);
                            Object target = Instantiate(
                                prefabsfloors[fms.blocks[pBlock].randomFloorsProbData[dice]],
                                new Vector3(
                                    Random.Range(-fms.width, fms.width),
                                    builtheight + (iSlice != 0 ? Random.Range(0, fms.blocks[pBlock].minSliceDuration) : 0),
                                    100),
                                Quaternion.identity,
                                floorcollection
                            );
                            //Random Powerups
                            //Flash Floors Powerups Will Be Fixed
                            if (fms.blocks[pBlock].randomPowerupsProbData.Length > 0 && Random.Range(0f, 0.999f) < fms.blocks[pBlock].powerupsPrec)
                            {
                                if (dice < 2) Instantiate(
                                    /*prefabspowerups[Random.Range(0,prefabspowerups.Length)]*/
                                    prefabspowerups[fms.blocks[pBlock].randomPowerupsProbData[Random.Range(0, fms.blocks[pBlock].randomPowerupsProbData.Length)]],
                                    ((GameObject)target).transform.position + new Vector3(0, 0.5f, 0),
                                    Quaternion.identity, ((GameObject)target).transform);
                            }
                            floorlist.Add(target);
                        }
                    }
                    builtheight += Random.Range(fms.blocks[pBlock].minSliceDuration, fms.blocks[pBlock].maxSliceDuration);
                }


            }
        }
    }

}