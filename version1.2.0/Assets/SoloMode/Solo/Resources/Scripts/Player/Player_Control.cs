using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena{

	//[RequireComponent(typeof(Onpu))]
	public class Player_Control : MonoBehaviour {

		private Player m_Hero;

		void Awake()
		{
			m_Hero = GetComponent<Player> ();
		}

		
		// Update is called once per frame
		void Update () {
			
		}

		void FixedUpdate () {
		}
	}
}