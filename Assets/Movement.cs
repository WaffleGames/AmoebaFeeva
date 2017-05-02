using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//code edited from https://noobtuts.com/unity/2d-pong-game
public class Movement : MonoBehaviour {
	public float playerSpeed = 10; 
	public float playerFriction = 0.5f;
	public Vector2 curVelocity;
	private SpriteRenderer mySpriteRenderer;

	private void Awake(){
		// get a reference to the SpriteRenderer component on this gameObject
		mySpriteRenderer = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate () {
		float v = Input.GetAxisRaw("Vertical");
		float h = Input.GetAxisRaw("Horizontal");
		curVelocity = GetComponent<Rigidbody2D> ().velocity;
		print (curVelocity);
		if (h > 0) { 
			mySpriteRenderer.flipX = true;
		}else {
			if(h < 0){
				mySpriteRenderer.flipX = false;
			}
		}
		//Vector2 velocity = new Vector2(h, v) * playerSpeed;
		GetComponent<Rigidbody2D>().AddForce(new Vector2 (playerFriction * h, playerFriction * v));
		//GetComponent<Rigidbody2D>().velocity = new Vector2(h, v) * playerSpeed; //this is what worked before
	}
}
