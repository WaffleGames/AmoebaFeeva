using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour {
	//CONTROLS SHOOTING

	public bool isFiring;
	public amoebaShoot bullet;
	public float bulletSpeed;
	public float timeBetweenShots;
	private float shotCounter;
	public Transform firePoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isFiring) {
			shotCounter -= Time.deltaTime;
			if (shotCounter <= 0) {
				shotCounter = timeBetweenShots;
				amoebaShoot newBullet = Instantiate (bullet, firePoint.position, firePoint.rotation) as amoebaShoot;
				newBullet.bSpeed = bulletSpeed;
			}
		} else {
			shotCounter = 0;
		}

	}
}
