using UnityEngine;
using System.Collections;

public class CircleMove : MonoBehaviour
{
	public Transform destination;

	// Update is called once per frame
	void Update ()
	{
		if (Vector3.Distance (transform.position, destination.position) > 0.5f) {
			transform.position += Vector3.Normalize (destination.position - transform.position) * Time.deltaTime;
		}
	}

}
