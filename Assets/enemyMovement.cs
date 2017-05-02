using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

	float speed;

	// Use this for initialization
	void Start () {
		speed = 3f;
	}
	
	// Update is called once per frame
	void Update () {
		//code by Pixelelement Games on youtube
		Vector2 position = transform.position;

		position = new Vector2 (position.x, position.y - speed * Time.deltaTime);

		transform.position = position;

		//for destroying the enemy
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0) );

		if (transform.position.y < min.y) {
			Destroy (gameObject);
		}

	}
}
