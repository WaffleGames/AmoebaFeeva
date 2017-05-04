using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//code edited from https://noobtuts.com/unity/2d-pong-game
public class Movement : MonoBehaviour {
	public float playerSpeed = 20; 
	public float playerFriction = 0.5f;
	public Vector2 curVelocity;
	private SpriteRenderer mySpriteRenderer;
	public Vector3 screenPos;
	public float amPosX;
	public float amPosY;
	private float xBound = Screen.width - 15;
	private float yBound = Screen.height - 15;
	public Vector2 playerScale;
	public float roundedVelX;
	public float roundedVelY;





	private void Awake(){
		// get a reference to the SpriteRenderer component on this gameObject
		mySpriteRenderer = GetComponent<SpriteRenderer>();

		playerScale.x = 0.25f;
		playerScale.y = 0.25f;
		transform.localScale = playerScale;
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
		if (v > 0) { 
			mySpriteRenderer.flipY = false;
		}else {
			if(v < 0){
				mySpriteRenderer.flipY = true;
			}
		}


		//GetComponent<Rigidbody2D>().velocity = new Vector2(h, v) * playerSpeed;

		//if(v ==0 && h == 0){
			roundedVelX = Mathf.Round (curVelocity.x);
			roundedVelY = Mathf.Round (curVelocity.y);
				if ( roundedVelX==0 || roundedVelY ==0) {
					if (roundedVelX==0) {
						GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, playerFriction * v));
				}
					if (roundedVelY==0) {
						GetComponent<Rigidbody2D>().AddForce(new Vector2 (playerFriction * h, 0));
				}
			}else	GetComponent<Rigidbody2D>().AddForce(new Vector2 (playerFriction * h, playerFriction * v));
		//}
		screenPos = Camera.main.WorldToScreenPoint(transform.position);
		amPosX = screenPos.x;
		amPosY = screenPos.y;
		//print (transform.position);




	}

	void OnTriggerEnter2D(Collider2D col){
		
		if (col.gameObject.tag == "bacteria") {
			//print ("Collided with bacteria!");

			//get the size
			//if safe to eat, continue. If not, DIE.
			enemyMovement bacteria = (enemyMovement)col.gameObject.GetComponent<enemyMovement>();

			//print ("bacteria scale: " + bacteria.scale.x + " player scale " + playerScale.x); 

			if(bacteria.scale.x <= playerScale.x){
				//print("Safe to eat!");

				//get color
				SpriteRenderer renderer = bacteria.GetComponent<SpriteRenderer> ();
				//print(renderer.color);

			}else{
				SpriteRenderer renderer = bacteria.GetComponent<SpriteRenderer> ();
				//TEMPORARY. MOVE UP LATER
				if (renderer.material.GetColor ("_Color") == Color.red) {
					//up red point bar
					//print("Red");
				}else if(renderer.material.GetColor ("_Color") == Color.black){
					//up black point bar
					//print("Black");
				}else if(renderer.material.GetColor ("_Color") == Color.blue){
					//up blue point bar
					//print ("Blue");
				}
				
				//print("YOU DIED!");
			}
				
		}

	}

}

