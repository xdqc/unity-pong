using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		//press key by user
		float vertPress = Input.GetAxisRaw("Vertical");

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, vertPress) * speed;
	}


	//move speed of the paddle
	public float speed = 30;
}
