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

		if (v != 0 && h != 0) { //if both are pressed at once
			if ((v > 0 && h > 0) || (v > 0 && h < 0)) { //up and right or up and left, show up animation
				GetComponent<Animator> ().SetFloat ("Diry", v);
			} else if ((v < 0 && h > 0) || (v < 0 && h < 0)) { //down and right or down and left, show down animation
				GetComponent<Animator> ().SetFloat ("Diry", v);
			}


		} else {
			GetComponent<Animator> ().SetFloat ("Diry", v);
			GetComponent<Animator> ().SetFloat ("Dirx", h);
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

