using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena{
	public class SimpleFloor : MonoBehaviour {

        public float JumpMul = 0;
		AudioSource[] audios;
		// Use this for initialization
		void Start () {
			audios = GetComponents<AudioSource>();
		}
		
		// Update is called once per frame
		void Update () {
			/*Camera.main.transform*/
			//if (Camera.main.transform.position.y + (-5) > transform.position.y)
			//	Destroy (gameObject);
		}

		void OnTriggerEnter2D(Collider2D e)
		{
			if (e.gameObject.tag.CompareTo("Player")==0)  
			{
                Player player = e.gameObject.GetComponent<Player>();
                if (player.velocity.y < 0)
                {
                    Onpu.print("Touch");
                    player.velocity = new Vector2(0,  player.CurrentMorphoStatus.Jump*(1+player.buffStatus.JumpMul)*(1 + JumpMul));//old:12
					audios[0].Play();
                    //Destroy(e.gameObject);
                }
            }  
		}
	}
}