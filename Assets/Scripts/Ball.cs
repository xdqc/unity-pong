using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float speed = 30;

	private Rigidbody2D rigidBody;

	private AudioSource audioSoure;

	// Use this for initialization
	void Start () {
		
		//get object from the game component(by drag & drop)
		rigidBody = GetComponent<Rigidbody2D> ();

		//set init velocity
		rigidBody.velocity = Vector2.right * speed;
	}
	
	// collision behavior
	void OnCollisionEnter2D (Collision2D coll) {

		//check what it collide with
		if(coll.gameObject.name == "PaddleLeft" || coll.gameObject.name == "PaddleRight"){
			
		}

	}
}
