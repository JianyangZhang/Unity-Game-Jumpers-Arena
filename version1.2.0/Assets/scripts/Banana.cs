using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Banana : NetworkBehaviour {

    [SyncVar]
    public NetworkInstanceId targetId;
    private GameObject floor = null;
    private float initX = 0f;

    public bool isDrop = true;

    private const float speed = -0.2f;
    private int delay = 100;

    // Use this for initialization
    void Start() {
        //MAX_ROTATION_FRAME = MAX_ROTATION / ((float)(Application.targetFrameRate == -1 ? 60 : Application.targetFrameRate));
        //GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);
    }

    // Update is called once per frame
    void Update() {
        if (isDrop) {
            //this.transform.position += new Vector3(0, speed, 0);
            if (this.transform.position.y < -10f)
                Destroy(gameObject);
        } else {
            //Player.print("No target");
            float dx = floor.transform.position.x - initX;
            initX = floor.transform.position.x;
            transform.position += new Vector3(dx, 0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D e) {
        if (e.gameObject.tag.CompareTo("Floor") == 0 && isDrop) {
            Player.print("TOUCH !!!!!!!!");
            isDrop = false;
            floor = e.gameObject;
            initX = floor.transform.position.x;
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            this.GetComponent<Rigidbody2D>().freezeRotation = true;

            this.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    void OnTriggerEnter2D(Collider2D e) {

        if (e.gameObject.tag.CompareTo("Player") == 0 && !isDrop) {
            Player targetPlayer = e.gameObject.GetComponent<Player>();
            int finishTime = targetPlayer.time + delay;
            EventBean bean = new EventBean();
            bean.finishTime = finishTime;
            bean.delay = delay;
            bean.itemName = "BananaItem";
            bean.className = "banana";
            bean.id = targetPlayer.netId;
            targetPlayer.CmdAddTask(bean);
            Player.print("Player " + targetId + " get Banana");
            Destroy(gameObject);
        }
    }


    private float MakeSureRightRotation(float rotation) {
        rotation += 360;
        rotation %= 360;
        return rotation;
    }
}

