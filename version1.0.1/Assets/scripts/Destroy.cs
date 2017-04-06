using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
    
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            Destroy(gameObject);
        }
    }
}
