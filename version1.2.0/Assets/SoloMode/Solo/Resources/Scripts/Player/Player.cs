using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena{

	public class Player : MonoBehaviour,IDamage {

        public string id;
        public string alias;
        public int hp;
        public int maxhp;
        public int MaxHp { set { maxhp = value; } get { return maxhp; } }
        public int Hp { set { hp = value; } get { return hp; } }
        public bool IsIDamageWork { get { return false; } }
        public bool IsShield { get { return buffStatus.IsShield; } }

		public AudioClip speedupAudio;
		public AudioClip rocketLaunchAudio;
		public AudioClip decAudio;
		public AudioClip missleAudio;

		AudioSource[] audios;

        public void Damage(int damageto)
        {
            hp -= damageto;
        }

        SimpleShooter[] shooterGroup=new SimpleShooter[0];

        public Vector3 ScreenOffset
        {
            get { return screenOffset; }
        }
        private Vector3 screenOffset = new Vector3(0, 1, 0); // Vector3.zero;

        Dictionary<string, ParticleSystem> particleList;

        public void ParticlePlayOnce(string name)
        {
            if (particleList.ContainsKey(name))
            {
                particleList[name].loop = false;
                particleList[name].Play();
            }
        }

        public void ParticlePlay(string name)
        {
            if (particleList.ContainsKey(name))
            {
                particleList[name].loop = true;
                particleList[name].Play();
            }
        }

        public void ParticleStop(string name)
        {
            if (particleList.ContainsKey(name))
            {
                particleList[name].loop = false;
            }
        }

        //public List<Item> items;
        public Dictionary<string,GameObject> SubDecorations;

        public class MorphoStatus
        {
            public float Speed;
            public float Jump;
            public float Gravity;
            public MorphoStatus()
            {
                Speed = 10f;
                Jump = 12f;
                Gravity = 1f;
            }
        }

        public class BuffStatus
        {
            public float SpeedMul;
            public float JumpMul;
            public float Gravity;
            public bool IsFreeze;
            public bool IsFloorAffected;
            public bool IsShield;
            public bool IsShooting;
            public BuffStatus()
            {
                SpeedMul = 0;
                JumpMul = 0;
            }
        }

        public void AddBuff(string type, float value, float time)
        {
            switch (type)
            {
                case "Freeze":
                    buffStatus.IsFreeze = value != 0 ? true : false;
                    BuffTimer[type] = time;
                    BuffWatcher.Add(type);
                    break;
				case "Shooter":
					audios[3].Play();
                    buffStatus.IsShooting = value != 0 ? true : false;
                    BuffTimer[type] = time;
                    BuffWatcher.Add(type);
                    foreach (SimpleShooter st in shooterGroup) st.ShootEnable = true;
                    break;
                case "Shield":
                    buffStatus.IsShield = value != 0 ? true : false;
                    BuffTimer[type] = time;
                    BuffWatcher.Add(type);
                    SubDecorations["helmet"].SetActive(true);
                    break;
                case "JumpMul":
                    buffStatus.JumpMul = value;
                    BuffTimer[type] = time;
                    BuffWatcher.Add(type);
                    break;
                case "JumpMulDelta":
                    buffStatus.JumpMul += value;
                    BuffTimer["JumpMul"] = time;
                    BuffWatcher.Add("JumpMul");
                    if (buffStatus.JumpMul>0)
                    {	
						audios[0].PlayOneShot(speedupAudio, 1f);
                        ParticlePlay("dust");
                        ParticleStop("dec");
                    }else
                    {
						audios[2].PlayOneShot(decAudio, 1f);
                        ParticlePlay("dec");
                        ParticleStop("dust");
                    }
                    break;
                default:
                    break;
            }
        }

        public void RemoveBuff(string type)
        {
            switch (type)
            {
                case "Freeze":
                    buffStatus.IsFreeze = false;
                    BuffWatcher.Remove(type);
                    break;
				case "Shooter":
					audios[3].Stop();
					buffStatus.IsShooting = false;
					foreach (SimpleShooter st in shooterGroup) {
						st.ShootEnable = false;
					}
                    BuffWatcher.Remove(type);
                    break;
                case "Shield":
                    buffStatus.IsShield = false;
                    BuffWatcher.Remove(type);
                    SubDecorations["helmet"].SetActive(false);
                    break;
                case "JumpMul":
                    buffStatus.JumpMul = 0;
                    BuffWatcher.Remove(type);
                    ParticleStop("dec");
                    ParticleStop("dust");
                    break;
                case "All"://Will remove in next turn
                    foreach (string index in BuffWatcher)
                        BuffTimer[index] = 0;
                    break;
                default:
                    break;
            }
        }

        public BuffStatus buffStatus;
        public MorphoStatus[] morphoStatus;
        int currentMorpho;
        float morphoTimeLeft;

        public void Btn_Gameover()
        {
            SetMorphoType(201, 999);
        }

        public void SetMorphoType(int mft, float time)
        {
            switch (currentMorpho)
            {
                case 1:
                    SubDecorations["rocket"].SetActive(false);
                    ParticleStop("flame");
                    break;
                case 201:
                    break;
                default:
                    break;
            }
            switch (mft)
            {
				case 1:
					SubDecorations["rocket"].SetActive(true);
					audios[1].PlayOneShot(rocketLaunchAudio, 1f);
                    ParticlePlay("flame");
                    break;
                case 201://Dead
                    ParticlePlayOnce("missiled");
                    SubDecorations["rocket"].SetActive(false);
                    SubDecorations["hero"].SetActive(false);
                    SubDecorations["helmet"].SetActive(false);
                    velocity = Vector2.zero;
                    MainHelper.Instance.Gameover(0);
                    break;
                case 301://Retreat
                    velocity = Vector2.zero;
                    MainHelper.Instance.Gameover(1);
                    break;
                default:
                    break;
            }
            //RemoveBuff("All");

            morphoTimeLeft = time;
            currentMorpho = mft;

            m_RigidBody2D.gravityScale = CurrentMorphoStatus.Gravity;
        }

        public MorphoStatus CurrentMorphoStatus
        { get { return morphoStatus[currentMorpho]; } }

        public Dictionary<string, float> BuffTimer;
        public List<string> BuffWatcher;
        

        public Vector2 velocity { get { return GetComponent<Rigidbody2D>().velocity; } set { GetComponent<Rigidbody2D>().velocity = value; } }

        public Vector2 location { get { return transform.position; } set { transform.position = value; } }

        Vector2 movement;

        private Rigidbody2D m_RigidBody2D;

        Vector2 nowvelocity;

        // Use this for initialization
        void Awake()
        {
            //Initialize Module Linking
			audios = GetComponents<AudioSource>();
            m_RigidBody2D = GetComponent<Rigidbody2D>();
            buffStatus = new BuffStatus();
            morphoStatus = new MorphoStatus[350];
            morphoStatus[0] = new MorphoStatus();
            morphoStatus[1] = new MorphoStatus();
            morphoStatus[1].Gravity = 0;
            morphoStatus[1].Jump = 5f;
            morphoStatus[201] = new MorphoStatus();
            morphoStatus[201].Gravity = 0;
            morphoStatus[201].Jump = 0;
            morphoStatus[201].Speed = 0;
            morphoStatus[301] = new MorphoStatus();
            morphoStatus[301].Gravity = 0;
            morphoStatus[301].Jump = 0;
            morphoStatus[301].Speed = 0;
            BuffTimer = new Dictionary<string, float>();
            BuffWatcher = new List<string>();

            if (MaxHp == 0) MaxHp = 100;
            hp = maxhp;

            SubDecorations = new Dictionary<string,GameObject>();
            SubDecorations["hero"] = GameObject.Find("deco_hero");
            SubDecorations["hero"].SetActive(true);
            SubDecorations["rocket"] = GameObject.Find("deco_rocket");
            SubDecorations["rocket"].SetActive(false);
            SubDecorations["helmet"] = GameObject.Find("deco_helmet");
            SubDecorations["helmet"].SetActive(false);

            particleList = new Dictionary<string, ParticleSystem>();
            particleList["dust"] = transform.Find("Par_Dust").GetComponent<ParticleSystem>();
            particleList["dec"] = transform.Find("Par_Dec").GetComponent<ParticleSystem>();
            particleList["flame"] = transform.Find("Par_Flame").GetComponent<ParticleSystem>();
            particleList["missiled"] = transform.Find("Par_Missled").GetComponent<ParticleSystem>();
            particleList["sheild"] = transform.Find("Par_Sheild").GetComponent<ParticleSystem>();
            particleList["slip"] = transform.Find("Par_Slip").GetComponent<ParticleSystem>();

            shooterGroup = new SimpleShooter[2];
            shooterGroup[0] = transform.Find("Add_ShooterLeft").GetComponent<SimpleShooter>();
            shooterGroup[1] = transform.Find("Add_ShooterRight").GetComponent<SimpleShooter>();
        }

        // Update is called once per frame
        void Update()
        {
            movement = new Vector2((Input.GetAxis("Horizontal") + Input.acceleration.x) * CurrentMorphoStatus.Speed * (1 + buffStatus.SpeedMul), 0);

            if ((facingleft && movement.x < 0) || (movement.x > 0 && !facingleft))
                flip();


            //CheckBuffTime
            for(int i=0;i<BuffWatcher.Count;) //Modified. Change to For.
            {
                BuffTimer[BuffWatcher[i]] -= Time.deltaTime;
                if (BuffTimer[BuffWatcher[i]] <= 0 && BuffTimer[BuffWatcher[i]] > -10000)
                {
                    BuffTimer[BuffWatcher[i]] = 0;
                    RemoveBuff(BuffWatcher[i]);

                }
                else i++;
            }

            //CheckMorphoTime
            if (currentMorpho != 0)
            {
                morphoTimeLeft -= Time.deltaTime;
                if (morphoTimeLeft <= 0 && morphoTimeLeft > -10000)
                {
                    morphoTimeLeft = 0;
                    SetMorphoType(0, 0);
                }
            }

            //CheckHP
            if (hp < 0&&currentMorpho!=201&& currentMorpho != 202) SetMorphoType(201, 999);
        }

        bool facingleft;
        void flip()
        {
            facingleft = !facingleft;
            Vector3 temp = SubDecorations["hero"].transform.localScale;
            temp.x *= -1;
            SubDecorations["hero"].transform.localScale = temp;
        }

        void FixedUpdate()
        {

            //Camera -> moved to followscreen.cs
            //if (nowvelocity.y > 0)
            //Camera.main.transform.position += new Vector3(0f, transform.position.y - Camera.main.transform.position.y, 0);
            //MainHelper.Instance.FollowCamera.transform.position += new Vector3(0f, transform.position.y - MainHelper.Instance.FollowCamera.transform.position.y, 0);

            switch(currentMorpho)
            {
                case 1:
                    m_RigidBody2D.velocity = new Vector2(0,CurrentMorphoStatus.Jump*(1+buffStatus.JumpMul));
                    m_RigidBody2D.velocity += movement;
                    break;
                default:
                    m_RigidBody2D.velocity = Vector2.Scale(m_RigidBody2D.velocity, Vector2.up);
                    m_RigidBody2D.velocity += movement;
                    break;
            }

        }


    }
}