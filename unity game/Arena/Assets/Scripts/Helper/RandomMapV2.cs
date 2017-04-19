using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Arena.Helper{

	public class RandomMapV2 : MonoBehaviour {

        //public Object[] prefabs;
        //const int maxprefabs = 2;

        public MainHelper mh;
		public Transform floorcollection;
		public Object[] prefabsfloors;
		public Object[] specprefabsfloors;
        FloorMapSetting fms;


        List<Object> floorlist;

		// Use this for initialization
		void Start () {

            FloorMapSetting fms = new FloorMapSetting ();
            //FloorMapSetting fms = mh.currentStage;

			float currentheight = 0;
			floorlist = new List<Object> ();
			//floorlist.Add (Instantiate (prefabsfloors [0], new Vector3 (0, 6, -5), Quaternion.identity, floorcollection));
			int pBlock=0;
			while (currentheight < fms.maxheight) {
				
				if (currentheight < fms.blocks [pBlock].startpoint)
					currentheight = fms.blocks [pBlock].startpoint;
				for (int iMust = 0; iMust < fms.blocks [pBlock].placingData.Length; iMust++) {
					floorlist.Add (
						Instantiate (
							specprefabsfloors [fms.blocks[pBlock].placingData[iMust].blockType], new Vector3 (
								fms.blocks[pBlock].placingData[iMust].x , 
								fms.blocks[pBlock].startpoint+fms.blocks[pBlock].placingData[iMust].y ,
								-5),
							Quaternion.identity,
							floorcollection
						)
					);

				}

				while (currentheight>fms.blocks[pBlock].endpoint) pBlock+=1;

				for (int iSlice = 0; iSlice < fms.blocks [pBlock].quantityOfSlice; iSlice++){
					float dice = Random.Range (0f, 1f);
					int rtype = 0;
					while (rtype < prefabsfloors.Length - 1 && dice > fms.blocks [pBlock].floorProb [rtype])
						rtype++;

					if (rtype<prefabsfloors.Length)
						floorlist.Add (
							Instantiate (
								prefabsfloors [rtype], new Vector3 (
									Random.Range(-fms.width + 2, fms.width -2), 
									currentheight+(iSlice!=0?Random.Range(0,fms.blocks [pBlock].minSliceDuration):0),
									-5),
								Quaternion.identity,
								floorcollection
							)
						);
				}
				currentheight += Random.Range (fms.blocks [pBlock].minSliceDuration, fms.blocks [pBlock].maxSliceDuration);
			}
		}

		// Update is called once per frame
		void Update () {

		}
	}

}