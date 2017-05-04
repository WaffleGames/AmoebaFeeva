using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

	public GameObject enemy_blob;

	float maxSpawnRateInSeconds = 5f;

	//heading:
	//0 = down
	//1 = up
	//2 = left
	//3 = right
	public int spawnDirection = 0;

	// Use this for initialization
	void Start () {
		Invoke ("spawnBlob", maxSpawnRateInSeconds);

		InvokeRepeating ("varyTheSpawnRate", 0f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//spawns the blob. Altered from Pixelelement Games
	void spawnBlob(){
		//bottom left corner of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//top right corner of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));	
	

		GameObject anEnemy = (GameObject)Instantiate (enemy_blob);
		anEnemy.GetComponent<enemyMovement> ().direction = spawnDirection;

		int colouring = Random.Range (0, 3);
		SpriteRenderer renderer = anEnemy.GetComponent<SpriteRenderer> ();

		if (colouring == 0) {
			//it's red
			renderer.material.SetColor("_Color", Color.red);
		} else if (colouring == 1) {
			//it's black
			renderer.material.SetColor("_Color", Color.black);
		} else {
			//it's blue
			renderer.material.SetColor("_Color", Color.blue);
		}


		if (spawnDirection == 0) {
			//goes down
			anEnemy.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);
		} else if (spawnDirection == 1) {
			//goes up
			anEnemy.transform.position = new Vector2 (Random.Range (min.x, max.x), min.y);
		} else if (spawnDirection == 2) {
			//goes left
			anEnemy.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));
		} else {
			//goes right
			anEnemy.transform.position = new Vector2 (min.x, Random.Range (min.y, max.y));
		}
		ScheduleNextEnemySpawn ();
	
	}

	void ScheduleNextEnemySpawn(){

		float spawnInNSeconds;

		if (maxSpawnRateInSeconds > 1f) {
			spawnInNSeconds = Random.Range (1f, maxSpawnRateInSeconds);
		} else {
			spawnInNSeconds = 1f;
		}

		Invoke ("spawnBlob", spawnInNSeconds);
	}


	void varyTheSpawnRate(){
		maxSpawnRateInSeconds = Random.Range (1f, 5f);
		spawnDirection = Random.Range (0, 4);
	}


}
