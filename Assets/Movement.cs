using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//code edited from https://noobtuts.com/unity/2d-pong-game
public class Movement : MonoBehaviour {
	public float playerSpeed = 10; 
	public float playerFriction = 0.5f;
	public Vector2 curVelocity;
	private SpriteRenderer mySpriteRenderer;
	public Vector3 screenPos;
	public float amPosX;
	public float amPosY;
	private float xBound = Screen.width - 15;
	private float yBound = Screen.height - 15;


	private void Awake(){
		// get a reference to the SpriteRenderer component on this gameObject
		mySpriteRenderer = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate () {
		float v = Input.GetAxisRaw("Vertical");
		float h = Input.GetAxisRaw("Horizontal");
		curVelocity = GetComponent<Rigidbody2D> ().velocity;

		if (h > 0) { 
			mySpriteRenderer.flipX = true;
		}else {
			if(h < 0){
				mySpriteRenderer.flipX = false;
			}
		}
		//Vector2 velocity = new Vector2(h, v) * playerSpeed;
		GetComponent<Rigidbody2D>().AddForce(new Vector2 (playerFriction * h, playerFriction * v));

		screenPos = Camera.main.WorldToScreenPoint(transform.position);
		amPosX = screenPos.x;
		amPosY = screenPos.y;
		//print (screenPos);
		//when the amoeba exits boundary, comes back through opposite side
		//left side
		if (amPosX < 0){ //too far on the left, so appear on the right
			//Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, amPosY, screenPos.z)).x;
			transform.Translate(xBound*Time.deltaTime,0,0,Space.World);
		} else	//Right side
			if (amPosX > xBound){
				transform.Translate((-1)*xBound*Time.deltaTime,0,0,Space.World);
			}
		//bottom 
		if (amPosY < 0){
			transform.Translate (0,yBound*Time.deltaTime,0,Space.World);
		}else	//top
			if (amPosY > yBound){
				transform.Translate (0,(-1)*yBound*Time.deltaTime,0,Space.World);
			}


	}
}
