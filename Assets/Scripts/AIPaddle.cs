using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour {

    public Ball theBall;

    public float speed = 30;

    public float lerpTweak = 2f;

    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {

        rigidBody = GetComponent<Rigidbody2D>();

	}


    void FixedUpdate () {

        // Make the paddle chase the ball in y direction
        var dir = new Vector2();

        if (theBall.transform.position.y + Random.Range(-5,5) > transform.position.y)
        {
            dir = new Vector2(0, 1).normalized;
        }
        else if (theBall.transform.position.y + Random.Range(-5, 5) < transform.position.y * Random.Range(0.5f, 2f))
        {
            dir = new Vector2(0, -1).normalized;
        }

        rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, 
            dir * speed, lerpTweak * Time.deltaTime);
	}
}
