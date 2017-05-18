using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amoebaShoot : MonoBehaviour {
	//CONTROLS THE BULLET
	public float bSpeed = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.up * bSpeed * Time.deltaTime);
	}
}
