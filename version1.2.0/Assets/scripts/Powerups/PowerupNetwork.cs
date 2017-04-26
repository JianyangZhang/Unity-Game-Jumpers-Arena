using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PowerupNetwork : NetworkBehaviour {

    private List<string> itemList;
    private List<float> itemWeight;
    [SyncVar]
    public int index = -1;
    public List<Sprite> itemImages;
    // Use this for initialization
    void Start() {
        itemList = new List<string>();
        itemList.Add("SpeedUpItem");
        itemList.Add("SpeedDownItem");
        itemList.Add("MissileItem");
        itemList.Add("BananaItem");
        itemList.Add("ShieldItem");
        itemWeight = new List<float>();
        itemWeight.Add(1);
        itemWeight.Add(0.5f);
        itemWeight.Add(3);
        itemWeight.Add(1);
        itemWeight.Add(1.5f);

        if (isServer) {
            index = generateIndex();
            Player.print("Index : " + index);
        }
        if (index != -1) {
            SpriteRenderer spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
            spriteRenderer.sprite = itemImages[index];
        }
    }

    void Update() {
        if (index != -1) {
            SpriteRenderer spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
            spriteRenderer.sprite = itemImages[index];
        }
    }

    void OnTriggerEnter2D(Collider2D e) {
        if (!isClient)
            return;
        if (e.gameObject.tag.CompareTo("Player") == 0) {
            Powerup.print("meet powerup");
            Player player = e.gameObject.GetComponent<Player>();
            Powerup.print(player.alias);
            Powerup.print("Slots : " + player.slots);
            Powerup.print(player.isLocalPlayer + " " + player.items.Count);
            if (player.isLocalPlayer && player.items.Count < player.slots) {
                Powerup.print("Enter Inner");
                string item = itemList[index];
                int itemIndex = player.items.Count;
                player.items.Add(item);
                GameObject buttonSlot = GameObject.Find("ButtonSlot");
                Button btn = buttonSlot.GetComponent<Button>();
                //Powerup.print(spriteRenderer.sprite.name);

                btn.GetComponent<Image>().color = new Color(222, 222, 222, 255);
                btn.GetComponent<Image>().sprite = itemImages[index];
                BaseButton baseBtn = btn.GetComponent<BaseButton>();
                baseBtn.setParam(player, itemIndex, item);
                Powerup.print("Destroy Gameobject1111");
                player.CmdDestroyThis(netId);
            }
        }
    }

    int generateIndex() {
        List<float> tmpSum = new List<float>();
        tmpSum.Add(0);
        float sum = 0;
        foreach (float weight in itemWeight) {
            sum += weight;
            tmpSum.Add(sum);
        }
        float k = Random.Range(0, sum);
        for (int i = 0; i < itemList.Capacity; i++) {
            if ((k > tmpSum[i]) && (k < tmpSum[i + 1]))
                return i;
        }
        return 0;
    }
}
