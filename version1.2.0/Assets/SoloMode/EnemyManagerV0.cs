using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class EnemyManagerV0 : MonoBehaviour
    {
        Transform enemyMapPool;
        Transform enemyFloatPool;
        Transform heroTrans;
        public Object[] prefabEnemies;
        int nextCoconut;
        float timerMeteor;
        //float timerFlight;
        Object currentFlight;
        bool retreated;

        Object[] allEnemies;

        // Use this for initialization
        void Start()
        {
            enemyMapPool = transform.Find("MapEnemies").transform;
            enemyFloatPool = transform.Find("FloatEnemies").transform;
            heroTrans = GameObject.Find("Hero").transform;
            nextCoconut = 20;
            timerMeteor = 0;
            retreated = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (timerMeteor >= 0)
            {
                timerMeteor -= Time.deltaTime;
            }

            float currentHeight = heroTrans.position.y;

            if (currentHeight > 10 && currentHeight < 200)
            {
                if (currentHeight > 180)
                {
                }
                else if (currentHeight > nextCoconut)
                {
                    float x = Random.Range(1.5f, 3f) * (Random.Range((int)0, (int)2) * 2 - 1);
                    Instantiate(prefabEnemies[0], new Vector3(x, currentHeight + 10, 0), Quaternion.identity, enemyMapPool);
                    Instantiate(prefabEnemies[0], new Vector3(x, currentHeight + 12, 0), Quaternion.identity, enemyMapPool);
                    Instantiate(prefabEnemies[0], new Vector3(x, currentHeight + 14, 0), Quaternion.identity, enemyMapPool);
                    nextCoconut += 20;
                }
            }
            if (currentHeight > 220 && currentHeight < 400)
            {
                if (currentHeight > 380)
                {
                    if (currentFlight != null && !retreated)
                    {
                        ((GameObject)currentFlight).GetComponent<Enemy>().ChangeStatus(301);
                        retreated = true;
                    }

                }
                else
                {
                    if (currentFlight == null)
                        currentFlight = Instantiate(prefabEnemies[1], new Vector3(0, currentHeight + 8, 0), Quaternion.identity, enemyFloatPool);
                }
            }
            if (currentHeight > 400 && currentHeight < 500)
            {
                if (currentHeight > 480)
                {

                }
                else if (timerMeteor < 0)
                {
                    float x = Random.Range(1.5f, 2.5f) * (Random.Range((int)0, (int)2) * 2 - 1);
                    Rigidbody2D sp =
                        ((GameObject)Instantiate(prefabEnemies[2], new Vector3(x, currentHeight + 6, 0), Quaternion.identity, enemyMapPool))
                        .GetComponent<Rigidbody2D>();
                    sp.velocity = Vector3.Scale(Vector3.Normalize(new Vector3(-x, -3, 0)), new Vector3(2, 2, 0));

                    Onpu.print("Meteor:" + x.ToString() + " " + (currentHeight + 6) + " " + sp.velocity.ToString());
                    timerMeteor = 2.5f;
                }
            }

        }
    }
}