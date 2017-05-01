using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_scene : MonoBehaviour {
	
	// Update is called once per frame
	public void changeScene (int sceneNum) {
		SceneManager.LoadScene (sceneNum);
	}
}
