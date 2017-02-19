using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public string id;
    public Character character;
    public string alias;
    public int hp;
    public List<Item> items;
    public bool isShield;
    public bool isAccelerated;
    public bool isDecelerated;
    public bool isStunned;

    public Vector2 velocity
    {
        get
        {
            return GetComponent<Rigidbody2D>().velocity;
        }
        set
        {
            GetComponent<Rigidbody2D>().velocity = value;
        }
    }

    public Vector2 location
    {
        get
        {
            return transform.position;
        }
        set
        {
            transform.position = value;
        }
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

