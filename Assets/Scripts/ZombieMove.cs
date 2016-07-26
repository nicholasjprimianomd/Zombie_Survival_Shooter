using UnityEngine;
using System.Collections;

public class ZombieMove : MonoBehaviour
{
	private Transform destination;
	public float zombieMoveSpeed = 2;

	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		destination = GameObject.FindGameObjectWithTag ("Player").transform;

		if (Vector3.Distance (transform.position, destination.position) > 0.5f) {
			transform.position += Vector3.Normalize (destination.position - transform.position) * Time.deltaTime * zombieMoveSpeed;
		}
	}

}
