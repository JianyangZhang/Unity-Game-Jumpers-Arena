﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseButton : MonoBehaviour {
    Player1 player;
    //bug
    int itemIndex;
    Item item;
    public Sprite sprite;
    bool isValid;

    public void OnClick() {
        if (isValid) {
            item.use(player, null);
            player.items.RemoveAt(itemIndex);
            gameObject.GetComponent<Image>().sprite = sprite;
            isValid = false;
        }
    }

    public void setParam(Player1 player, int index, Item item) {
        if (!isValid) {
            isValid = true;
            this.player = player;
            itemIndex = index;
            this.item = item;
        } else {
            throw new System.Exception();
        }
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
