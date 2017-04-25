using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class DrawingShield : MonoBehaviour
    {
        
        int maxShieldPoint=1000;

        int shieldStatus;
        //Rect shieldRange = new Rect(0f, 300f, 500f, 800f);
        Rect shieldRange = new Rect(0f, 0f, 800f, 1200f);

        Vector3[] shieldPointGroup;
        Object[] shieldGroup;
        int pShieldGroup;
        public Object prototype;
        public Transform fakeShieldCollection;
        public Transform realShieldCollection;
        //Touch targetTouch;
        int targetIndex;
        Vector2 lastPosition;

        LineRenderer lren;

        EdgeCollider2D lcol;

        public float maxShieldLength;
        public float currentShieldLength;

        public float shieldTimer;
        public float totalShieldTime;

        // Use this for initialization
        void Start()
        {
            shieldGroup = new Object[maxShieldPoint];
            shieldPointGroup = new Vector3[maxShieldPoint];


            shieldStatus = 0;
            //dbldeltatime = 0;
            pShieldGroup = 0;
            
            lren = realShieldCollection.GetComponent<LineRenderer>();
            lcol = realShieldCollection.GetComponent<EdgeCollider2D>();
            //lren.SetVertexCount(4);
        }


        //float dbldeltatime;
        // Update is called once per frame
        void Update()
        {
            //dbldeltatime += Time.deltaTime;
            //if (dbldeltatime < 0.02) return;
            //else dbldeltatime = 0;

            //Timer
            if (shieldTimer >= 0)
            {
                shieldTimer -= Time.deltaTime;
                lcol.isTrigger = true;

                lren.startColor = new Color(255, 255, 255, (1-totalShieldTime + shieldTimer) / totalShieldTime);
                lren.endColor = new Color(255, 255, 0, (1-totalShieldTime + shieldTimer) / totalShieldTime);
            }
            else lcol.isTrigger = false;

            //Automachine
            switch (shieldStatus)
            {
                case 1:
                    if (Input.touchCount==0)//Will change for multi
                    {
                        shieldStatus = 2;
                        break;
                    }

                    Vector2 sa = Input.touches[targetIndex].position - lastPosition;

                    if (sa.magnitude>10f)
                    {
                        
                        lastPosition = Input.touches[targetIndex].position;
                        shieldGroup[pShieldGroup]=
                            Instantiate(prototype, MainHelper.Instance.CurrentCamera.GetComponent<Camera>().ScreenToWorldPoint(lastPosition)+new Vector3(0,0,10) , Quaternion.identity, fakeShieldCollection);
                        shieldPointGroup[pShieldGroup] = lastPosition;
                        
                        pShieldGroup += 1;
                    }

                    //MaxLen
                    currentShieldLength += sa.magnitude;
                    if (currentShieldLength > maxShieldLength) shieldStatus = 3;
                    break;
                case 2:
                    lren.numPositions=pShieldGroup;
                    //lcol.points = new Vector2[pShieldGroup];

                    Vector2[] shieldPointGroup2D=new Vector2[pShieldGroup]; //Complete at Once

                    for (int i=0;i<pShieldGroup;i++)
                    {
                        Destroy(shieldGroup[i]);
                        lren.SetPosition(i, MainHelper.Instance.CurrentCamera.GetComponent<Camera>().ScreenToWorldPoint(shieldPointGroup[i]) - MainHelper.Instance.CurrentCamera.GetComponent<Camera>().transform.position);
                        //Vector2 temp = MainHelper.Instance.CurrentCamera.GetComponent<Camera>().ScreenToWorldPoint(shieldPointGroup[i]);
                        //lcol.points[i] .Set(temp.x,temp.y);
                        shieldPointGroup2D[i]= MainHelper.Instance.CurrentCamera.GetComponent<Camera>().ScreenToWorldPoint(shieldPointGroup[i]) - MainHelper.Instance.CurrentCamera.GetComponent<Camera>().transform.position;
                    }

                    lren.startColor = new Color(255, 255, 255, 255);
                    lren.endColor = new Color(255, 255, 0, 255);
                    shieldTimer = totalShieldTime;

                    lcol.points = shieldPointGroup2D;
                    shieldStatus = 0;
                    break;
                case 3:
                    if (Input.touchCount == 0)//Will change for multi
                    {
                        shieldStatus = 2;
                        break;
                    }
                    break;
                default:
                    for (int i=0;i<Input.touchCount;i++ )
                    {
                        if (shieldRange.Contains(Input.touches[i].position))
                        {
                            lren.numPositions = 0;
                            pShieldGroup = 0;
                            currentShieldLength = 0;

                            //targetTouch = Input.touches[i];
                            targetIndex = i;
                            shieldStatus = 1;
                            lastPosition = Input.touches[targetIndex].position;
                            break;
                        }
                    }
                    break;
            }
        }

        private void FixedUpdate()
        {
            
        }
    }
}