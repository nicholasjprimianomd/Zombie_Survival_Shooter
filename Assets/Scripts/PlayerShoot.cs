using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.Rendering;


public class PlayerShoot : MonoBehaviour
{

	public GameObject bullet;
	public Transform spawnPoint;
	public float xOffset = 0;
	public float yOffset = 1;
	public float bulletSpeed = .00001f;
	public bool canShoot = true;
	public int rounds = 8;
	public int ammo = 16;
	private const int maxRounds = 8;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.R) && ammo > 0) {
			reload ();
		}

		if (canShoot && rounds > 0) {
			shoot ();
		}
	}

	void shoot ()
	{
		if (!Input.GetMouseButtonDown (1) && Input.GetMouseButtonDown (0)) {
			Vector2 bulletDirection = (spawnPoint.position - transform.position).normalized;
			GameObject bulletPrefab = Instantiate (bullet, spawnPoint.position, transform.rotation) as GameObject;
			Rigidbody2D bulletRigidBody2D = bulletPrefab.GetComponent<Rigidbody2D> ();
			bulletRigidBody2D.AddForce (bulletDirection * bulletSpeed, ForceMode2D.Impulse);
			//rounds -= 1;
		}
	}

	void reload ()
	{
		int roundDeficit = maxRounds - rounds;
		//int roundsToAdd = roundDeficit - rounds;

		if (roundDeficit >= 0) {
			rounds += roundDeficit;
			while (ammo > 0 && roundDeficit > 0) {
				ammo -= 1;
				roundDeficit -= 1;
			}
		}
	}

}
