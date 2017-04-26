using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class Enemy : MonoBehaviour, IDamage
    {

        int hp;
        public int score;
        public int maxhp;
        public int MaxHp { set { maxhp = value; }get { return maxhp; } }
        public int Hp { set { hp = value; } get { return hp; } }
        public bool IsIDamageWork { get { return false; } }
        public bool IsShield { get { return false; } }
        public ParticleSystem dead;

        public void Damage(int damageto)
        {
            hp -= damageto;
        }

        // Use this for initialization
        void Start()
        {
            dead= transform.Find("Display/Enemy_Par_Missled").GetComponent<ParticleSystem>();

            Transform bulletcollection = GameObject.Find("FloatBullets").transform;
            transform.Find("Display/LeftShooter").GetComponent<SimpleShooter>().bulletcollection = bulletcollection;
            transform.Find("Display/RightShooter").GetComponent<SimpleShooter>().bulletcollection = bulletcollection;

            if (MaxHp == 0) MaxHp = 100;
            hp = maxhp;
            ChangeStatus(0);
        }

        public int nowStatus;
        public Vector3 moveTarget;
        public Vector3 moveStart;
        public float moveLeft;
        public float moveStep;
        public float moveSpec;

        public float statusTimeLeft;

        public void ChangeStatus(int nextStatus)
        {
            switch(nextStatus)
            {
                case 0://Begin
                    transform.Find("Display/LeftShooter").GetComponent<SimpleShooter>().ShootEnable = false;
                    transform.Find("Display/RightShooter").GetComponent<SimpleShooter>().ShootEnable = false;
                    MoveTo(new Vector3(0, -4, 0), 2.8f, 2,false);
                    statusTimeLeft = 3;
                    break;
                case 101:
                    switch (Random.Range(11, 12))
                    {
                        case 10:
                            break;
                        case 11:
                            Vector3 rnddir = new Vector3((transform.localPosition.x<0?1f:-1f)*Random.Range(0,2f), 0, 0);
                            if (transform.localPosition.x + rnddir.x < 3 && transform.localPosition.x + rnddir.x > -3)
                                MoveTo(rnddir, 1, 2, false);
                            break;
                        default:
                            //Should Never Reached
                            break;
                    }
                    statusTimeLeft = 3;
                    break;
                case 201://Dead
                    dead.Play();
                    statusTimeLeft = 0.5f;
                    break;
                case 202://Destroy
                    dead.Stop();
                    this.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
                    statusTimeLeft = 0.5f;
                    break;
                case 301://Retreat
                    MoveTo(new Vector3(0, 6, 0), 2.8f, 1, false);
                    transform.Find("Display/LeftShooter").GetComponent<SimpleShooter>().ShootEnable = false;
                    transform.Find("Display/RightShooter").GetComponent<SimpleShooter>().ShootEnable = false;
                    statusTimeLeft = 3f;
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
                    transform.Find("Display/LeftShooter").GetComponent<SimpleShooter>().ShootEnable = true;
                    transform.Find("Display/RightShooter").GetComponent<SimpleShooter>().ShootEnable = true;
                    ChangeStatus(101);
                    break;
                case 101:
                    ChangeStatus(101);
                    break;
                case 201://Dead
                    
                    ChangeStatus(202);
                    break;
                case 202://Destroy
                    MainHelper.Instance.enemykilled+=score;
                    Destroy(gameObject);
                    break;
                case 301://Destroy
                    Destroy(gameObject);
                    break;
                default:
                    break;
            }
        }

        void MoveTo(Vector3 target, float time, float spec,bool isfixed)
        {
            moveStart = transform.localPosition;
            moveTarget = target;
            if (!isfixed) moveTarget += moveStart;
            moveLeft = 1;
            moveStep = 1/time;
            moveSpec = 1/spec;
        }

        // Update is called once per frame
        void Update()
        {

            //MoveFunction
            if (moveLeft > 0)
            {
                moveLeft -= moveStep * Time.deltaTime;
                
                if (moveLeft < 0) moveLeft = 0;
                transform.localPosition = Vector3.Lerp(moveStart, moveTarget, Mathf.Pow(1 - moveLeft,moveSpec));
            }

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

            if (hp < 0&&nowStatus!=201 && nowStatus != 202)
            {
                ChangeStatus(201);
            }
        }
    }
}