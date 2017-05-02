using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

	float speed;
	public int direction;

	// Use this for initialization
	void Start () {
		speed = 3f;

	}
	
	// Update is called once per frame
	void Update () {
		//code by Pixelelement Games on youtube
		Vector2 position = transform.position;
		if (direction == 0) {
			//goes down
			position = new Vector2 (position.x, position.y - speed * Time.deltaTime);
		} else if (direction == 1) {
			//goes up
			position = new Vector2 (position.x, position.y + speed * Time.deltaTime);
		} else if (direction == 2) {
			//goes left
			position = new Vector2 (position.x - speed * Time.deltaTime, position.y);
		} else {
			//goes right
			position = new Vector2 (position.x + speed * Time.deltaTime, position.y);
		}
		transform.position = position;

		//for destroying the enemy
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0) );

		if (transform.position.y < min.y) {
			Destroy (gameObject);
		}

	}
}
