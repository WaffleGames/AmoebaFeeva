using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eating : MonoBehaviour {
	public float RedBar{ get; set; }
	public float BlackBar{ get; set; }
	public float BlueBar{ get; set; }

	public float Health{ get; set; }
		
	//the actual sliders
	public Slider red;
	public Slider black;
	public Slider blue;

	// Use this for initialization
	void Start () {
		Health = 1;

		RedBar = 0;
		BlackBar = 0;
		BlueBar = 0;

		red.value = 20;
		black.value = 40;
		blue.value = 10;
	}

	//calculates the value for the given health bar
	//pass it the collided creature's color as a number?
	//1 - red
	//2 - black
	//3 - blue
	//other (invincibility, other effects) not handled by this function. Ignore.
	float calculate(){
		return 10.9f;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
