using UnityEngine;
using System.Collections;

public class DestroyGrapple : MonoBehaviour
{

	private GameObject player;

	// Use this for initialization
	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((transform.position - player.transform.position).magnitude > 10) {
			Destroy (gameObject);
		}
	}
}
