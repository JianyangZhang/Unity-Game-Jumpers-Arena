using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFloor : MonoBehaviour {

    GameManager mr;

    private void Awake() {
        mr = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D e) {
        if (e.gameObject.tag.CompareTo("Player") == 0) {
            print("finish");
            //mr.gameOver();
            e.gameObject.GetComponent<Player>().CmdAddWinner();
        }
    }
}
