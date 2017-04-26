using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class CoinPowerup : MonoBehaviour
    {
        public int coin;
        public int score;

		AudioSource[] audios;
		public AudioClip coinAudio;

        // Use this for initialization
        void Start()
        {
			audios = GetComponents<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter2D(Collider2D e)
        {
            if (e.gameObject.tag.CompareTo("Player") == 0)
            {
                //Player player = e.GetComponent<Player>();
                //player.AddBuff("JumpMulDelta", value, time);
				MainHelper.Instance.addcoin(coin);//coin+=coin;
                MainHelper.Instance.score += score;
				// audios[0].PlayOneShot(coinAudio, 1f);
                Destroy(gameObject);
            }
        }
    }
}