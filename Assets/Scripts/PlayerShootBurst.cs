using UnityEngine;
using System.Collections;

public class PlayerShootBurst : MonoBehaviour
{

	public GameObject bullet;
	public Transform spawnPoint;
	public Transform spawnPointLeft;
	public Transform spawnPointRight;
	public float xOffset = 0;
	public float yOffset = 1;
	public float bulletSpeed;
	public bool canShoot = true;
	private int rounds;

	void Start ()
	{
		rounds = GetComponent<PlayerShoot> ().rounds;
	}

	void Update ()
	{
		//if (Input.GetKeyDown (KeyCode.R) && ammo > 0) {
		//	reload ();
		//}

		if (canShoot && rounds > 0) {
			//	shoot ();
		}
	}

	void shootBurst ()
	{
		if (Input.GetMouseButtonDown (1) && !Input.GetMouseButtonDown (0)) {
			Vector2 bulletDirection = (spawnPointLeft.position - transform.position /* + new Vector3(0,10,0)*/).normalized;
			GameObject bulletPrefab = Instantiate (bullet, spawnPointLeft.position, transform.rotation) as GameObject;
			Rigidbody2D bulletRigidBody2D = bulletPrefab.GetComponent<Rigidbody2D> ();
			bulletRigidBody2D.AddForce (bulletDirection * bulletSpeed, ForceMode2D.Impulse);

			Vector2 bulletDirection2 = (spawnPoint.position - transform.position).normalized;
			GameObject bulletPrefab2 = Instantiate (bullet, spawnPoint.position, transform.rotation) as GameObject;
			Rigidbody2D bulletRigidBody2D2 = bulletPrefab2.GetComponent<Rigidbody2D> ();
			bulletRigidBody2D2.AddForce (bulletDirection2 * bulletSpeed, ForceMode2D.Impulse);

			Vector2 bulletDirection3 = (spawnPointRight.position - transform.position /* + new Vector3(0,5,0)*/).normalized;
			GameObject bulletPrefab3 = Instantiate (bullet, spawnPointRight.position, transform.rotation) as GameObject;
			Rigidbody2D bulletRigidBody2D3 = bulletPrefab3.GetComponent<Rigidbody2D> ();
			bulletRigidBody2D3.AddForce (bulletDirection3 * bulletSpeed, ForceMode2D.Impulse);

			rounds -= 1;
			print ("Num rounds: " + rounds);
		}
	}
		
}
