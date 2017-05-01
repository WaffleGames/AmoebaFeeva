using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eating : MonoBehaviour {
	public float RedBar{ get; set; }
	public float BlackBar{ get; set; }
	public float BlueBar{ get; set; }

	public float Health{ get; set; }
		

	// Use this for initialization
	void Start () {
		Health = 1;

		RedBar = 0;
		BlackBar = 0;
		BlueBar = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
