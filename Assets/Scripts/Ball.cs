using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public float speed = 30;

	private Rigidbody2D rigidBody;

	private AudioSource audioSoure;

	// Use this for initialization
	void Start () {
		
		//get object from the game component(by drag & drop)
		rigidBody = GetComponent<Rigidbody2D> ();

		//set init velocity
		rigidBody.velocity = new Vector2(1,0).normalized * speed;
        
	}
	
	// collision behavior
	void OnCollisionEnter2D (Collision2D coll) {

		// Check what it collide with
        // Paddle
		if(coll.gameObject.name == "PaddleLeft" || coll.gameObject.name == "PaddleRight")
        {
            HandlePaddleHit(coll);

            SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitPaddleBloop);
		}

        // Wall
        else if(coll.gameObject.name == "WallTop" || coll.gameObject.name == "WallBottom")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallBloop);
        }

        // Goal
        else if(coll.gameObject.name == "GoalLeft" || coll.gameObject.name == "GoalRight")
	    {
            //reset ball position
            transform.position = new Vector2(0, 0);

            //update UI score
            if (coll.gameObject.name == "GoalLeft")
            {
                IncreaseScoreText("RightScoreUI");
            }
            else
            {
                IncreaseScoreText("LeftScoreUI");
            }

            SoundManager.Instance.PlayOneShot(SoundManager.Instance.goalBloop);
        }

	}

    private void IncreaseScoreText(string textUIname)
    {

        var textUIComp = GameObject.Find(textUIname).GetComponent<Text>();

        int score = int.Parse(textUIComp.text);

        score++;

        textUIComp.text = score.ToString();

    }

    private void HandlePaddleHit(Collision2D col)
    {
        // The relative verticall position hit on the paddle
        float y = (transform.position.y - col.transform.position.y) / col.collider.bounds.size.y;

        Vector2 dir = new Vector2();

        if (col.gameObject.name == "PaddleLeft")
        {
            dir = new Vector2(1, y).normalized;
        }
        else if (col.gameObject.name == "PaddleRight")
        {
            dir = new Vector2(-1, y).normalized;
        }

        rigidBody.velocity = dir * speed;
    }

}
