using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour {

	//public Object[] prefabs;
	//const int maxprefabs = 2;

	public Transform floorcollection;
	public Object[] prefabsfloors;

	Object[] floors;
	const int maxfloors = 10;
	const int maxlevels = 10;

	// Use this for initialization
	void Start () {
		
		floors = new Object[maxfloors*maxlevels];
		for (int j=0;j<maxlevels;j++)
			for (int i=0;i<maxfloors;i++){
				floors[i+j*maxfloors] = Instantiate(prefabsfloors[Random.Range(0,prefabsfloors.Length)], new Vector3(Random.Range(-50,50)/10f,Random.Range(-50,50)/10f+j*10f,-5),Quaternion.identity,floorcollection);
			}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
