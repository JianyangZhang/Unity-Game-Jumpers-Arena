using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Missile : NetworkBehaviour {

    [SyncVar]
    public NetworkInstanceId targetId;

    public Player targetPlayer = null;

    private const float speed = 1;

    // Use this for initialization
    void Start () {
        //MAX_ROTATION_FRAME = MAX_ROTATION / ((float)(Application.targetFrameRate == -1 ? 60 : Application.targetFrameRate));
        //GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (targetPlayer != null) {
            Player.print("Target = " + targetPlayer.netId);
            Player.print(targetPlayer.transform.position);
            Player.print(this.transform.position);
            //Vector3 targetPos = Camera.main.WorldToScreenPoint(targetPlayer.transform.position);
            //Vector3 thisPos = Camera.main.WorldToScreenPoint(transform.position);
            ////print(cubePos + ":" + spherePos);

            //this.transform.LookAt(targetPlayer.transform);
            //float distance = Vector3.Distance(targetPos, thisPos);
            //float time = distance / 2f;

            //float xSpeed = (targetPos.x - thisPos.x) / time;
            //float ySpeed = (targetPos.y - thisPos.y) / time;

            //float x = Mathf.Clamp(transform.localPosition.x, -400, 400);
            //transform.localPosition = new Vector3(x, transform.localPosition.y, 0);

            //transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);
            float dx = targetPlayer.transform.position.x - this.transform.position.x;
            float dy = targetPlayer.transform.position.y - this.transform.position.y;
            float length = Mathf.Sqrt(dx * dx + dy * dy);
            float rotation = Mathf.Atan2(dy, dx);
            if (Mathf.Abs(speed * Mathf.Sin(rotation)) > Mathf.Abs(dx)) {
                transform.position += new Vector3(dx, dy, 0);
            } else {
                transform.position += new Vector3(speed * Mathf.Sin(rotation), speed * Mathf.Cos(rotation));
            }
        } else {
            Player.print("No target");
        }
    }

    private float MakeSureRightRotation(float rotation) {
        rotation += 360;
        rotation %= 360;
        return rotation;
    }
}
