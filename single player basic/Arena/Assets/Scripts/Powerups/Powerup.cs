using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Powerup : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public abstract Item getItemObject(Player1 player);

    void OnTriggerEnter2D(Collider2D e) {
        if (e.gameObject.tag.CompareTo("Player") == 0) {
            Powerup.print("meet powerup");
            Player1 player = e.gameObject.GetComponent<Player1>();
            if (player.items.Count < player.slots) {
                Item item = getItemObject(player);
                int itemIndex = player.items.Count;
                player.items.Add(item);
                //item.use(null, null);
                GameObject buttonSlot = GameObject.Find("ButtonSlot");
                Button btn = buttonSlot.GetComponent<Button>();
                SpriteRenderer spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
                Powerup.print(spriteRenderer.sprite.name);
                btn.GetComponent<Image>().sprite = spriteRenderer.sprite;
                BaseButton baseBtn = btn.GetComponent<BaseButton>();
                baseBtn.setParam(player, itemIndex, item);
                Destroy(gameObject);
            }


        }
    }
}
