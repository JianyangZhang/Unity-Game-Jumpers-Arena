using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Missile : NetworkBehaviour {

    [SyncVar]
    public NetworkInstanceId targetId;

    public Player targetPlayer = null;
    public Player currentPlayer = null;

    private const float speed = 3;
    private int delay = 200;

    // Use this for initialization
    void Start() {
        //MAX_ROTATION_FRAME = MAX_ROTATION / ((float)(Application.targetFrameRate == -1 ? 60 : Application.targetFrameRate));
        //GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);
    }

    // Update is called once per frame
    void Update() {
        if (targetPlayer != null) {
            Player.print("Target = " + targetPlayer.netId);
            Player.print(targetPlayer.transform.position);
            Player.print(this.transform.position);
            float dx = targetPlayer.transform.position.x - this.transform.position.x;
            float dy = targetPlayer.transform.position.y - this.transform.position.y;
            float length = Mathf.Sqrt(dx * dx + dy * dy);
            float rotation = Mathf.Atan2(dy, dx);
            Player.print("rotation :" + rotation + ", move : " + Mathf.Sin(rotation));
            if (length <= speed) {
                transform.position += new Vector3(dx, dy, 0);
            } else {
                float x = speed * dx / length;
                transform.position += new Vector3(speed * dx / length, speed * dy / length);
            }
        } else {
            //Player.print("No target");
        }
    }

    void OnTriggerEnter2D(Collider2D e) {
        if (targetPlayer == null)
            return;
        if (e.gameObject.tag.CompareTo("Player") == 0 && (e.gameObject.GetComponent<Player>().netId == targetPlayer.netId)) {
            int finishTime = targetPlayer.time + delay;
            EventBean bean = new EventBean();
            bean.finishTime = finishTime;
            bean.delay = delay;
            bean.itemName = "MissileItem";
            bean.className = "missile";
            //Player.print("apply speedDown, current: " + currentPlayer.netId + "player id:" + targetPlayer.netId);
            //player.speedRatio = speedRatio;
            bean.id = targetPlayer.netId;
            if (currentPlayer.isClient)
                currentPlayer.CmdAddTask(bean);
            else
                targetPlayer.CmdAddTask(bean);
            Player.print("Player " + targetId + " is hitted");
            Destroy(gameObject);
        }
    }


    private float MakeSureRightRotation(float rotation) {
        rotation += 360;
        rotation %= 360;
        return rotation;
    }
}
