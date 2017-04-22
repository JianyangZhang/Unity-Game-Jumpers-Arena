using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager_n : NetworkBehaviour {

    public GameObject[] items;
    public float itemTimeInterval;
    public float maxLength;
    public float initLength;
    public int initRowsNum;
    public int colsPerRow;
    public GameObject powerUp;

    // Update is called once per frame
    void Update() {

    }

    void Start() {
        init();
        StartCoroutine(Spawn());
    }

    //[Server]
    private void init() {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        for (int i = 0; i < initRowsNum; i++) {
            float yAxis = Random.Range(10, initLength);
            float step = (max.x - min.x) / colsPerRow;
            float xStart = min.x + step / 2;
            for (int j = 0; j < colsPerRow; j++) {
                Vector3 spawnPosition = new Vector3(
                    xStart,
                    yAxis,
                    4f
                );
                GameObject item = Instantiate(powerUp, spawnPosition, Quaternion.identity);
                Destroy(item, 20f);
                xStart += step;
                NetworkServer.Spawn(item);
            }
        }
    }

    //[Server]
    public IEnumerator Spawn() {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        yield return new WaitForSeconds(5.0f);
        while (true) {
            float yAxis = Random.Range(10, maxLength);
            float step = (max.x - min.x) / colsPerRow;
            float xStart = min.x + step / 2;
            for (int j = 0; j < colsPerRow; j++) {
                Vector3 spawnPosition = new Vector3(
                    xStart,
                    yAxis,
                    4f
                );
                GameObject item = Instantiate(powerUp, spawnPosition, Quaternion.identity);
                Destroy(item, 20f);
                xStart += step;
                NetworkServer.Spawn(item);
            }
            yield return new WaitForSeconds(Random.Range(itemTimeInterval * 0.5f, itemTimeInterval));
        }
    }
}
