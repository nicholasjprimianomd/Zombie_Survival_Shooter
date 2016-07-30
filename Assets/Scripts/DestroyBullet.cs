using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour
{

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Bullet") {
			Destroy (coll.gameObject);
		}
		Debug.Log ("Destroy Bullet!");
	}
}
