using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//code edited from https://noobtuts.com/unity/2d-pong-game
public class Movement : MonoBehaviour {
	public float playerSpeed = 5000; 
	public float playerFriction = .2f;
	public Vector2 curVelocity;
	private SpriteRenderer mySpriteRenderer;
	public Vector3 screenPos;
	public float amPosX;
	public float amPosY;
	public float roundedVelX;
	public float roundedVelY;






	private void Awake(){
		// get a reference to the SpriteRenderer component on this gameObject
		mySpriteRenderer = GetComponent<SpriteRenderer>();
	}
		
	void FixedUpdate () {
		float v = Input.GetAxisRaw("Vertical");
		float h = Input.GetAxisRaw("Horizontal");


		if (h > 0) { 
			mySpriteRenderer.flipX = true;
		}else {
			if(h < 0){
				mySpriteRenderer.flipX = false;
			}
		}
		if (v > 0) { 
			mySpriteRenderer.flipY = false;
		}else {
			if(v < 0){
				mySpriteRenderer.flipY = true;
			}
		}



		//GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * playerSpeed * v);
		//GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * playerSpeed * h);
		//GetComponent<Rigidbody2D>().velocity = new Vector2(h, v) * playerSpeed;
		curVelocity = GetComponent<Rigidbody2D> ().velocity;
		GetComponent<Rigidbody2D> ().AddForce (new Vector2(playerSpeed*h,playerSpeed*v));


		/*if (h == 0) {
			Vector2 temp = new Vector2 ((-1) * playerFriction * curVelocity.x, 0);
			GetComponent<Rigidbody2D> ().AddForce (temp);
			curVelocity = GetComponent<Rigidbody2D> ().velocity;
			roundedVelX = Mathf.Round (curVelocity.x);
			if (roundedVelX == 0) {
				GetComponent<Rigidbody2D> ().velocity = (new Vector2 (0,curVelocity.y));
				curVelocity = GetComponent<Rigidbody2D> ().velocity;
			}
		}
		if(v == 0){
			Vector2 temp = new Vector2 (0, (-1) * playerFriction * curVelocity.y);
			GetComponent<Rigidbody2D> ().AddForce (temp);
			curVelocity = GetComponent<Rigidbody2D> ().velocity;
			roundedVelY = Mathf.Round (curVelocity.y);
			if (roundedVelY == 0) {
				GetComponent<Rigidbody2D> ().velocity =  (new Vector2 (curVelocity.x, 0));
			}
		}
*/

	
			

		 






	}
}

