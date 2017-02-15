using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public Camera cam;
    public GameObject[] items;
    public float itemTimeInterval;

    private float maxWidth;

    // Use this for initialization
    void Start () {
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        maxWidth = targetWidth.x;
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        //yield return new WaitForSeconds(2.0f);
        int i = 0;
        while (true)
        {
            GameObject item = items[Random.Range(0, items.Length)];
            Vector3 spawnPosition = new Vector3(
                //Random.Range(-maxWidth, maxWidth),
                Random.Range(-15, 15),
                Random.Range(0,100),
                -5f
            );
            //Quaternion spawnRotation = Quaternion.identity;
            Instantiate(item, spawnPosition, Quaternion.identity);
            i++;
            if (i > 5)
                yield return new WaitForSeconds(Random.Range(itemTimeInterval * 0.5f, itemTimeInterval));
        }
        yield return new WaitForSeconds(2.0f);
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
