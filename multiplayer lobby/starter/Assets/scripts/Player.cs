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

    public List<string> items;
    //public List<Item> items;
    [SyncVar]
    public bool isShield;
    [SyncVar]
    public bool isAccelerated;
    [SyncVar]
    public bool isDecelerated;
    [SyncVar]
    public bool isStunned;
    
    public Camera maincamera;
    [SyncVar]
    public float speedRatio = 1f;

    public int time = 0;
    [SyncVar]
    public SyncListEventBean tasksList = new SyncListEventBean();
    [SyncVar]
    public SyncListEventBean timeList = new SyncListEventBean();
    public Dictionary<string, EventBean> timeDic = new Dictionary<string, EventBean>();
    public Sprite[] sprites;
    private int listIndex = 0;

    
    private Dictionary<NetworkInstanceId, Player> playerDic;
    private List<Player> players;

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
    [Server]
    public void initPlayers() {
        //yield return new WaitForSeconds(2);
        playerDic = new Dictionary<NetworkInstanceId, Player>();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        Player.print(objs.Length + "player objs" + this.netId);
        players = new List<Player>();
        foreach (GameObject gameObj in objs) {
            Player p = gameObj.GetComponent<Player>();
            playerDic[p.netId] = p;
            players.Add(p);
        }
    }

    [Server]
    public void taskManager() {
        if (!isServer)
            return;
        if (time % 100 == 0)
            initPlayers();
        if (players == null)
            return;
        //initPlayers();
        foreach (Player p in players) {
            if (p.tasksList.Count > 0) {
                foreach (EventBean e in p.tasksList) {
                    Player target = playerDic[e.id];
                    target.timeList.Add(e);
                }
                p.tasksList.Clear();
            }
        }
    }

    [Command]
    public void CmdAddTask(EventBean e) {
        tasksList.Add(e);
    }
    
    private void eventManager() {
        //Player1.print(time);
        if (timeList.Count > listIndex) {
            for (; listIndex < timeList.Count; listIndex++) {
                timeDic[timeList[listIndex].className] = timeList[listIndex];
                Item.execute(timeList[listIndex].itemName, this);
            }
        }
        time++;
        foreach (string name in new List<string>(timeDic.Keys)) {
            //Item item = timeDic[name];
            EventBean item = timeDic[name];
            if (item.finishTime <= time) {
                //item.finish();
                Player.print("finish " + item.itemName);
                Item.finish(item.itemName, this);
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
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Player.print("width:" + min.x + " , " + max.x);
        Player.print("height:" + min.y + " , " + max.y);
        //StartCoroutine(initPlayers());
        SpriteRenderer spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
        if (role == "ninja")
            spriteRenderer.sprite = sprites[0];
        else if (role == "hunter")
            spriteRenderer.sprite = sprites[1];
        else if (role == "enchanter")
            spriteRenderer.sprite = sprites[2];
        else if (role == "thief")
            spriteRenderer.sprite = sprites[3];
        CmdInitializeAll();
        maincamera = Camera.main;
        m_RigidBody2D = GetComponent<Rigidbody2D>();
        items = new List<string>();
        speedmul = 5f;
        initPlayers();
    }

    // Update is called once per frame
    void Update() {
        if (isLocalPlayer == false) {
            return;
        }
        //Player.print(this.alias);
        // 下面写控制
        //movement = new Vector2(Input.GetAxis("Horizontal") * speedmul, 0);
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        float length = Input.GetAxis("Horizontal") * speedmul;
        if ((facingleft && length < 0) || (length > 0 && !facingleft))
            flip();
        if (transform.position.x + length < min.x - 1)
            length = min.x - 1f - transform.position.x;
        if (transform.position.x + length > max.x + 1)
            length = max.x + 1f - transform.position.x;
        movement = new Vector2(length, 0);
        maincamera.transform.position += new Vector3(0f, transform.position.y - maincamera.transform.position.y, 0);


    }

    bool facingleft;
    void flip() {
        facingleft = !facingleft;
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }

    void FixedUpdate() {
        taskManager();
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