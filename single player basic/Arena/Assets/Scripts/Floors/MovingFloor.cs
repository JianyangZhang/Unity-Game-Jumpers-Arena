using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour {


    Vector2 origin;
    Vector2 current;
    float multi = 0.5f;
    float speed = 1f;
    float startoffset = 0.1f;

    // Use this for initialization
    void Start() {
        multi = Random.Range(0.5f, 1f);
        startoffset = Random.Range(-0.2f, 0.2f);
        origin = transform.position;
        current = transform.position + new Vector3(startoffset, 0, 0);
    }

    // Update is called once per frame
    void Update() {
        current = transform.position;
    }

    void FixedUpdate() {
        GetComponent<Rigidbody2D>().velocity += Vector2.Scale(origin - current + new Vector2(speed, 0), new Vector2(multi, 1));
        //print (origin.ToString()+" "+current.ToString());
        //if (Camera.main.transform.position.y+ (-5) > transform.position.y)
        //	Destroy (gameObject);
    }
}
