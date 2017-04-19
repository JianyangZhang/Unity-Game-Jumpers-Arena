using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Prototype.NetworkLobby;

public class GameManager : MonoBehaviour {

    public GameObject[] items;
    public float itemTimeInterval;
    public float maxLength;
    public float initLength;
    public int initRowsNum;
    public int colsPerRow;
    public GameObject finishDialog;
    public GameObject textBox;
    public GameObject middleDialog;

    public void pressBackBtn() {
        GameObject lm = GameObject.Find("LobbyManager");
        lm.GetComponent<LobbyManager>().GoBackButton();
        //SceneManager.LoadScene("lobby");
    }
    // Use this for initialization
    void Start() {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        for (int i = 0; i < initRowsNum; i++) {
            float yAxis = Random.Range(10, initLength);
            float step = (max.x - min.x) / colsPerRow;
            float xStart = min.x + step / 2;
            for (int j = 0; j < colsPerRow; j++) {
                GameObject item = items[Random.Range(0, items.Length)];
                Vector3 spawnPosition = new Vector3(
                    //Random.Range(-maxWidth, maxWidth),
                    xStart,
                    yAxis,
                    -5f
                );
                //Quaternion spawnRotation = Quaternion.identity;
                Instantiate(item, spawnPosition, Quaternion.identity);
                //Destroy(item, 20f);
                xStart += step;
            }
        }
        StartCoroutine(Spawn());
        middleDialog.SetActive(true);
        finishDialog.SetActive(false);
    }

    public IEnumerator Spawn() {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        yield return new WaitForSeconds(5.0f);
        while (true) {
            float yAxis = Random.Range(10, maxLength);
            float step = (max.x - min.x) / colsPerRow;
            float xStart = min.x + step / 2;
            for (int j = 0; j < colsPerRow; j++) {
                GameObject item = items[Random.Range(0, items.Length)];
                Vector3 spawnPosition = new Vector3(
                    //Random.Range(-maxWidth, maxWidth),
                    xStart,
                    yAxis,
                    -5f
                );
                //Quaternion spawnRotation = Quaternion.identity;
                Instantiate(item, spawnPosition, Quaternion.identity);
                //Destroy(item, 20f);
                xStart += step;
            }
            yield return new WaitForSeconds(Random.Range(itemTimeInterval * 0.5f, itemTimeInterval));
        }        
    }

    // Update is called once per frame
    void Update() {

    }

    public void gameOver(string name, bool isWinner) {
        Player.print("Game Over!!!");
        finishDialog.SetActive(true);
        middleDialog.SetActive(false);
        if (isWinner)
            textBox.GetComponent<Text>().text = "You Win !!!";
        else
            textBox.GetComponent<Text>().text = "You Lose\nPlayer " + name + " win.";
    }
}
