using UnityEngine;
using System.Collections;

public class BulletKillZombie : MonoBehaviour
{

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Zombie") {
			Destroy (coll.gameObject);
			Destroy (gameObject);
			print ("debug 1");
		}

	}
}
