﻿using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class PlayerShoot : MonoBehaviour
{

	public GameObject bullet;
	public Transform spawnPoint;
	public float xOffset = 0;
	public float yOffset = 1;
	public float bulletSpeed = .00001f;

	// Update is called once per frame
	void Update ()
	{
		Vector2 bulletDirection = (spawnPoint.position - transform.position).normalized;
		if ((Input.GetKeyDown (KeyCode.Space))) {
			GameObject bulletPrefab = Instantiate (bullet, spawnPoint.position, transform.rotation) as GameObject;
			Rigidbody2D bulletRigidBody2D = bulletPrefab.GetComponent<Rigidbody2D> ();
			bulletRigidBody2D.AddForce (bulletDirection * bulletSpeed, ForceMode2D.Impulse);
		}
	}
}
