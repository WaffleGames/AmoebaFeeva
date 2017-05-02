using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

	public GameObject enemy_blob;

	float maxSpawnRateInSeconds = 5f;

	// Use this for initialization
	void Start () {
		Invoke ("spawnBlob", maxSpawnRateInSeconds);
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
		anEnemy.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

	
	}
}
