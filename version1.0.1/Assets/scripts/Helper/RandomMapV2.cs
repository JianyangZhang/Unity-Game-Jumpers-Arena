using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomMapV2 : MonoBehaviour {

    //public Object[] prefabs;
    //const int maxprefabs = 2;

    public class FloorMapSetting {
        public float maxheight = 300;
        public float width = 4;
        public floorBlockSetting[] blocks;

        public FloorMapSetting() {
            blocks = new floorBlockSetting[6];
            blocks[0] = new floorBlockSetting(0, 1, new float[3] { 0.5f, 1f, 1f }, 0, 1, 1, 0, new floorPlacing[1] { new floorPlacing(0, 0, 0) });
            blocks[1] = new floorBlockSetting(1, 20, new float[3] { 0.5f, 1f, 1f }, 2, 2, 3, 0, new floorPlacing[0]);
            blocks[2] = new floorBlockSetting(20, 40, new float[3] { 0.5f, 0.75f, 1f }, 2, 2, 4, 0, new floorPlacing[1] { new floorPlacing(0, 0, 0) });
            blocks[3] = new floorBlockSetting(40, 60, new float[3] { 0.25f, 0.75f, 1f }, 2, 2, 4, 0, new floorPlacing[1] { new floorPlacing(1, 0, 0) });
            blocks[4] = new floorBlockSetting(60, 80, new float[3] { 0f, 1f, 1f }, 2, 3, 4, 0, new floorPlacing[1] { new floorPlacing(0, 0, 0) });
            blocks[5] = new floorBlockSetting(80, 300, new float[3] { 0f, 0.75f, 1f }, 1, 3, 4, 0, new floorPlacing[1] { new floorPlacing(0, 0, 0) });
        }
    }

    public struct floorBlockSetting {
        public float startpoint;
        public float endpoint;
        public float[] floorProb;
        public float quantityOfSlice;
        public float minSliceDuration;
        public float maxSliceDuration;
        public floorPlacing[] placingData;
        //public float sliceDurationAugment;

        public floorBlockSetting(float aa, float a, float[] b, float c, float d, float e, float f, floorPlacing[] g) {
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

    public struct floorPlacing {
        public int blockType;
        public float x;
        public float y;
        public floorPlacing(int a, float b, float c) {
            blockType = a;
            x = b;
            y = c;
        }

    }

    public Transform floorcollection;
    public Object[] prefabsfloors;
    public Object[] specprefabsfloors;

    List<Object> floorlist;

    // Use this for initialization
    void Start() {
        Random.InitState(1234567);
        FloorMapSetting fms = new FloorMapSetting();
        float currentheight = 0;
        floorlist = new List<Object>();
        floorlist.Add(Instantiate(prefabsfloors[0], new Vector3(0, -2, -5), Quaternion.identity, floorcollection));
        int pBlock = 0;
        while (currentheight < fms.maxheight) {

            if (currentheight < fms.blocks[pBlock].startpoint)
                currentheight = fms.blocks[pBlock].startpoint;

            for (int iMust = 0; iMust < fms.blocks[pBlock].placingData.Length; iMust++) {
                floorlist.Add(
                    Instantiate(
                        specprefabsfloors[fms.blocks[pBlock].placingData[iMust].blockType], new Vector3(
                            fms.blocks[pBlock].placingData[iMust].x,
                            fms.blocks[pBlock].startpoint + fms.blocks[pBlock].placingData[iMust].y,
                            -5),
                        Quaternion.identity,
                        floorcollection
                    )
                );

            }

            while (currentheight > fms.blocks[pBlock].endpoint) pBlock += 1;
            
            for (int iSlice = 0; iSlice < fms.blocks[pBlock].quantityOfSlice; iSlice++) {
                float dice = Random.Range(0f, 1f);
                int rtype = 0;
                while (rtype < prefabsfloors.Length - 1 && dice > fms.blocks[pBlock].floorProb[rtype])
                    rtype++;

                if (rtype < prefabsfloors.Length)
                    floorlist.Add(
                        Instantiate(
                            prefabsfloors[rtype], new Vector3(
                                Random.Range(-fms.width, fms.width),
                                currentheight + (iSlice != 0 ? Random.Range(0, fms.blocks[pBlock].minSliceDuration) : 0),
                                -5),
                            Quaternion.identity,
                            floorcollection
                        )
                    );
            }
            currentheight += Random.Range(fms.blocks[pBlock].minSliceDuration, fms.blocks[pBlock].maxSliceDuration);
        }
    }

    // Update is called once per frame
    void Update() {

    }
}

