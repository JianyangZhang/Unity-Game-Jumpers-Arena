using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {
    // public string id;
    // public Character character;
    [SyncVar]
    public string role;
    [SyncVar]
    public int slots;
    [SyncVar]
    public string alias;
    [SyncVar]
    public int hp;
    
    public List<Item> items;
    [SyncVar]
    public bool isShield;
    [SyncVar]
    public bool isAccelerated;
    [SyncVar]
    public bool isDecelerated;
    [SyncVar]
    public bool isStunned;
    
    public Camera maincamera;

    public float speedRatio = 1f;

    public int time = 0;
    public Dictionary<string, Item> timeDic = new Dictionary<string, Item>();

    public Vector2 velocity {
        get {
            return GetComponent<Rigidbody2D>().velocity;
        }
        set {
            GetComponent<Rigidbody2D>().velocity = value;
        }
    }

    public Vector2 location {
        get {
            return transform.position;
        }
        set {
            transform.position = value;
        }
    }

    private void eventManager() {
        //Player1.print(time);
        time++;
        foreach (string name in new List<string>(timeDic.Keys)) {
            Item item = timeDic[name];
            if (item.finishTime <= time) {
                item.finish();
                timeDic.Remove(name);
            }
        }
    }

    float speedmul;
    Vector2 movement;
    

    private Rigidbody2D m_RigidBody2D;

    Vector2 nowvelocity;

    // Use this for initialization
    void Start() {
        CmdInitializeAll();
        maincamera = Camera.main;
        m_RigidBody2D = GetComponent<Rigidbody2D>();
        items = new List<Item>();
        speedmul = 5f;
    }

    // Update is called once per frame
    void Update() {
        if (isLocalPlayer == false) {
            return;
        }
        //Player.print(this.alias);
        // 下面写控制
        movement = new Vector2(Input.GetAxis("Horizontal") * speedmul, 0);

        maincamera.transform.position += new Vector3(0f, transform.position.y - maincamera.transform.position.y, 0);


    }

    void FixedUpdate() {
        if (isLocalPlayer == false) {
            return;
        }
        nowvelocity = m_RigidBody2D.velocity;
        m_RigidBody2D.velocity = new Vector2(0f, GetComponent<Rigidbody2D>().velocity.y);
        m_RigidBody2D.velocity += movement;
        eventManager();
        //if (nowvelocity.y > 0)
        //maincamera.transform.position += new Vector3 (0f, Mathf.Max(transform.position.y-maincamera.transform.position.y,0) ,0);

    }

    //[ClientRpc]
    //public int CmdCountItemlist() {
    //    return items.Count;
    //}

    //[ClientRpc]
    //public void CmdaddItem(Item item) {
    //    items.Add(item);
    //}

    [Command]
    public void CmdInitializeAll() {
        /*switch (BasicPlayerInfo.instance.characterIndex) {
			case 0:
				character.slots = 2;
				character.role = "ninja";
				break;				
			case 1:
				character.slots = 3;
				character.role = "hunter";
				break;	
			case 2:
				character.slots = 1;
				character.role = "enchanter";
				break;	
			case 3:
				character.slots = 2;
				character.role = "thief";
				break;	
			default:
				character.slots = 2;
				character.role = "ninja";
				break;
		}
		alias = BasicPlayerInfo.instance.playerName; 初始化写在了lobbyhook里, 直接.即可*/
        hp = 100;
        items = null;
        isShield = false;
        isAccelerated = false;
        isDecelerated = false;
        isStunned = false;
    }
}