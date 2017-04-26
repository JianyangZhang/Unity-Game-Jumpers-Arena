using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena {
	public class simplescroll : MonoBehaviour {

		public Vector3 multiplyer;
		Vector3 beginPosition;

		public Vector3 beginHeight;
		public Vector3 endHeight; //Cancelled

		public Player hero;

		// Use this for initialization
		void Awake () {
			beginPosition = transform.position;
		}

		// Update is called once per frame
		void Update () {

			if (hero == null) return;//Why?

			Vector3 offset = endHeight-beginHeight;

			if (hero.transform.position.y < endHeight.y)
				offset = Vector3.Scale(hero.transform.position - beginHeight,Vector2.one);

			offset.Scale(multiplyer);
			//Vector2.Scale(speed,direction) * Time.deltaTime;
			transform.position=beginPosition+offset;
		}
	}
}