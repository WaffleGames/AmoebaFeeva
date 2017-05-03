using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

	float speed;
	public int direction;
	public Vector2 scale;

	// Use this for initialization
	void Start () {
		
		float random_scale = Random.Range (1f, 6f);
		random_scale = Mathf.Round (random_scale);
		scale.x = random_scale;
		scale.y = random_scale;
		transform.localScale = scale;

		float random_speed = Random.Range (1f, 5f);
		random_speed = Mathf.Round (random_speed);

		speed = random_speed;
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
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1) );

		if (transform.position.y < min.y && direction ==0) {
			Destroy (gameObject);
		}

		if (transform.position.y > max.y && direction ==1) {
			Destroy (gameObject);
		}

		if (transform.position.x < min.x && direction ==2) {
			Destroy (gameObject);
		}

		if (transform.position.x > max.x && direction ==3) {
			Destroy (gameObject);
		}

	}


}
