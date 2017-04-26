using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class Em_Durian : MonoBehaviour, IDamage
    {
        public int score;
        public int hp;
        public int maxhp;
        public int MaxHp { set { maxhp = value; } get { return maxhp; } }
        public int Hp { set { hp = value; } get { return hp; } }
        public bool IsIDamageWork { get { return false; } }
        public bool IsShield { get { return false; } }
        public int damage;

        ParticleSystem dead;

        public void Damage(int damageto)
        {
            hp -= damageto;
        }

        // Use this for initialization
        void Start()
        {
            dead = gameObject.GetComponent<ParticleSystem>();
            
            if (MaxHp == 0) MaxHp = 100;
            hp = maxhp;
            ChangeStatus(0);
        }

        public int nowStatus;

        public float statusTimeLeft;

        public void ChangeStatus(int nextStatus)
        {
            switch (nextStatus)
            {
                case 0://Begin
                    statusTimeLeft = 0.1f;
                    break;
                case 101:
                    statusTimeLeft = 10f;
                    break;
                case 201://Dead
                    dead.Play();
                    MainHelper.Instance.enemykilled += score;
                    statusTimeLeft = 0.1f;
                    break;
                case 202://Destroy
                    dead.Stop();
                    this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                    statusTimeLeft = 0.2f;
                    break;
                default:
                    break;
            }
            nowStatus = nextStatus;
        }

        void ChangeStatusEnd(int nextStatus)
        {
            switch (nextStatus)
            {
                case 0://Begin
                    ChangeStatus(101);
                    break;
                case 101:
                    ChangeStatus(101);
                    break;
                case 201://Dead
                    ChangeStatus(202);
                    break;
                case 202://Destroy
                    Destroy(gameObject);
                    break;
                default:
                    break;
            }
        }

        // Update is called once per frame
        void Update()
        {

            //StatusFunction
            if (statusTimeLeft > 0)
            {
                statusTimeLeft -= Time.deltaTime;

                if (statusTimeLeft < 0)
                {
                    statusTimeLeft = 0;
                    ChangeStatusEnd(nowStatus);
                }
            }

            if (Hp < 0 && nowStatus != 201 && nowStatus != 202)
            {
                ChangeStatus(201);
            }
        }
        void OnTriggerEnter2D(Collider2D e) //Need to move to seperate codes.
        {
            if (e.gameObject.tag.CompareTo("Player") == 0)
            {
                Player player = e.GetComponent<Player>();
                if (!player.buffStatus.IsShield)
                {
                    player.Hp -= damage;
                }
                Destroy(gameObject);
            }
        }
    }
}