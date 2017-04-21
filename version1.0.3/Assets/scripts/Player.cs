using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using DragonBones;

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
    [SyncVar]
    public int eyes;
    [SyncVar]
    public int skin;

    [SyncVar]
    public NetworkInstanceId winnerId;
    [SyncVar]
    public string winnerName;

    public List<string> items;
    //public List<Item> items;
    [SyncVar]
    public bool isShield;
    [SyncVar]
    public bool missileHited;
    [SyncVar]
    public bool isAccelerated;
    [SyncVar]
    public bool isDecelerated;
    [SyncVar]
    public bool isStunned;

    public Camera maincamera;
    [SyncVar]
    public float speedRatio = 1f;

    [SyncVar]
    public int time = 0;
    [SyncVar]
    public SyncListEventBean tasksList = new SyncListEventBean();
    [SyncVar]
    public SyncListEventBean timeList = new SyncListEventBean();
    public Dictionary<string, EventBean> timeDic = new Dictionary<string, EventBean>();
    public Sprite[] sprites;
    private int listIndex = 0;
    public UnityArmatureComponent armatureComponent;
    public bool isUp = false;
    public bool isDown = true;
    public GameObject bananaPrefab;
    public GameObject missilePrefab;

    private Dictionary<NetworkInstanceId, Player> playerDic;
    private List<Player> players;
    public AudioClip speedupAudio;
    public AudioClip slipAudio;
	public AudioClip missledAudio;
	public AudioClip decAudio;

    AudioSource[] audios;
    ParticleSystem flame;
    ParticleSystem slip;
    ParticleSystem dust;
	ParticleSystem missled;
	ParticleSystem dec;
	ParticleSystem shield;
    bool facingleft;
    float speedmul;
    Vector2 movement;
    private Rigidbody2D m_RigidBody2D;
    Vector2 nowvelocity;

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
        //Player.print(objs.Length + "player objs" + this.netId);
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
                    Player.print("Task: Player" + target.netId + " do task " + e.itemName);
                }
                p.tasksList.Clear();
            }
        }
    }

    [Command]
    public void CmdAddTask(EventBean e) {
        tasksList.Add(e);
    }

    [Command]
    public void CmdAddWinner() {
        foreach (Player player in players) {
            player.winnerId = this.netId;
            player.winnerName = this.alias;
        }
    }

    [Command]
    void CmdFire(NetworkInstanceId currentID) {
        GameObject bullet_r = Instantiate(bananaPrefab, transform.position, transform.rotation);
        //bullet_r.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
        Player.print("find Target");
        //foreach (Player p in players) {
        //    if (p.netId != currentID) {
        //        bullet_r.GetComponent<Missile>().targetPlayer = p;
        //        bullet_r.GetComponent<Missile>().targetId = p.netId;
        //        //bullet_r.GetComponent<Missile>().currentPlayer = this;
        //        Player.print("Init target");
        //        break;
        //    }
        //}

        //Destroy(bullet_r, 2);
        NetworkServer.Spawn(bullet_r);
    }

    [Command]
    public void CmdSetBanana() {
        GameObject banana_r = Instantiate(bananaPrefab, transform.position, transform.rotation);
        NetworkServer.Spawn(banana_r);
    }

    [Command]
    public void CmdSetupMissile(NetworkInstanceId currentID) {
        GameObject missile_r = Instantiate(missilePrefab, transform.position, transform.rotation);
        //bullet_r.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
        Player.print("Setup Missile");
        Player target = null;
        Player current = null;
        foreach (Player p in players) {
            if (p.netId == currentID) {
                current = p;
                break;
            }
        }
        float loc = float.MaxValue;
        foreach (Player p in players) {
            if (p.netId != currentID) {
                if ((p.transform.position.y > current.transform.position.y) && (loc > p.transform.position.y)) {
                    loc = p.transform.position.y;
                    target = p;
                }
            }
        }
        missile_r.GetComponent<Missile>().targetPlayer = target;
        if (target != null) {
            missile_r.GetComponent<Missile>().targetId = target.netId;
            Player.print("Player :" + currentID + " hits Player" + target.netId);
        } else {
            Player.print("Player :" + currentID + " hits NULL");
        }
        missile_r.GetComponent<Missile>().currentPlayer = current;
        if (target == null) {
            Destroy(missile_r, 2);
            missile_r.GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);
        }
        NetworkServer.Spawn(missile_r);
    }

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
        //items = null;
        isShield = false;
        isAccelerated = false;
        isDecelerated = false;
        missileHited = false;
        isStunned = false;
        winnerId = NetworkInstanceId.Invalid;
    }

    private void eventManager() {
        //Player1.print(time);
        if (timeList.Count > listIndex) {
            for (; listIndex < timeList.Count; listIndex++) {
                EventBean bean = timeList[listIndex];
                bean.finishTime = time + bean.delay;
                timeDic[bean.className] = bean;
                Item.execute(bean.itemName, this);
                Player.print("Player " + this.netId + " exec " + bean.itemName + " " + time);
            }
        }
        time++;
        foreach (string name in new List<string>(timeDic.Keys)) {
            //Item item = timeDic[name];
            EventBean item = timeDic[name];
            if (item.finishTime <= time) {
                //item.finish();
                Player.print("finish " + item.itemName + " " + time);
                Item.finish(item.itemName, this);
                timeDic.Remove(name);
            }
        }
    }

    void flip() {
        facingleft = !facingleft;
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }


    // Use this for initialization
    void Start() {
        audios = GetComponents<AudioSource>();
        flame = transform.Find("Flame").GetComponent<ParticleSystem>();
        slip = transform.Find("Slip").GetComponent<ParticleSystem>();
		missled = transform.Find("Missled").GetComponent<ParticleSystem>();
		dec = transform.Find("Dec").GetComponent<ParticleSystem>();
		shield = transform.Find("Sheild").GetComponent<ParticleSystem>();
        // dust = transform.Find("Dust").GetComponent<ParticleSystem>();
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Player.print("width:" + min.x + " , " + max.x);
        Player.print("height:" + min.y + " , " + max.y);
        //StartCoroutine(initPlayers());
        // SpriteRenderer spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
        int charIndex = 0;
        for (int i = 0; i < BasicPlayerInfo.instance.CharacterDiscription.Length; i++) {
            if (role == BasicPlayerInfo.instance.CharacterDiscription[i]) {
                charIndex = i;
                break;
            }
        }
        //if (role == "ninja")
        //     spriteRenderer.sprite = sprites[0];
        // else if (role == "hunter")
        //     spriteRenderer.sprite = sprites[1];
        // else if (role == "enchanter")
        //     spriteRenderer.sprite = sprites[2];
        // else if (role == "thief")
        //     spriteRenderer.sprite = sprites[3];
        CmdInitializeAll();
        maincamera = Camera.main;
        m_RigidBody2D = GetComponent<Rigidbody2D>();
        armatureComponent = GetComponent<UnityArmatureComponent>();
        Player.print("eyes" + eyes + "char" + charIndex + "skin" + skin);
        BasicPlayerInfo.UpdateEyes(eyes, armatureComponent);
        BasicPlayerInfo.UpdateChar(charIndex, armatureComponent);
        BasicPlayerInfo.UpdateColor(skin, armatureComponent);
        int index = 1;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject gameObj in objs) {
            Player p = gameObj.GetComponent<Player>();
            p.GetComponent<UnityArmatureComponent>().transform.position = new Vector3(0.0f, 0.0f, -15.0f + index);
            index++;
            if (p.isLocalPlayer) {
                armatureComponent.transform.position = new Vector3(0.0f, 0.0f, -15.0f);
            }
        }
        items = new List<string>();
        speedmul = 0.5f;
        initPlayers();
        // Warning!!!! make all character's slot as 1
        slots = 1;
    }

    // Update is called once per frame
    void Update() {
        if (isLocalPlayer == false) {
            return;
        }
        if (winnerId != NetworkInstanceId.Invalid) {
            GameManager mr = GameObject.Find("GameManager").GetComponent<GameManager>();
            if (winnerId == netId) {
                mr.gameOver(name, true);
            } else {
                mr.gameOver(winnerName, false);
            }
            gameObject.SetActive(false);
        }

        //Player.print(this.alias);
        // 下面写控制
        //movement = new Vector2(Input.GetAxis("Horizontal") * speedmul, 0);
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        float length = 0f;
        if (Input.GetAxis("Horizontal") != 0)
            length = Input.GetAxis("Horizontal") * speedmul / 3;
        else
            length = Input.acceleration.x * speedmul;
        if ((facingleft && length < 0) || (length > 0 && !facingleft))
            flip();
        //if (transform.position.x + length < min.x - 1)
        //    length = min.x - 1f - transform.position.x;
        //if (transform.position.x + length > max.x + 1)
        //    length = max.x + 1f - transform.position.x;
        //float scale = Random.Range(-1, 1);
        length = Mathf.Clamp(length + transform.position.x, min.x, max.x);
        if (missileHited)
            movement = new Vector2(length * -1, 0);
        else
            movement = new Vector2(length, 0);
        if (isStunned) {
            movement = new Vector2(0, 0);
            flip();
        }
        transform.position = new Vector2(length, transform.position.y);

        maincamera.transform.position += new Vector3(0f, transform.position.y - maincamera.transform.position.y, 0);

        //if (Input.GetKeyDown(KeyCode.Space)) {
        //	CmdFire(this.netId);
        //}

        if (isStunned && !audios[0].isPlaying) {
            audios[0].PlayOneShot(slipAudio, 1f);
            slip.Play();
        }

        if (speedRatio == 1.5f && !audios[1].isPlaying) {
            audios[1].PlayOneShot(speedupAudio, 1f);
            flame.Play();
        }
		if (missileHited && !audios[2].isPlaying) {
			audios[2].PlayOneShot(missledAudio, 1f);
			missled.Play();
		}
		if (isDecelerated && !audios[3].isPlaying) {
			audios[3].PlayOneShot(decAudio, 1f);
			dec.Play();
		}
		if (isShield) {
			shield.Play();
		}
    }


    void FixedUpdate() {
        taskManager();
        if (isLocalPlayer == false) {
            return;
        }
        if (winnerId != NetworkInstanceId.Invalid) {
            return;
        }
        nowvelocity = m_RigidBody2D.velocity;
        m_RigidBody2D.velocity = new Vector2(0f, GetComponent<Rigidbody2D>().velocity.y);
        //m_RigidBody2D.velocity += movement;
        //m_RigidBody2D.position += movement;
        eventManager();
        //Player.print (nowvelocity.y  );
        if (m_RigidBody2D.velocity.y > 0 && !isUp) {
            isDown = false;
            isUp = true;
            //armatureComponent.animation..Reset ();
            armatureComponent.animation.Play("TouchBottom", 1);
            armatureComponent.RemoveEventListener(EventObject.COMPLETE, AnimationController.PlayDownEventHandler);
            armatureComponent.AddEventListener(EventObject.COMPLETE, AnimationController.PlayStandEventHandler);
            audios[0].Play();
        }
        if (m_RigidBody2D.velocity.y < 0 && !isDown) {
            isDown = true;
            isUp = false;
            //armatureComponent.animation.Reset ();
            armatureComponent.animation.Play("StartDown", 1);
            armatureComponent.RemoveEventListener(EventObject.COMPLETE, AnimationController.PlayStandEventHandler);
            armatureComponent.AddEventListener(EventObject.COMPLETE, AnimationController.PlayDownEventHandler);
        }
        //if (nowvelocity.y > 0)
        //maincamera.transform.position += new Vector3 (0f, Mathf.Max(transform.position.y-maincamera.transform.position.y,0) ,0);
    }

}