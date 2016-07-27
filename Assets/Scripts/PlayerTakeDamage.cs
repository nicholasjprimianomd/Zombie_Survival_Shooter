using UnityEngine;
using System.Collections;
using System;

public class PlayerTakeDamage : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth = 100;

	void Update ()
	{
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Zombie") {
			currentHealth -= 1;
		}
	}
}
