using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Onpu : MonoBehaviour {

    Vector2 speed;
    float speedmul;
    Vector2 movement;
	public Camera maincamera;
	public Transform text;

	public Transform texthp;
	int hp;

	public Transform textheight;
	float height;

	Vector2 nowvelocity;

	// Use this for initialization
	void Start () {
        speed = new Vector2(0f,0f);
        speedmul = 5f;
		hp = 100;
	}
	
	// Update is called once per frame
    void Update()
    {
        //Onpu.print("What");

        /*speed += new Vector2(Input.GetAxis("Horizontal") * speedplus, Input.GetAxis("Vertical")*speedplus);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + Time.deltaTime * speed.x, -100f, 100f) ,
            Mathf.Clamp(transform.position.y + Time.deltaTime * speed.y, -100f, 100f),-5);*/

        /*transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + Time.deltaTime * speedplus * Input.GetAxis("Horizontal"), -100f, 100f),
            Mathf.Clamp(transform.position.y + Time.deltaTime * speedplus * Input.GetAxis("Vertical"), -100f, 100f), -5);*/

		movement = new Vector2(Input.GetAxis("Horizontal") * speedmul, 0);
		Text textx = text.GetComponent<Text>();  
		textx.text = nowvelocity.ToString ();

		texthp.GetComponent<Text> ().text = "HP: "+hp.ToString ();

		textheight.GetComponent<Text> ().text = "Height: " + maincamera.transform.position.y.ToString ();

		//if (transform.position.x > 4f)
		//	transform.position = new Vector3(-3.99f,transform.position.y,transform.position.z);

		//if (transform.position.x < -4f)
		//	transform.position = new Vector3 (3.99f, transform.position.y, transform.position.z);
	}
    void FixedUpdate()
	{

		nowvelocity = GetComponent<Rigidbody2D> ().velocity;
		GetComponent<Rigidbody2D> ().velocity= new Vector2(0f,GetComponent<Rigidbody2D> ().velocity.y);
		GetComponent<Rigidbody2D> ().velocity+= movement;

		//if (nowvelocity.y > 0)
			//maincamera.transform.position += new Vector3 (0f, Mathf.Max(transform.position.y-maincamera.transform.position.y,0) ,0);
		maincamera.transform.position += new Vector3 (0f, transform.position.y-maincamera.transform.position.y ,0);

    }

	void OnTriggerEnter2D(Collider2D e)
	{
		if (e.gameObject.tag.CompareTo("Floor")==0&&(nowvelocity.y < 0))  
		{   
			Onpu.print("Touch");  
			//speedplus += 2f;
			GetComponent<Rigidbody2D>().velocity=new Vector2(0,15);
			//Destroy(e.gameObject);
		}  
	}
}
