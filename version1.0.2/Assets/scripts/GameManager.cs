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
    public int initItemNum;
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
        for (int i = 0; i < initItemNum; i++) {
            GameObject item = items[Random.Range(0, items.Length)];
            Vector3 spawnPosition = new Vector3(
                //Random.Range(-maxWidth, maxWidth),
                Random.Range(-3, 3),
                Random.Range(0, maxLength),
                -5f
            );
            //Quaternion spawnRotation = Quaternion.identity;
            Instantiate(item, spawnPosition, Quaternion.identity);
        }
        StartCoroutine(Spawn());
        middleDialog.SetActive(true);
        finishDialog.SetActive(false);
    }

    public IEnumerator Spawn() {
        yield return new WaitForSeconds(5.0f);
        while (true) {
            GameObject item = items[Random.Range(0, items.Length)];
            Vector3 spawnPosition = new Vector3(
                //Random.Range(-maxWidth, maxWidth),
                Random.Range(-15, 15),
                Random.Range(0, 100),
                -5f
            );
            //Quaternion spawnRotation = Quaternion.identity;
            Instantiate(item, spawnPosition, Quaternion.identity);
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
