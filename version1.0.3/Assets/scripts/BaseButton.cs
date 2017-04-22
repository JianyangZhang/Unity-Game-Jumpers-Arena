using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseButton : MonoBehaviour {
    Player player;
    //bug
    int itemIndex;
    //Item item;
    string item;
    public Sprite sprite;
    bool isValid;

    public void OnClick() {
        Player.print("Click Item " + item);
        if (isValid) {
            //item.use(player, null);
            Item.use(item, player);


            player.items.RemoveAt(itemIndex);

            gameObject.GetComponent<Image>().sprite = sprite;
            gameObject.GetComponent<Image>().color = new Color(222, 222, 222, 0);
            isValid = false;

        }
    }

    public void setParam(Player player, int index, string item)
    {
        if (!isValid)
        {
            isValid = true;
            this.player = player;
            itemIndex = index;
            this.item = item;
        }
        else
        {
            throw new System.Exception();
        }
    }

    //public void setParam(Player player, int index, Item item) {
    //    if (!isValid) {
    //        isValid = true;
    //        this.player = player;
    //        itemIndex = index;
    //        //this.item = item;
    //    } else {
    //        throw new System.Exception();
    //    }
    //}

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
