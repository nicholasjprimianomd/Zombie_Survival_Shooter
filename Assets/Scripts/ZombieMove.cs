using UnityEngine;
using System.Collections;

public class ZombieMove : MonoBehaviour
{
	private Transform destination;
	public float zombieMoveSpeed = 2;
	public bool canMove = true;


	void Start ()
	{
		canMove = true;
	}


	void Update ()
	{
		destination = GameObject.FindGameObjectWithTag ("Player").transform;

		if (Vector3.Distance (transform.position, destination.position) > 1f && canMove) {
			transform.position += Vector3.Normalize (destination.position - transform.position) * Time.deltaTime * zombieMoveSpeed;
		}
	}

}
